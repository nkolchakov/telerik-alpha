SELECT * FROM Departments

SELECT Name FROM Departments

SELECT * FROM Employees 

SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees

SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] FROM Employees

SELECT DISTINCT Salary from Employees

SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees 
WHERE FirstName LIKE 'SA%'

SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees 
WHERE LastName LIKE '%ei%'

SELECT * FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT FirstName + ' ' + LastName AS [Full Name], Salary FROM Employees 
WHERE Salary IN (25000,14000, 12500 ,23600)

SELECT * FROM Employees WHERE ManagerID IS NULL

SELECT * FROM Employees WHERE Salary > 50000 ORDER BY Salary DESC

SELECT TOP 10 * FROM Employees ORDER BY Salary DESC 

SELECT * FROM Addresses

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText 
FROM Employees e JOIN Addresses a
ON e.AddressID = a.AddressID 


SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText 
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

SELECT e.FirstName + ' ' + e.LastName AS [Employee], m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
INNER JOIN  Employees m
ON e.ManagerID = m.EmployeeID

-- down

SELECT e.FirstName [Employee Name], m.FirstName [Managed Name], a.AddressText [Address] FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
JOIN Addresses a
ON e.AddressID = a.AddressID

SELECT d.Name [Department Name] FROM Departments d
UNION 
SELECT t.Name [Town Name] FROM Towns t

SELECT e.FirstName [Employee Name], m.FirstName [Manager Name] 
FROM Employees m
RIGHT JOIN Employees e
ON m.EmployeeID = e.ManagerID

SELECT e.FirstName [Employee Name], m.FirstName [Manager Name] 
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName [Full Name] FROM Employees e
JOIN Departments d
ON  e.DepartmentID = d.DepartmentID AND d.Name IN ('Sales','Finance')
WHERE YEAR(e.HireDate) BETWEEN 1995 AND 2005

