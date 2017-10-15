/*
Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
Use a nested SELECT statement.
*/
SELECT FirstName, Salary FROM Employees
WHERE Salary = 
(SELECT MIN(Salary) FROM Employees)

/*
Write a SQL query to find the names and salaries of the employees that have a salary 
that is up to 10% higher than the minimal salary for the company.
*/

SELECT FirstName, LastName, Salary FROM Employees 
WHERE Salary > 
(SELECT MIN(Salary) FROM Employees ) * 1.1

/*
Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
Use a nested SELECT statement.
*/

SELECT FirstName, LastName, DepartmentID, Salary
FROM Employees e
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID) -- every salary in the department with ID = X

--Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) FROM Employees
WHERE DepartmentID = 1

-- Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(Salary) FROM Employees e
WHERE DepartmentID = 
(SELECT DepartmentID FROM Departments
WHERE Name = 'Sales')

SELECT AVG(Salary) FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID 
WHERE d.Name = 'Sales'

-- Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

SELECT COUNT(*) FROM Employees e
WHERE e.DepartmentID =
(SELECT DepartmentID FROM Departments
WHERE Name = 'Sales' 
AND DepartmentID = e.DepartmentID)

-- Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) FROM Employees
WHERE ManagerID IS NULL

-- Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name , AVG(e.Salary) [Avarage Salary] 
FROM Departments d
JOIN Employees e
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

--Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name, t.Name, COUNT(*) FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name, d.Name

--Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
set statistics time on 

SELECT m.FirstName, m.LastName FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
AND (SELECT COUNT(*) FROM Employees WHERE ManagerID = m.EmployeeID) = 5
GROUP BY m.FirstName, m.LastName

set statistics time off
--////
set statistics time on 

SELECT m.firstName, m.LastName FROM Employees m
	JOIN Employees e 
	ON e.ManagerID = m.EmployeeID
	GROUP BY m.FirstName, m.LastName
	HAVING COUNT(e.ManagerID) = 5

set statistics time off

-- Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName [Empl Name],
ISNULL(m.FirstName, 'no manager') [Manager Name] 
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

--Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
--  Search in Google to find how to format dates in SQL Server.
SELECT CONVERT(varchar,GETDATE(), 113)

--Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name [Dep name], e.JobTitle, AVG(Salary) as AvgSalary FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name
ORDER BY AvgSalary DESC

--Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT d.Name, e.JobTitle, MIN(Salary) as MinSalary
FROM Employees e
JOIN Departments d 
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY MinSalary DESC

-- Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(*) as TotalCount FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY TotalCount DESC

-- Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(*) as ManagersCount FROM Towns t
JOIN Addresses a
ON t.TownID = a.TownID
JOIN Employees e
ON e.AddressID = a.AddressID
WHERE e.EmployeeID IN (SELECT ManagerID FROM Employees)
GROUP BY t.Name
ORDER BY ManagersCount DESC
