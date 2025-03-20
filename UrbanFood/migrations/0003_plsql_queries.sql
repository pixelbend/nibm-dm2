CREATE OR REPLACE FUNCTION Get_Product_By_ID(
    pProductID Products.ProductID%TYPE
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT * FROM Products WHERE ProductID = pProductID;

    RETURN vCursor;
END Get_Product_By_ID;

CREATE OR REPLACE FUNCTION List_Inventory_Products(
    pSupplierID VARCHAR2,
    pCategory VARCHAR2 DEFAULT NULL,
    pName VARCHAR2 DEFAULT NULL,
    pStockAvailable NUMBER DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT *
        FROM Products
        WHERE SupplierID = pSupplierID
          AND (pCategory IS NULL OR LOWER(Category) = LOWER(pCategory))
          AND (pName IS NULL OR LOWER(Name) LIKE '%' || LOWER(pName) || '%')
          AND (pStockAvailable IS NULL OR (pStockAvailable = 1 AND StockQuantity > 0) OR
               (pStockAvailable = 0 AND StockQuantity = 0))
          AND Discontinued = 0
        ORDER BY AddedAt DESC;

    RETURN vCursor;
END List_Inventory_Products;

CREATE OR REPLACE FUNCTION List_Products(
    pCategory VARCHAR2 DEFAULT NULL,
    pName VARCHAR2 DEFAULT NULL,
    pStockAvailable NUMBER DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT *
        FROM Products
        WHERE (pCategory IS NULL OR LOWER(Category) = LOWER(pCategory))
          AND (pName IS NULL OR LOWER(Name) LIKE '%' || LOWER(pName) || '%')
          AND (pStockAvailable IS NULL OR (pStockAvailable = 1 AND StockQuantity > 0))
          AND Discontinued = 0
        ORDER BY AddedAt DESC;

    RETURN vCursor;
END List_Products;

CREATE OR REPLACE FUNCTION Get_Pending_Orders_By_Customer(
    pCustomerID VARCHAR2
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT o.OrderID        AS OrderID,
               o.Status         AS Status,
               o.OrderDate      AS OrderDate,
               SUM(oi.Subtotal) AS OrderTotal
        FROM Orders o
                 JOIN OrderItems oi ON o.OrderID = oi.OrderID
        WHERE o.CustomerID = pCustomerID
          AND o.Status = 'Pending'
        GROUP BY o.OrderID, o.Status, o.OrderDate;

    RETURN vCursor;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Get_Pending_Orders_By_Customer;

CREATE OR REPLACE FUNCTION List_OrderItems_By_Order(
    pOrderID VARCHAR2,
    pStatus VARCHAR2 DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT oi.OrderItemID  AS OrderItemID,
               oi.OrderID      AS OrderID,
               oi.ProductID    AS ProductID,
               p.Name          AS Name,
               p.Description   AS Description,
               p.Category      AS Category,
               p.Price         AS Price,
               p.StockQuantity AS StockQuantity,
               oi.Quantity     AS Quantity,
               oi.Subtotal     AS Total,
               oi.Status       AS Status,
               o.OrderDate     AS OrderDate
        FROM OrderItems oi
                 JOIN Orders o ON oi.OrderID = o.OrderID
                 JOIN Products p ON oi.ProductID = p.ProductID
        WHERE o.OrderID = pOrderID
          AND (pStatus IS NULL OR oi.Status = pStatus);

    RETURN vCursor;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END List_OrderItems_By_Order;

CREATE OR REPLACE FUNCTION List_OrderItems_By_Supplier(
    pSupplierID VARCHAR2,
    pStatus VARCHAR2 DEFAULT NULL,
    pProductName VARCHAR2 DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT oi.OrderItemID  AS OrderItemID,
               oi.OrderID      AS OrderID,
               o.CustomerID    AS CustomerID,
               oi.ProductID    AS ProductID,
               p.Name          AS Name,
               p.Description   AS Description,
               p.Category      AS Category,
               p.Price         AS Price,
               p.StockQuantity AS StockQuantity,
               oi.Quantity     AS Quantity,
               oi.Subtotal     AS Total,
               oi.Status       AS OrderStatus,
               o.OrderDate     AS OrderDate
        FROM OrderItems oi
                 JOIN Orders o ON oi.OrderID = o.OrderID
                 JOIN Products p ON oi.ProductID = p.ProductID
        WHERE p.SupplierID = pSupplierID
          AND (pStatus IS NULL OR oi.Status = pStatus)
          AND (pProductName IS NULL OR p.Name = pProductName);

    RETURN vCursor;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END List_OrderItems_By_Supplier;

CREATE OR REPLACE FUNCTION List_Order_History_By_Customer(
    pCustomerID VARCHAR2
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT o.OrderID,
               o.OrderDate,
               o.Status,
               COALESCE(SUM(CASE WHEN oi.Status != 'Canceled' THEN oi.Subtotal ELSE 0 END), 0) AS TotalAmount
        FROM Orders o
                 LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
        WHERE o.CustomerID = pCustomerID
          AND o.Status != 'Pending'
        GROUP BY o.OrderID, o.OrderDate, o.Status
        ORDER BY o.OrderDate DESC;

    RETURN vCursor;
END List_Order_History_By_Customer;
