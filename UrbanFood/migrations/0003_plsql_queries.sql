CREATE OR REPLACE FUNCTION List_Inventory_Products(
    pSupplierID VARCHAR2,
    pCategory VARCHAR2 DEFAULT NULL,
    pName VARCHAR2 DEFAULT NULL,
    pStockAvailable NUMBER DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor      SYS_REFCURSOR;
    vSQL         VARCHAR2(1000);
    vWhereClause VARCHAR2(1000) := ' WHERE SupplierID = :supplierID AND Discontinued = 0 ';
BEGIN
    IF pCategory IS NOT NULL AND TRIM(pCategory) != '' THEN
        vWhereClause := vWhereClause || ' AND LOWER(Category) = LOWER(:category) ';
    END IF;

    IF pName IS NOT NULL AND TRIM(pName) != '' THEN
        vWhereClause := vWhereClause || ' AND LOWER(Name) LIKE LOWER(:name) ';
    END IF;

    IF pStockAvailable IS NOT NULL THEN
        IF pStockAvailable = 1 THEN
            vWhereClause := vWhereClause || ' AND StockQuantity > 0 ';
        ELSIF pStockAvailable = 0 THEN
            vWhereClause := vWhereClause || ' AND StockQuantity = 0 ';
        END IF;
    END IF;

    vSQL := 'SELECT * FROM Products ' || vWhereClause || ' ORDER BY AddedAt DESC';

    OPEN vCursor FOR vSQL
        USING pSupplierID, pCategory, '%' || pName || '%', pStockAvailable;

    RETURN vCursor;
END List_Inventory_Products;

CREATE OR REPLACE FUNCTION List_Products(
    pCategory VARCHAR2 DEFAULT NULL,
    pName VARCHAR2 DEFAULT NULL,
    pStockAvailable NUMBER DEFAULT NULL
) RETURN SYS_REFCURSOR IS
    vCursor      SYS_REFCURSOR;
    vSQL         VARCHAR2(1000);
    vWhereClause VARCHAR2(1000) := ' WHERE Discontinued = 0 ';
BEGIN
    IF pCategory IS NOT NULL AND TRIM(pCategory) != '' THEN
        vWhereClause := vWhereClause || ' AND LOWER(Category) = LOWER(:category) ';
    END IF;

    IF pName IS NOT NULL AND TRIM(pName) != '' THEN
        vWhereClause := vWhereClause || ' AND LOWER(Name) LIKE LOWER(:name) ';
    END IF;

    IF pStockAvailable IS NOT NULL THEN
        IF pStockAvailable = 1 THEN
            vWhereClause := vWhereClause || ' AND StockQuantity > 0 ';
        ELSIF pStockAvailable = 0 THEN
            vWhereClause := vWhereClause || ' AND StockQuantity = 0 ';
        END IF;
    END IF;

    vSQL := 'SELECT * FROM Products ' || vWhereClause || ' ORDER BY AddedAt DESC';

    OPEN vCursor FOR vSQL
        USING pCategory, '%' || pName || '%', pStockAvailable;

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
        IF pStatus IN ('Pending', 'Confirmed', 'Fulfilled', 'Returned', 'Canceled') THEN
            vValidStatus := TRUE;
        END IF;

        IF NOT vValidStatus THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Invalid status. Allowed values are: Pending, Confirmed, Canceled, Fulfilled, Returned');
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
        IF pStatus IN ('Pending', 'Confirmed', 'Fulfilled', 'Returned', 'Canceled') THEN
            vValidStatus := TRUE;
        END IF;

        IF NOT vValidStatus THEN
            RAISE_APPLICATION_ERROR(-20001,
                                    'Invalid status. Allowed values are: Pending, Confirmed, Canceled, Fulfilled');
        END IF;
    END IF;

    IF NOT vValidStatus THEN
        RAISE_APPLICATION_ERROR(-20001,
                                'Invalid status. Allowed values are: Pending, Confirmed, Canceled, Returned, Fulfilled');
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
) RETURN SYS_REFCURSOR IS
    vCursor SYS_REFCURSOR;
BEGIN
    OPEN vCursor FOR
        SELECT * FROM Products WHERE ProductID = pProductID;

    RETURN vCursor;
END Get_Product_By_ID;
