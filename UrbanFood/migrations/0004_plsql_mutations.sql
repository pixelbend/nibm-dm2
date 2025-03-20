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
    pSupplierID VARCHAR2,
    pName VARCHAR2,
    pDescription VARCHAR2 DEFAULT NULL,
    pPrice NUMBER,
    pStockQuantity NUMBER,
    pCategory VARCHAR2 DEFAULT NULL
) RETURN VARCHAR2 IS
    vProductID     Products.ProductID%TYPE;
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
    WHERE SupplierID = pSupplierID
      AND LOWER(Name) = LOWER(pName);

    IF vProductCount > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'A product with the name "' || pName || '" already exists for the supplier.');
    END IF;

    INSERT INTO Products (ProductID, SupplierID, Name, Description, Price, StockQuantity, Category)
    VALUES (Generate_UUID(), pSupplierID, pName, pDescription, pPrice, pStockQuantity, LOWER(pCategory))
    RETURNING ProductID INTO vProductID;

    RETURN vProductID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Create_Product;

CREATE OR REPLACE FUNCTION Update_Product(
    pSupplierID VARCHAR2,
    pProductID VARCHAR2,
    pName VARCHAR2 DEFAULT NULL,
    pDescription VARCHAR2 DEFAULT NULL,
    pPrice NUMBER DEFAULT NULL,
    pStockQuantity NUMBER DEFAULT NULL,
    pCategory VARCHAR2 DEFAULT NULL
) RETURN VARCHAR2 IS
    vCurrentStock  NUMBER;
    vCurrentPrice  NUMBER;
    vSupplierID    Suppliers.SupplierID%TYPE;
    vValidCategory BOOLEAN := FALSE;
BEGIN
    BEGIN
        SELECT SupplierID, StockQuantity, Price
        INTO vSupplierID, vCurrentStock, vCurrentPrice
        FROM Products
        WHERE ProductID = pProductID
          AND SupplierId = pSupplierID
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
            WHERE SupplierID = pSupplierID
              AND Name = pName
              AND ProductID != pProductID;
            IF vNameExists > 0 THEN
                RAISE_APPLICATION_ERROR(-20001, 'A product with this name already exists for the supplier.');
            END IF;
        END;

        UPDATE Products
        SET Name = pName
        WHERE ProductID = pProductID;
    END IF;

    IF pDescription IS NOT NULL THEN
        UPDATE Products
        SET Description = pDescription
        WHERE ProductID = pProductID;
    END IF;

    IF pPrice IS NOT NULL THEN
        IF pPrice > 0 THEN
            UPDATE Products
            SET Price = pPrice
            WHERE ProductID = pProductID;
        ELSE
            RAISE_APPLICATION_ERROR(-20001, 'Price must be greater than 0.');
        END IF;
    END IF;

    IF pStockQuantity IS NOT NULL THEN
        IF pStockQuantity >= 0 THEN
            UPDATE Products
            SET StockQuantity = pStockQuantity
            WHERE ProductID = pProductID;
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
        WHERE ProductID = pProductID;
    END IF;

    RETURN pProductID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Update_Product;

CREATE OR REPLACE FUNCTION Delete_Product(
    pProductID VARCHAR2,
    pSupplierID VARCHAR2
) RETURN VARCHAR2 AS
    vProductName   VARCHAR2(255);
    vPendingOrders NUMBER;
    vUndelivered   NUMBER;
BEGIN
    BEGIN
        SELECT Name
        INTO vProductName
        FROM Products
        WHERE ProductID = pProductID
          AND SupplierID = pSupplierID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Product not found or unauthorized access.');
    END;

    SELECT COUNT(*)
    INTO vPendingOrders
    FROM OrderItems oi
             JOIN Orders o ON oi.OrderID = o.OrderID
    WHERE oi.ProductID = pProductID
      AND oi.Status IN ('Pending', 'Processing', 'Confirmed');

    SELECT COUNT(*)
    INTO vUndelivered
    FROM Deliveries d
             JOIN OrderItems oi ON d.OrderItemID = oi.OrderItemID
    WHERE oi.ProductID = pProductID
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
    WHERE ProductID = pProductID;

    COMMIT;

    RETURN pProductID;
END Delete_Product;

CREATE OR REPLACE FUNCTION Order_Product(
    pCustomerID VARCHAR2,
    pProductID VARCHAR2,
    pQuantity NUMBER
) RETURN VARCHAR2 IS
    vOrderID        Orders.OrderID%TYPE;
    vOrderItemID    OrderItems.OrderItemID%TYPE;
    vAvailableStock NUMBER;
    vTotalAmount    NUMBER(10, 2);
    vProductPrice   NUMBER(10, 2);
BEGIN
    SELECT StockQuantity, Price
    INTO vAvailableStock, vProductPrice
    FROM Products
    WHERE ProductID = pProductID;

    IF pQuantity > vAvailableStock THEN
        RAISE_APPLICATION_ERROR(-20001, 'Requested quantity exceeds available stock.');
    END IF;

    BEGIN
        SELECT OrderID
        INTO vOrderID
        FROM Orders
        WHERE CustomerID = pCustomerID
          AND Status = 'Pending'
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            vOrderID := NULL;
    END;

    IF vOrderID IS NULL THEN
        INSERT INTO Orders (OrderID, CustomerID, Status)
        VALUES (Generate_UUID(), pCustomerID, 'Pending')
        RETURNING OrderID INTO vOrderID;
    END IF;

    vTotalAmount := pQuantity * vProductPrice;

    BEGIN
        SELECT OrderItemID
        INTO vOrderItemID
        FROM OrderItems
        WHERE OrderID = vOrderID
          AND ProductID = pProductID
          AND Status = 'Pending'
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            vOrderItemID := NULL;
    END;

    IF vOrderItemID IS NOT NULL THEN
        UPDATE OrderItems
        SET Quantity = pQuantity,
            Subtotal = vTotalAmount
        WHERE OrderItemID = vOrderItemID;
    ELSE
        INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Subtotal, Status)
        VALUES (Generate_UUID(), vOrderID, pProductID, pQuantity, vTotalAmount, 'Pending')
        RETURNING OrderItemID INTO vOrderItemID;
    END IF;

    RETURN vOrderItemID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Order_Product;

CREATE OR REPLACE FUNCTION Customer_Remove_OrderItem(
    pCustomerID   VARCHAR2,
    pOrderItemID  VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus      VARCHAR2(20);
    vOrderID          Orders.OrderID%TYPE;
    vProductID        Products.ProductID%TYPE;
    vQuantity         NUMBER;
BEGIN
    BEGIN
        SELECT oi.OrderID, oi.Status, oi.ProductID, oi.Quantity
        INTO vOrderID, vOrderStatus, vProductID, vQuantity
        FROM OrderItems oi
                 JOIN Orders o ON oi.OrderID = o.OrderID
        WHERE oi.OrderItemID = pOrderItemID
          AND o.CustomerID = pCustomerID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Order item does not exist or customer is not authorized to remove this item');
    END;

    IF vOrderStatus = 'Fulfilled' OR vOrderStatus = 'Canceled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item cannot be removed as the order is already confirmed, fulfilled, or canceled.');
    END IF;

    DELETE FROM OrderItems
    WHERE OrderItemID = pOrderItemID;

    UPDATE Products
    SET StockQuantity = StockQuantity + vQuantity
    WHERE ProductID = vProductID;

    DECLARE
        vRemainingItems NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO vRemainingItems
        FROM OrderItems
        WHERE OrderID = vOrderID
          AND Status != 'Fulfilled';

        IF vRemainingItems = 0 THEN
            UPDATE Orders
            SET Status = 'Canceled'
            WHERE OrderID = vOrderID;
        END IF;
    END;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Customer_Remove_OrderItem;

CREATE OR REPLACE FUNCTION Customer_Update_OrderItem_Quantity(
    pCustomerID   VARCHAR2,
    pOrderItemID  VARCHAR2,
    pNewQuantity  NUMBER
) RETURN VARCHAR2 IS
    vOrderStatus      VARCHAR2(20);
    vOrderID          Orders.OrderID%TYPE;
    vProductID        Products.ProductID%TYPE;
    vOldQuantity      NUMBER;
    vAvailableStock   NUMBER;
    vProductPrice     NUMBER(10, 2);
    vTotalAmount      NUMBER(10, 2);
BEGIN
    BEGIN
        SELECT oi.OrderID, oi.Status, oi.ProductID, oi.Quantity
        INTO vOrderID, vOrderStatus, vProductID, vOldQuantity
        FROM OrderItems oi
                 JOIN Orders o ON oi.OrderID = o.OrderID
        WHERE oi.OrderItemID = pOrderItemID
          AND o.CustomerID = pCustomerID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Order item does not exist or customer is not authorized to update this item');
    END;

    IF vOrderStatus = 'Fulfilled' OR vOrderStatus = 'Canceled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item cannot be updated because the order is already confirmed, fulfilled, or canceled.');
    END IF;

    IF pNewQuantity <= 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'Quantity must be greater than 0.');
    END IF;

    BEGIN
        SELECT StockQuantity, Price
        INTO vAvailableStock, vProductPrice
        FROM Products
        WHERE ProductID = vProductID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20003, 'Product does not exist.');
    END;

    IF pNewQuantity > vAvailableStock THEN
        RAISE_APPLICATION_ERROR(-20004, 'Not enough stock available for the requested quantity.');
    END IF;

    vTotalAmount := pNewQuantity * vProductPrice;

    UPDATE OrderItems
    SET Quantity = pNewQuantity,
        Subtotal = vTotalAmount
    WHERE OrderItemID = pOrderItemID;


    RETURN pOrderItemID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Customer_Update_OrderItem_Quantity;

CREATE OR REPLACE FUNCTION Checkout_Order(
    pCustomerID VARCHAR2,
    pOrderID VARCHAR2,
    pTransactionKey VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus   VARCHAR2(20);
    vOrderID       Orders.OrderID%TYPE;
    vCustomerID    Customers.CustomerID%TYPE;
    vStockQuantity NUMBER;
    vProductPrice  NUMBER(10, 2);
    vTotalAmount   NUMBER(10, 2) := 0;
BEGIN
    BEGIN
        SELECT OrderID, Status, CustomerID
        INTO vOrderID, vOrderStatus, vCustomerID
        FROM Orders
        WHERE OrderID = pOrderID
          AND CustomerId = pCustomerID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Order does not exist for the specified customer');
    END;

    IF vOrderStatus <> 'Pending' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order cannot be confirmed. Current status: ' || vOrderStatus);
    END IF;

    FOR orderItem IN (
        SELECT OrderItemID, ProductID, Quantity
        FROM OrderItems
        WHERE OrderID = vOrderID
          AND Status = 'Pending'
        )
        LOOP
            BEGIN
                SELECT StockQuantity, Price
                INTO vStockQuantity, vProductPrice
                FROM Products
                WHERE ProductID = orderItem.ProductID
                    FOR UPDATE;
            EXCEPTION
                WHEN NO_DATA_FOUND THEN
                    RAISE_APPLICATION_ERROR(-20001, 'Product does not exist');
            END;

            IF vStockQuantity < orderItem.Quantity THEN
                RAISE_APPLICATION_ERROR(-20001, 'Not enough stock available for product ' || orderItem.ProductID);
            END IF;

            vTotalAmount := orderItem.Quantity * vProductPrice;

            UPDATE Products
            SET StockQuantity = StockQuantity - orderItem.Quantity
            WHERE ProductID = orderItem.ProductID;

            UPDATE OrderItems
            SET Status   = 'Confirmed',
                Subtotal = vTotalAmount
            WHERE OrderItemID = orderItem.OrderItemID;

            INSERT INTO Payments (PaymentID, OrderItemID, CustomerID, AmountPaid, TransactionKey, Status)
            VALUES (Generate_UUID(), orderItem.OrderItemID, vCustomerID, vTotalAmount, pTransactionKey, 'Accepted');
        END LOOP;

    UPDATE Orders
    SET Status = 'Confirmed'
    WHERE OrderID = vOrderID;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Checkout_Order;

CREATE OR REPLACE FUNCTION Customer_Cancel_Order(
    pCustomerID VARCHAR2,
    pOrderID VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus VARCHAR2(20);
    vOrderID     Orders.OrderID%TYPE;
BEGIN
    BEGIN
        SELECT OrderID, Status
        INTO vOrderID, vOrderStatus
        FROM Orders
        WHERE CustomerID = pCustomerID
          AND OrderID = pOrderID
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
    WHERE OrderID = pOrderID;

    UPDATE OrderItems
    SET Status = 'Canceled'
    WHERE OrderID = pOrderID;

    UPDATE Payments
    SET Status = 'Refunded'
    WHERE OrderItemID IN (SELECT OrderItemID FROM OrderItems WHERE OrderID = pOrderID);

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Customer_Cancel_Order;

CREATE OR REPLACE FUNCTION Supplier_Cancel_OrderItem(
    pSupplierID VARCHAR2,
    pOrderItemID VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus VARCHAR2(20);
    vOrderID     Orders.OrderID%TYPE;
    vProductID   Products.ProductID%TYPE;
    vQuantity    NUMBER;
    vPaymentID   Payments.PaymentID%TYPE;
BEGIN
    BEGIN
        SELECT oi.OrderID, oi.Status, oi.ProductID, oi.Quantity, p.PaymentID
        INTO vOrderID, vOrderStatus, vProductID, vQuantity, vPaymentID
        FROM OrderItems oi
                 JOIN Orders o ON oi.OrderID = o.OrderID
                 JOIN Products pr ON oi.ProductID = pr.ProductID
                 JOIN Payments p ON oi.OrderItemID = p.OrderItemID
        WHERE oi.OrderItemID = pOrderItemID
          AND pr.SupplierID = pSupplierID
          AND oi.Status != 'Canceled'
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Order item does not exist or supplier is not authorized to cancel this order item');
    END;

    IF vOrderStatus = 'Fulfilled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is already fulfilled and cannot be canceled');
    END IF;

    UPDATE OrderItems
    SET Status = 'Canceled'
    WHERE OrderItemID = pOrderItemID;

    UPDATE Products
    SET StockQuantity = StockQuantity + vQuantity
    WHERE ProductID = vProductID;

    UPDATE Payments
    SET Status       = 'Refunded',
        RefundedDate = CURRENT_TIMESTAMP
    WHERE PaymentID = vPaymentID;

    DECLARE
        vRemainingItems NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO vRemainingItems
        FROM OrderItems
        WHERE OrderID = vOrderID
          AND Status != 'Canceled';

        IF vRemainingItems = 0 THEN
            UPDATE Orders
            SET Status = 'Canceled'
            WHERE OrderID = vOrderID;
        END IF;
    END;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Supplier_Cancel_OrderItem;

CREATE OR REPLACE FUNCTION Supplier_Fulfill_OrderItem(
    pSupplierID VARCHAR2,
    pOrderItemID VARCHAR2
) RETURN VARCHAR2 IS
    vOrderID         Orders.OrderID%TYPE;
    vProductID       Products.ProductID%TYPE;
    vOrderItemStatus VARCHAR2(20);
BEGIN
    BEGIN
        SELECT oi.OrderID, oi.Status, oi.ProductID
        INTO vOrderID, vOrderItemStatus, vProductID
        FROM OrderItems oi
                 JOIN Orders o ON oi.OrderID = o.OrderID
                 JOIN Products pr ON oi.ProductID = pr.ProductID
        WHERE oi.OrderItemID = pOrderItemID
          AND pr.SupplierID = pSupplierID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Order item does not exist or supplier is not authorized to fulfill this item');
    END;

    IF vOrderItemStatus = 'Fulfilled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is already fulfilled and cannot be changed.');
    END IF;

    IF vOrderItemStatus != 'Pending' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is not in a valid state (Pending) to be fulfilled.');
    END IF;

    UPDATE OrderItems
    SET Status = 'Fulfilled'
    WHERE OrderItemID = pOrderItemID;

    DECLARE
        vRemainingItems NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO vRemainingItems
        FROM OrderItems
        WHERE OrderID = vOrderID
          AND Status != 'Fulfilled';

        IF vRemainingItems = 0 THEN
            UPDATE Orders
            SET Status = 'Fulfilled'
            WHERE OrderID = vOrderID;
        END IF;
    END;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END Supplier_Fulfill_OrderItem;