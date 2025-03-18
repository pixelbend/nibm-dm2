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

CREATE OR REPLACE FUNCTION List_Orders_By_Customer(
    pCustomerID VARCHAR2,
    pStatus VARCHAR2 DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor      SYS_REFCURSOR;
    vValidStatus BOOLEAN := FALSE;
BEGIN
    IF pStatus IS NOT NULL THEN
        IF pStatus IN ('Pending', 'Confirmed', 'Processing', 'Fulfilled', 'Returned', 'Canceled') THEN
            vValidStatus := TRUE;
        END IF;

        IF NOT vValidStatus THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Invalid status. Allowed values are: Pending, Confirmed, Canceled, Processing, Fulfilled');
        END IF;
    END IF;

    OPEN vCursor FOR
        SELECT o.OrderID       AS OrderID,
               o.ProductID     AS ProductID,
               p.Name          AS Name,
               p.Description   AS Description,
               p.Category      AS Category,
               p.Price         AS Price,
               p.StockQuantity AS StockQuantity,
               o.Quantity      AS Quantity,
               o.Total         AS Total,
               o.Status        AS Status,
               o.OrderDate     AS OrderDate
        FROM Orders o
                 JOIN Products p ON o.ProductID = p.ProductID
        WHERE o.CustomerID = pCustomerID
          AND (pStatus IS NULL OR o.Status = pStatus);

    RETURN vCursor;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END List_Orders_By_Customer;

CREATE OR REPLACE FUNCTION List_Orders_By_Supplier(
    pSupplierID VARCHAR2,
    pStatus VARCHAR2 DEFAULT NULL,
    pProductName VARCHAR2 DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor      SYS_REFCURSOR;
    vValidStatus BOOLEAN := FALSE;
BEGIN
    IF pStatus IS NOT NULL THEN
        IF pStatus IN ('Pending', 'Confirmed', 'Processing', 'Fulfilled', 'Returned', 'Canceled') THEN
            vValidStatus := TRUE;
        END IF;

        IF NOT vValidStatus THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Invalid status. Allowed values are: Pending, Confirmed, Canceled, Processing, Fulfilled');
        END IF;
    END IF;

    IF NOT vValidStatus THEN
        RAISE_APPLICATION_ERROR(-20001,
                                'Invalid status. Allowed values are: Pending, Confirmed, Canceled, Processing, Fulfilled');
    END IF;

    OPEN vCursor FOR
        SELECT o.OrderID       AS OrderID,
               o.CustomerID    AS CustomerID,
               o.ProductID     AS ProductID,
               p.Name          AS Name,
               p.Description   AS Description,
               p.Category      AS Category,
               p.Price         AS Price,
               p.StockQuantity AS StockQuantity,
               o.Quantity      AS Quantity,
               o.Total         AS Total,
               o.Status        AS OrderStatus,
               o.OrderDate     AS OrderDate
        FROM Orders o
                 JOIN Products p ON o.ProductID = p.ProductID
        WHERE p.SupplierID = pSupplierID
          AND (pStatus IS NULL OR o.Status = pStatus)
          AND (pProductName IS NULL OR p.Name = pProductName);

    RETURN vCursor;
END List_Orders_By_Supplier;

CREATE OR REPLACE FUNCTION Get_Product_By_ID(
    pProductID Products.ProductID%TYPE
) RETURN Products%ROWTYPE IS
    vProduct Products%ROWTYPE;
BEGIN
     BEGIN
        SELECT * INTO vProduct
        FROM Products
        WHERE ProductID = pProductID;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20001, 'No product found with the given ID');
    END;

    RETURN vProduct;
END Get_Product_By_ID;
