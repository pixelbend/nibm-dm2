CREATE OR REPLACE FUNCTION Generate_UUID RETURN VARCHAR2 IS
    UUIDRaw RAW(16);
BEGIN
    UUIDRaw := SYS_GUID();
    RETURN RAWTOHEX(UUIDRaw);
END Generate_UUID;

CREATE TABLE Suppliers
(
    SupplierID VARCHAR2(32) PRIMARY KEY,
    Name       VARCHAR2(255) UNIQUE NOT NULL,
    Email      VARCHAR2(255) UNIQUE NOT NULL,
    Password   VARCHAR2(255)        NOT NULL,
    Phone      VARCHAR2(20) UNIQUE  NOT NULL,
    Address    VARCHAR2(500)        NOT NULL
);

CREATE OR REPLACE TRIGGER set_supplier_uuid
    BEFORE INSERT
    ON Suppliers
    FOR EACH ROW
BEGIN
    :NEW.SupplierID := Generate_UUID();
END;

CREATE TABLE Customers
(
    CustomerID VARCHAR2(32) PRIMARY KEY,
    Name       VARCHAR2(100)        NOT NULL,
    Email      VARCHAR2(255) UNIQUE NOT NULL,
    Password   VARCHAR2(255)        NOT NULL,
    Phone      VARCHAR2(20) UNIQUE  NOT NULL,
    Address    VARCHAR2(500)        NOT NULL
);

CREATE OR REPLACE TRIGGER set_customer_uuid
    BEFORE INSERT
    ON Customers
    FOR EACH ROW
BEGIN
    :NEW.CustomerID := Generate_UUID();
END;

CREATE TABLE Products
(
    ProductID     VARCHAR2(32) PRIMARY KEY,
    SupplierID    VARCHAR2(32)                      NOT NULL,
    Name          VARCHAR2(255)                     NOT NULL,
    Description   VARCHAR2(1000),
    Price         NUMBER(10, 2) CHECK (Price > 0)   NOT NULL,
    StockQuantity NUMBER CHECK (StockQuantity >= 0) NOT NULL,
    Category      VARCHAR2(20),
    AddedAt       TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Discontinued  NUMBER(1) DEFAULT 0 CHECK (Discontinued IN (0, 1)),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers (SupplierID),
    UNIQUE (SupplierID, Name)
);

CREATE OR REPLACE TRIGGER set_product_uuid
    BEFORE INSERT
    ON Products
    FOR EACH ROW
BEGIN
    :NEW.ProductID := Generate_UUID();
END;

CREATE TABLE Orders
(
    OrderID    VARCHAR2(32) PRIMARY KEY,
    CustomerID VARCHAR2(32)          NOT NULL,
    OrderDate  TIMESTAMP    DEFAULT CURRENT_TIMESTAMP,
    Status     VARCHAR2(20) DEFAULT 'Pending' CHECK (Status
        IN ('Pending', 'Confirmed',
            'Partially Fulfilled', 'Fulfilled', 'Partially Delivered', 'Delivered',
            'Canceled', 'Returned')) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
);

CREATE OR REPLACE TRIGGER set_order_uuid
    BEFORE INSERT
    ON Orders
    FOR EACH ROW
BEGIN
    :NEW.OrderID := Generate_UUID();
END;

CREATE TABLE OrderItems
(
    OrderItemID VARCHAR2(32) PRIMARY KEY,
    OrderID     VARCHAR2(32)                                   NOT NULL,
    ProductID   VARCHAR2(32)                                   NOT NULL,
    Quantity    NUMBER CHECK (Quantity > 0)                    NOT NULL,
    Subtotal    NUMBER(10, 2) CHECK (Subtotal >= 0)            NOT NULL,
    Status      VARCHAR2(20) DEFAULT 'Pending' CHECK (Status
        IN ('Pending', 'Confirmed',
            'Fulfilled', 'Delivered', 'Canceled', 'Returned')) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products (ProductID)
);

CREATE OR REPLACE TRIGGER set_order_item_uuid
    BEFORE INSERT
    ON OrderItems
    FOR EACH ROW
BEGIN
    :NEW.OrderItemID := Generate_UUID();
END;

CREATE TABLE Payments
(
    PaymentID      VARCHAR2(32) PRIMARY KEY,
    OrderItemID    VARCHAR2(32) UNIQUE                                                        NOT NULL,
    CustomerID     VARCHAR2(32)                                                               NOT NULL,
    AmountPaid     NUMBER(10, 2) CHECK (AmountPaid >= 0)                                      NOT NULL,
    PaymentDate    TIMESTAMP    DEFAULT CURRENT_TIMESTAMP,
    TransactionKey VARCHAR2(255)                                                              NOT NULL,
    Status         VARCHAR2(20) DEFAULT 'Accepted' CHECK (Status IN ('Accepted', 'Refunded')) NOT NULL,
    RefundedDate   TIMESTAMP,
    FOREIGN KEY (OrderItemID) REFERENCES OrderItems (OrderItemID),
    FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
);

CREATE OR REPLACE TRIGGER set_payment_uuid
    BEFORE INSERT
    ON Payments
    FOR EACH ROW
BEGIN
    :NEW.PaymentID := Generate_UUID();
END;

CREATE TABLE Deliveries
(
    DeliveryID   VARCHAR2(32) PRIMARY KEY,
    OrderItemID  VARCHAR2(32) UNIQUE NOT NULL,
    SupplierID   VARCHAR2(32)        NOT NULL,
    CustomerID   VARCHAR2(32)        NOT NULL,
    DeliveryDate TIMESTAMP,
    Address      VARCHAR2(500)       NOT NULL,
    FOREIGN KEY (OrderItemID) REFERENCES OrderItems (OrderItemID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers (SupplierID),
    FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
);

CREATE OR REPLACE TRIGGER set_delivery_uuid
    BEFORE INSERT
    ON Deliveries
    FOR EACH ROW
BEGIN
    :NEW.DeliveryID := Generate_UUID();
END;

CREATE MATERIALIZED VIEW TotalSalesPerProduct
            BUILD IMMEDIATE
    REFRESH COMPLETE ON DEMAND
AS
SELECT p.ProductID,
       p.Name           AS ProductName,
       p.SupplierID,
       SUM(oi.Quantity) AS TotalQuantitySold,
       SUM(oi.Subtotal) AS TotalRevenue
FROM OrderItems oi
         JOIN Products p ON oi.ProductID = p.ProductID
WHERE oi.Status = 'Fulfilled'
GROUP BY p.ProductID, p.Name, p.SupplierID;

CREATE MATERIALIZED VIEW SupplierSalesSummary
            BUILD IMMEDIATE
    REFRESH COMPLETE ON DEMAND
AS
SELECT s.SupplierID,
       s.Name                         AS SupplierName,
       COUNT(DISTINCT oi.OrderItemID) AS TotalOrders,
       SUM(oi.Quantity)               AS TotalQuantitySold,
       SUM(oi.Subtotal)               AS TotalRevenue
FROM OrderItems oi
         JOIN Products p ON oi.ProductID = p.ProductID
         JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE oi.Status = 'Fulfilled'
GROUP BY s.SupplierID, s.Name;

CREATE MATERIALIZED VIEW SupplierSalesLast30Days
            BUILD IMMEDIATE
    REFRESH COMPLETE ON DEMAND
AS
SELECT s.SupplierID, s.Name AS SupplierName, TRUNC(oi.OrderID) AS SalesDate, SUM(oi.Subtotal) AS DailyRevenue
FROM OrderItems oi
         JOIN Products p ON oi.ProductID = p.ProductID
         JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE oi.OrderID >= SYSDATE - 30
  AND oi.Status = 'Fulfilled'
GROUP BY s.SupplierID, s.Name, TRUNC(oi.OrderID)
ORDER BY s.SupplierID, SalesDate;
