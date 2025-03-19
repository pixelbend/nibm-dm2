CREATE OR REPLACE FUNCTION Signup_Supplier(
    pName IN VARCHAR2,
    pEmail IN VARCHAR2,
    pHashedPassword IN VARCHAR2,
    pPhone IN VARCHAR2,
    pAddress IN VARCHAR2
) RETURN VARCHAR2 IS
    vCount      NUMBER;
    vSupplierID Suppliers.SupplierID%TYPE;
BEGIN
    SELECT COUNT(*)
    INTO vCount
    FROM Suppliers
    WHERE Name = pName
       OR LOWER(Email) = LOWER(pEmail)
       OR Phone = pPhone;

    IF vCount > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'A supplier with the same Name, Email, or Phone already exists.');
    END IF;

    INSERT INTO Suppliers (SupplierID, Name, Email, Password, Phone, Address)
    VALUES (GENERATE_UUID(), pName, LOWER(pEmail), pHashedPassword, pPhone, pAddress)
    RETURNING SupplierID INTO vSupplierID;

    RETURN vSupplierID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Signup_Supplier;

CREATE OR REPLACE FUNCTION Signup_Customer(
    pName IN VARCHAR2,
    pEmail IN VARCHAR2,
    pHashedPassword IN VARCHAR2,
    pPhone IN VARCHAR2,
    pAddress IN VARCHAR2
) RETURN VARCHAR2 IS
    vCount      NUMBER;
    vCustomerID Customers.CustomerID%TYPE;
BEGIN
    SELECT COUNT(*)
    INTO vCount
    FROM Customers
    WHERE LOWER(Email) = LOWER(pEmail)
       OR Phone = pPhone;

    IF vCount > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'A customer with the same Email or Phone already exists.');
    END IF;

    INSERT INTO Customers (CustomerID, Name, Email, Password, Phone, Address)
    VALUES (GENERATE_UUID(), pName, LOWER(pEmail), pHashedPassword, pPhone, pAddress)
    RETURNING CustomerID INTO vCustomerID;

    RETURN vCustomerID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Signup_Customer;

CREATE OR REPLACE PROCEDURE Login_Supplier(
    pEmail IN VARCHAR2,
    pSupplierID OUT VARCHAR2,
    pPassword OUT VARCHAR2
)
    IS
BEGIN
    SELECT SupplierID, Password
    INTO pSupplierID, pPassword
    FROM Suppliers
    WHERE LOWER(Email) = LOWER(pEmail);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-20001, 'Supplier with the provided email does not exist.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20000, 'Database Error: ' || SQLERRM);
END Login_Supplier;

CREATE OR REPLACE PROCEDURE Login_Customer(
    pEmail IN VARCHAR2,
    pCustomerID OUT VARCHAR2,
    pPassword OUT VARCHAR2
)
    IS
BEGIN
    SELECT CustomerID, Password
    INTO pCustomerID, pPassword
    FROM Customers
    WHERE LOWER(Email) = LOWER(pEmail);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-20001, 'Customer with the provided email does not exist.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20000, 'Database Error: ' || SQLERRM);
END Login_Customer;

CREATE OR REPLACE FUNCTION Create_Product(
    pSupplierId VARCHAR2,
    pName VARCHAR2,
    pDescription VARCHAR2 DEFAULT NULL,
    pPrice NUMBER,
    pStockQuantity NUMBER,
    pCategory VARCHAR2 DEFAULT NULL
) RETURN VARCHAR2 IS
    vProductId     Products.ProductID%TYPE;
    vValidCategory BOOLEAN := FALSE;
    vProductCount  NUMBER;
BEGIN
    IF pCategory IS NOT NULL THEN
        IF LOWER(pCategory) IN ('vegetables', 'fruits', 'dairy products', 'baked goods', 'handmade crafts') THEN
            vValidCategory := TRUE;
        END IF;
    ELSE
        vValidCategory := TRUE;
    END IF;

    IF NOT vValidCategory THEN
        RAISE_APPLICATION_ERROR(-20001,
                                'Invalid category. Allowed values: vegetables, fruits, dairy products, baked goods, handmade crafts.');
    END IF;

    SELECT COUNT(*)
    INTO vProductCount
    FROM Products
    WHERE SupplierID = pSupplierId
      AND LOWER(Name) = LOWER(pName);

    IF vProductCount > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'A product with the name "' || pName || '" already exists for the supplier.');
    END IF;

    INSERT INTO Products (ProductID, SupplierID, Name, Description, Price, StockQuantity, Category)
    VALUES (Generate_UUID(), pSupplierId, pName, pDescription, pPrice, pStockQuantity, LOWER(pCategory))
    RETURNING ProductID INTO vProductId;

    RETURN vProductId;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Create_Product;

CREATE OR REPLACE FUNCTION Update_Product(
    pSupplierId VARCHAR2,
    pProductId VARCHAR2,
    pName VARCHAR2 DEFAULT NULL,
    pDescription VARCHAR2 DEFAULT NULL,
    pPrice NUMBER DEFAULT NULL,
    pStockQuantity NUMBER DEFAULT NULL,
    pCategory VARCHAR2 DEFAULT NULL
) RETURN VARCHAR2 IS
    vCurrentStock  NUMBER;
    vCurrentPrice  NUMBER;
    vSupplierId    Suppliers.SupplierID%TYPE;
    vValidCategory BOOLEAN := FALSE;
BEGIN
    BEGIN
        SELECT SupplierID, StockQuantity, Price
        INTO vSupplierId, vCurrentStock, vCurrentPrice
        FROM Products
        WHERE ProductID = pProductId
          AND SupplierId = pSupplierId
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Product with the given ID does not exist.');
    END;

    IF pName IS NOT NULL THEN
        DECLARE
            vNameExists NUMBER;
        BEGIN
            SELECT COUNT(*)
            INTO vNameExists
            FROM Products
            WHERE SupplierID = pSupplierId
              AND Name = pName
              AND ProductID != pProductId;
            IF vNameExists > 0 THEN
                RAISE_APPLICATION_ERROR(-20001, 'A product with this name already exists for the supplier.');
            END IF;
        END;

        UPDATE Products
        SET Name = pName
        WHERE ProductID = pProductId;
    END IF;

    IF pDescription IS NOT NULL THEN
        UPDATE Products
        SET Description = pDescription
        WHERE ProductID = pProductId;
    END IF;

    IF pPrice IS NOT NULL THEN
        IF pPrice > 0 THEN
            UPDATE Products
            SET Price = pPrice
            WHERE ProductID = pProductId;
        ELSE
            RAISE_APPLICATION_ERROR(-20001, 'Price must be greater than 0.');
        END IF;
    END IF;

    IF pStockQuantity IS NOT NULL THEN
        IF pStockQuantity >= 0 THEN
            UPDATE Products
            SET StockQuantity = pStockQuantity
            WHERE ProductID = pProductId;
        ELSE
            RAISE_APPLICATION_ERROR(-20001, 'Stock quantity cannot be negative.');
        END IF;
    END IF;

    IF pCategory IS NOT NULL THEN
        IF LOWER(pCategory) IN ('vegetables', 'fruits', 'dairy products', 'baked goods', 'handmade crafts') THEN
            vValidCategory := TRUE;
        ELSE
            vValidCategory := FALSE;
        END IF;

        IF NOT vValidCategory THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Invalid category. Allowed values: vegetables, fruits, dairy products, baked goods, handmade crafts.');
        END IF;

        UPDATE Products
        SET Category = LOWER(pCategory)
        WHERE ProductID = pProductId;
    END IF;

    RETURN pProductId;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Update_Product;

CREATE OR REPLACE FUNCTION Delete_Product(
    pProductId VARCHAR2,
    pSupplierId VARCHAR2
) RETURN VARCHAR2 AS
    vProductName   VARCHAR2(255);
    vPendingOrders NUMBER;
    vUndelivered   NUMBER;
BEGIN
    BEGIN
        SELECT Name
        INTO vProductName
        FROM Products
        WHERE ProductID = pProductId
          AND SupplierID = pSupplierId
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Product not found or unauthorized access.');
    END;

    SELECT COUNT(*)
    INTO vPendingOrders
    FROM Orders
    WHERE ProductID = pProductId
      AND Status IN ('Pending', 'Processing', 'Confirmed');

    SELECT COUNT(*)
    INTO vUndelivered
    FROM Deliveries d
             JOIN Orders o ON d.OrderID = o.OrderID
    WHERE o.ProductID = pProductId
      AND d.Status != 'Delivered';

    IF vPendingOrders > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Cannot delete: There are unfulfilled orders.');
    END IF;

    IF vUndelivered > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Cannot delete: Some deliveries are not completed.');
    END IF;

    UPDATE Products
    SET Name         = Name || '_ARCHIVED_' || TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS'),
        Discontinued = 1
    WHERE ProductID = pProductId;

    COMMIT;

    RETURN pProductId;
END Delete_Product;

CREATE OR REPLACE FUNCTION Order_Product(
    pCustomerId VARCHAR2,
    pProductId VARCHAR2,
    pQuantity NUMBER
) RETURN VARCHAR2 IS
    vOrderId        Orders.OrderID%TYPE;
    vAvailableStock NUMBER;
    vTotalAmount    NUMBER(10, 2);
    vProductPrice   NUMBER(10, 2);
BEGIN
    SELECT StockQuantity, Price
    INTO vAvailableStock, vProductPrice
    FROM Products
    WHERE ProductID = pProductId;

    IF pQuantity > vAvailableStock THEN
        RAISE_APPLICATION_ERROR(-20001, 'Requested quantity exceeds available stock.');
    END IF;

    BEGIN
        SELECT OrderID
        INTO vOrderId
        FROM Orders
        WHERE CustomerID = pCustomerId
          AND ProductID = pProductId
          AND Status = 'Pending'
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            vOrderId := NULL;
    END;

    vTotalAmount := pQuantity * vProductPrice;

    IF vOrderId IS NOT NULL THEN
        UPDATE Orders
        SET Quantity = pQuantity,
            Total    = vTotalAmount
        WHERE OrderID = vOrderId;
    ELSE
        vOrderId := Generate_UUID();
        INSERT INTO Orders (OrderID, CustomerID, ProductID, Quantity, Total, Status)
        VALUES (vOrderId, pCustomerId, pProductId, pQuantity, vTotalAmount, 'Pending');
    END IF;

    RETURN vOrderId;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Order_Product;

CREATE OR REPLACE FUNCTION Checkout_Order(
    pCustomerId VARCHAR2,
    pOrderId VARCHAR2,
    pTransactionKey VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus   VARCHAR2(20);
    vOrderID       Orders.OrderID%TYPE;
    vProductID     Products.ProductID%TYPE;
    vCustomerID    Customers.CustomerID%TYPE;
    vQuantity      NUMBER;
    vStockQuantity NUMBER;
    vProductPrice  NUMBER(10, 2);
    vTotalAmount   NUMBER(10, 2);
    vPaymentID     Payments.PaymentID%TYPE;
BEGIN
    BEGIN
        SELECT OrderID, Status, ProductID, Quantity, CustomerID
        INTO vOrderID, vOrderStatus, vProductID, vQuantity, vCustomerID
        FROM Orders
        WHERE OrderID = pOrderId
          AND CustomerId = pCustomerId
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Order does not exist for the specified customer');
    END;

    IF vOrderStatus <> 'Pending' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order cannot be confirmed. Current status: ' || vOrderStatus);
    END IF;

    BEGIN
        SELECT StockQuantity, Price
        INTO vStockQuantity, vProductPrice
        FROM Products
        WHERE ProductID = vProductID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Product does not exist');
    END;

    IF vStockQuantity < vQuantity THEN
        RAISE_APPLICATION_ERROR(-20001, 'Not enough stock available');
    END IF;

    vTotalAmount := vQuantity * vProductPrice;

    UPDATE Products
    SET StockQuantity = StockQuantity - vQuantity
    WHERE ProductID = vProductID;

    UPDATE Orders
    SET Status = 'Confirmed',
        Total  = vTotalAmount
    WHERE OrderID = vOrderID;


    vPaymentID := Generate_UUID();
    INSERT INTO Payments (PaymentID, OrderID, CustomerID, AmountPaid, TransactionKey, Status)
    VALUES (vPaymentID, vOrderID, vCustomerID, vTotalAmount, pTransactionKey, 'Accepted');

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Checkout_Order;

CREATE OR REPLACE FUNCTION Customer_Cancel_Order(
    pCustomerId VARCHAR2,
    pOrderId VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus VARCHAR2(20);
    vOrderID     Orders.OrderID%TYPE;
BEGIN
    BEGIN
        SELECT OrderID, Status
        INTO vOrderID, vOrderStatus
        FROM Orders
        WHERE CustomerID = pCustomerId
          AND OrderID = pOrderId
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Order does not exist');
    END;

    IF vOrderStatus = 'Canceled' THEN
        RAISE_APPLICATION_ERROR(-20002, 'Order is already canceled');
    END IF;

    UPDATE Orders
    SET Status = 'Canceled'
    WHERE OrderID = pOrderId;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Customer_Cancel_Order;

CREATE OR REPLACE FUNCTION Supplier_Cancel_Order(
    pSupplierId VARCHAR2,
    pOrderId VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus VARCHAR2(20);
    vOrderID     Orders.OrderID%TYPE;
    vProductID   Products.ProductID%TYPE;
    vQuantity    NUMBER;
BEGIN
    BEGIN
        SELECT o.OrderID, o.Status, o.ProductID, o.Quantity
        INTO vOrderID, vOrderStatus, vProductID, vQuantity
        FROM Orders o
                 JOIN Products pr ON o.ProductID = pr.ProductID
                 JOIN Payments p ON o.OrderID = p.OrderID
        WHERE o.OrderID = pOrderId
          AND pr.SupplierID = pSupplierId
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Order does not exist or supplier is not authorized to cancel this order');
    END;

    IF vOrderStatus = 'Fulfilled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order is already fulfilled and cannot be canceled');
    END IF;

    UPDATE Orders
    SET Status = 'Canceled'
    WHERE OrderID = pOrderId;

    UPDATE Products
    SET StockQuantity = StockQuantity + vQuantity
    WHERE ProductID = vProductID;

    UPDATE Payments
    SET Status       = 'Refunded',
        RefundedData = CURRENT_TIMESTAMP
    WHERE OrderID = pOrderId;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Supplier_Cancel_Order;

CREATE OR REPLACE FUNCTION Supplier_Fulfill_Order(
    pSupplierId VARCHAR2,
    pOrderId VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus VARCHAR2(20);
    vOrderID     Orders.OrderID%TYPE;
    vProductID   Products.ProductID%TYPE;
BEGIN
    BEGIN
        SELECT o.OrderID, o.Status, o.ProductID
        INTO vOrderID, vOrderStatus, vProductID
        FROM Orders o
                 JOIN Products pr ON o.ProductID = pr.ProductID
        WHERE o.OrderID = pOrderId
          AND pr.SupplierID = pSupplierId
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Order does not exist or supplier is not authorized to update this order');
    END;

    IF vOrderStatus = 'Fulfilled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order is already Fulfilled and cannot be changed.');
    END IF;

    IF vOrderStatus != 'Pending' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order is not in a valid state (Pending) to be fulfilled.');
    END IF;

    UPDATE Orders
    SET Status = 'Fulfilled'
    WHERE OrderID = pOrderId;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Supplier_Fulfill_Order;
