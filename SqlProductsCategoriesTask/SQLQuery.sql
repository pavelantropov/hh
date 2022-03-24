SELECT P.ProductName, C.CategoryName FROM Products P
LEFT OUTER JOIN ProductsCategories PC
ON P.ProductID = PC.ProductID
LEFT OUTER JOIN Categories C
ON PC.CategoryID = C.CategoryID