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

    COMMIT;

    RETURN vSupplierID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
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

    COMMIT;

    RETURN vCustomerID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
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

    COMMIT;

    RETURN vProductID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
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

    COMMIT;

    RETURN pProductID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Update_Product;

CREATE OR REPLACE FUNCTION Delete_Product(
    pProductID VARCHAR2,
    pSupplierID VARCHAR2
) RETURN VARCHAR2 AS
    vProductName   VARCHAR2(255);
    vPendingOrders NUMBER;
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
      AND o.Status IN ('Pending', 'Confirmed', 'Partially Fulfilled')
      AND oi.Status IN ('Pending', 'Confirmed');

    IF vPendingOrders > 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'Cannot delete: There are active unfulfilled orders.');
    END IF;

    UPDATE Products
    SET Name         = Name || '_ARCHIVED_' || TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS'),
        Discontinued = 1
    WHERE ProductID = pProductID
      AND SupplierID = pSupplierID;

    COMMIT;

    RETURN pProductID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
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

    COMMIT;

    RETURN vOrderItemID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Order_Product;

CREATE OR REPLACE FUNCTION Customer_Remove_OrderItem(
    pCustomerID VARCHAR2,
    pOrderItemID VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus VARCHAR2(20);
    vOrderID     Orders.OrderID%TYPE;
    vProductID   Products.ProductID%TYPE;
    vQuantity    NUMBER;
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
            RAISE_APPLICATION_ERROR(-20001,
                                    'Order item does not exist or customer is not authorized to remove this item');
    END;

    IF vOrderStatus = 'Fulfilled' OR vOrderStatus = 'Canceled' THEN
        RAISE_APPLICATION_ERROR(-20001,
                                'Order item cannot be removed as the order is already confirmed, fulfilled, or canceled.');
    END IF;

    UPDATE OrderItems
    SET Status = 'Canceled'
    WHERE OrderItemID = pOrderItemID;

    DECLARE
        vTotalItems    NUMBER;
        vCanceledItems NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO vTotalItems
        FROM OrderItems
        WHERE OrderID = vOrderID;

        SELECT COUNT(*)
        INTO vCanceledItems
        FROM OrderItems
        WHERE OrderID = vOrderID
          AND Status = 'Canceled';

        IF vTotalItems = vCanceledItems AND vTotalItems > 0 THEN
            UPDATE Orders
            SET Status = 'Canceled'
            WHERE OrderID = vOrderID;
        END IF;
    END;

    COMMIT;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Customer_Remove_OrderItem;

CREATE OR REPLACE FUNCTION Checkout_Order(
    pCustomerID VARCHAR2,
    pOrderID VARCHAR2,
    pTransactionKey VARCHAR2
) RETURN VARCHAR2 IS
    vOrderStatus   VARCHAR2(20);
    vOrderID       Orders.OrderID%TYPE;
    vCustomerID    Customers.CustomerID%TYPE;

    TYPE OrderItemRecord IS RECORD (
        OrderItemID OrderItems.OrderItemID%TYPE,
        ProductID   Products.ProductID%TYPE,
        Quantity    OrderItems.Quantity%TYPE,
        ProductName Products.Name%TYPE,
        ProductPrice Products.Price%TYPE,
        StockQuantity Products.StockQuantity%TYPE
    );

    TYPE OrderItemTable IS TABLE OF OrderItemRecord;
    vOrderItems OrderItemTable;
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

    SELECT oi.OrderItemID, oi.ProductID, oi.Quantity, p.Name, p.Price, p.StockQuantity
    BULK COLLECT INTO vOrderItems
    FROM OrderItems oi
    JOIN Products p ON oi.ProductID = p.ProductID
    WHERE oi.OrderID = vOrderID
      AND oi.Status = 'Pending'
    FOR UPDATE OF p.StockQuantity;

    FOR i IN 1 .. vOrderItems.COUNT LOOP
        IF vOrderItems(i).StockQuantity < vOrderItems(i).Quantity THEN
            RAISE_APPLICATION_ERROR(-20001, 'Not enough stock available for product ' || vOrderItems(i).ProductName
                || '. Please remove the product and checkout again.');
        END IF;
    END LOOP;

    FOR i IN 1 .. vOrderItems.COUNT LOOP
        UPDATE Products
        SET StockQuantity = StockQuantity - vOrderItems(i).Quantity
        WHERE ProductID = vOrderItems(i).ProductID;

        UPDATE OrderItems
        SET Status = 'Confirmed',
            Subtotal = vOrderItems(i).Quantity * vOrderItems(i).ProductPrice
        WHERE OrderItemID = vOrderItems(i).OrderItemID;

        INSERT INTO Payments (PaymentID, OrderItemID, CustomerID, AmountPaid, TransactionKey, Status)
        VALUES (Generate_UUID(), vOrderItems(i).OrderItemID, vCustomerID, vOrderItems(i).Quantity * vOrderItems(i).ProductPrice, pTransactionKey, 'Accepted');
    END LOOP;

    UPDATE Orders
    SET Status = 'Confirmed'
    WHERE OrderID = vOrderID;

    COMMIT;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
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

    COMMIT;

    RETURN vOrderID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Customer_Cancel_Order;

CREATE OR REPLACE FUNCTION Supplier_Cancel_OrderItem(
    pSupplierID VARCHAR2,
    pOrderItemID VARCHAR2
) RETURN VARCHAR2 IS
    vOrderItemStatus VARCHAR2(20);
    vOrderID         Orders.OrderID%TYPE;
    vOrderItemID     OrderItems.OrderItemID%TYPE;
    vProductID       Products.ProductID%TYPE;
    vQuantity        NUMBER;
    vPaymentID       Payments.PaymentID%TYPE;
BEGIN
    BEGIN
        SELECT oi.OrderItemID, oi.OrderID, oi.Status, oi.ProductID, oi.Quantity, p.PaymentID
        INTO vOrderItemID, vOrderID, vOrderItemStatus, vProductID, vQuantity, vPaymentID
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

    IF vOrderItemStatus = 'Fulfilled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is already Fulfilled and cannot be canceled');
    ELSIF vOrderItemStatus = 'Delivered' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is already Delivered and cannot be canceled');
    END IF;

    UPDATE OrderItems
    SET Status = 'Canceled'
    WHERE OrderItemID = vOrderItemID;

    UPDATE Products
    SET StockQuantity = StockQuantity + vQuantity
    WHERE ProductID = vProductID;

    UPDATE Payments
    SET Status       = 'Refunded',
        RefundedDate = CURRENT_TIMESTAMP
    WHERE PaymentID = vPaymentID;

    DECLARE
        vTotalItems    NUMBER;
        vCanceledItems NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO vTotalItems
        FROM OrderItems
        WHERE OrderID = vOrderID;

        SELECT COUNT(*)
        INTO vCanceledItems
        FROM OrderItems
        WHERE OrderID = vOrderID
          AND Status = 'Canceled';

        IF vTotalItems = vCanceledItems AND vTotalItems > 0 THEN
            UPDATE Orders
            SET Status = 'Canceled'
            WHERE OrderID = vOrderID;
        END IF;
    END;

    COMMIT;

    RETURN vOrderItemID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Supplier_Cancel_OrderItem;

CREATE OR REPLACE FUNCTION Supplier_Fulfill_OrderItem(
    pSupplierID VARCHAR2,
    pOrderItemID VARCHAR2
) RETURN VARCHAR2 IS
    vOrderID         Orders.OrderID%TYPE;
    vOrderItemID     OrderItems.OrderItemID%TYPE;
    vProductID       Products.ProductID%TYPE;
    vOrderItemStatus VARCHAR2(20);
BEGIN
    BEGIN
        SELECT oi.OrderItemID, oi.OrderID, oi.Status, oi.ProductID
        INTO vOrderItemID, vOrderID, vOrderItemStatus, vProductID
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
        RAISE_APPLICATION_ERROR(-20001, 'Order item is already Fulfilled and cannot be changed.');
    ELSIF vOrderItemStatus != 'Confirmed' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is not in a valid state (Pending) to be Fulfilled.');
    END IF;

    UPDATE OrderItems
    SET Status = 'Fulfilled'
    WHERE OrderItemID = vOrderItemID;

    DECLARE
        vFulfilledItems NUMBER;
    BEGIN
        SELECT SUM(CASE WHEN Status = 'Fulfilled' THEN 1 ELSE 0 END)
        INTO vFulfilledItems
        FROM OrderItems
        WHERE OrderID = vOrderID;

        IF vFulfilledItems > 0 THEN
            UPDATE Orders
            SET Status = 'Partially Fulfilled'
            WHERE OrderID = vOrderID;
        END IF;
    END;

    COMMIT;

    RETURN vOrderItemID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Supplier_Fulfill_OrderItem;

CREATE OR REPLACE FUNCTION Supplier_Deliver_OrderItem(
    pSupplierID VARCHAR2,
    pOrderItemID VARCHAR2
) RETURN VARCHAR2 IS
    vOrderID         Orders.OrderID%TYPE;
    vOrderItemID     OrderItems.OrderItemID%TYPE;
    vProductID       Products.ProductID%TYPE;
    vCustomerID      Customers.CustomerID%TYPE;
    vAddress         Customers.Address%TYPE;
    vOrderItemStatus VARCHAR2(20);
    vDeliveryID      Deliveries.DeliveryID%TYPE;
BEGIN
    BEGIN
        SELECT oi.OrderItemID, oi.OrderID, oi.Status, oi.ProductID, o.CustomerID, c.Address
        INTO vOrderItemID, vOrderID, vOrderItemStatus, vProductID, vCustomerID, vAddress
        FROM OrderItems oi
                 JOIN Orders o ON oi.OrderID = o.OrderID
                 JOIN Products pr ON oi.ProductID = pr.ProductID
                 JOIN Customers c ON o.CustomerID = c.CustomerID
        WHERE oi.OrderItemID = pOrderItemID
          AND pr.SupplierID = pSupplierID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Order item does not exist or supplier is not authorized to fulfill this item');
    END;

    IF vOrderItemStatus = 'Delivered' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is already Delivered and cannot be changed.');
    ELSIF vOrderItemStatus != 'Fulfilled' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Order item is not in a valid state (Fulfilled) to be Delivered.');
    END IF;

    UPDATE OrderItems
    SET Status = 'Delivered'
    WHERE OrderItemID = vOrderItemID;

    INSERT INTO Deliveries (DeliveryID, OrderItemID, SupplierID, CustomerID, Address, DeliveredDate)
    VALUES (GENERATE_UUID(), vOrderItemID, pSupplierID, vCustomerID,
            vAddress, CURRENT_TIMESTAMP)
    RETURNING DeliveryID INTO vDeliveryID;

    DECLARE
        vTotalItems     NUMBER;
        vDeliveredItems NUMBER;
    BEGIN
        SELECT COUNT(*), SUM(CASE WHEN Status = 'Delivered' THEN 1 ELSE 0 END)
        INTO vTotalItems, vDeliveredItems
        FROM OrderItems
        WHERE OrderID = vOrderID;

        IF vDeliveredItems = vTotalItems THEN
            UPDATE Orders
            SET Status = 'Fulfilled'
            WHERE OrderID = vOrderID;
        ELSIF vDeliveredItems > 0 THEN
            UPDATE Orders
            SET Status = 'Partially Fulfilled'
            WHERE OrderID = vOrderID;
        END IF;
    END;

    COMMIT;

    RETURN vOrderItemID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Supplier_Deliver_OrderItem;

CREATE OR REPLACE FUNCTION Update_Supplier_Profile(
    pSupplierID VARCHAR2,
    pName VARCHAR2,
    pEmail VARCHAR2,
    pPhone VARCHAR2,
    pAddress VARCHAR2
) RETURN VARCHAR2
    IS
    vExistingName  Suppliers.Name%TYPE;
    vExistingEmail Suppliers.Email%TYPE;
    vExistingPhone Suppliers.Phone%TYPE;
    vExistingRows  NUMBER;
BEGIN
    BEGIN
        SELECT Name, Email, Phone
        INTO vExistingName, vExistingEmail, vExistingPhone
        FROM Suppliers
        WHERE SupplierID = pSupplierID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Supplier does not exist.');
    END;

    BEGIN
        SELECT COUNT(*)
        INTO vExistingRows
        FROM Suppliers
        WHERE Name = pName
          AND SupplierID <> pSupplierID;

        IF vExistingRows > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Supplier name already exists.');
        END IF;
    END;

    BEGIN
        SELECT COUNT(*)
        INTO vExistingRows
        FROM Suppliers
        WHERE Email = pEmail
          AND SupplierID <> pSupplierID;

        IF vExistingRows > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Supplier email already exists.');
        END IF;
    END;

    BEGIN
        SELECT COUNT(*)
        INTO vExistingRows
        FROM Suppliers
        WHERE Phone = pPhone
          AND SupplierID <> pSupplierID;

        IF vExistingRows > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Supplier phone number already exists.');
        END IF;
    END;

    UPDATE Suppliers
    SET Name    = pName,
        Email   = pEmail,
        Phone   = pPhone,
        Address = pAddress
    WHERE SupplierID = pSupplierID;

    COMMIT;

    RETURN pSupplierID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Update_Supplier_Profile;

CREATE OR REPLACE FUNCTION Update_Customer_Profile(
    pCustomerID VARCHAR2,
    pName VARCHAR2,
    pEmail VARCHAR2,
    pPhone VARCHAR2,
    pAddress VARCHAR2
) RETURN VARCHAR2
    IS
    vExistingEmail Customers.Email%TYPE;
    vExistingPhone Customers.Phone%TYPE;
    vExistingRows  NUMBER;
BEGIN
    BEGIN
        SELECT Email, Phone
        INTO vExistingEmail, vExistingPhone
        FROM Customers
        WHERE CustomerID = pCustomerID
            FOR UPDATE;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'Customer does not exist.');
    END;

    BEGIN
        SELECT COUNT(*)
        INTO vExistingRows
        FROM Customers
        WHERE Email = pEmail
          AND CustomerID <> pCustomerID;

        IF vExistingRows > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Customer email already exists.');
        END IF;
    END;

    BEGIN
        SELECT COUNT(*)
        INTO vExistingRows
        FROM Customers
        WHERE Phone = pPhone
          AND CustomerID <> pCustomerID;

        IF vExistingRows > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Customer phone number already exists.');
        END IF;
    END;

    UPDATE Customers
    SET Name    = pName,
        Email   = pEmail,
        Phone   = pPhone,
        Address = pAddress
    WHERE CustomerID = pCustomerID;

    COMMIT;

    RETURN pCustomerID;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END Update_Customer_Profile;
