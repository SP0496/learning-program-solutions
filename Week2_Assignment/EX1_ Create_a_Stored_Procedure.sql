-- Create a new database named 'EmployeeManagementDB'
CREATE DATABASE EmployeeManagementDB;
GO

USE EmployeeManagementDB;
GO

-- Create the Departments table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

-- Create the Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);
GO

-- Insert data into the Departments & Employees table
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO

-- Retrieve employee details along with their department name
SELECT 
    E.EmployeeID,
    E.FirstName,
    E.LastName,
    E.Salary,
    E.JoinDate,
    D.DepartmentName
FROM 
    Employees E
INNER JOIN 
    Departments D ON E.DepartmentID = D.DepartmentID
WHERE 
    E.DepartmentID = 2;
    GO


-- Insert a new employee into the Employees table
-- The EmployeeID will be automatically generated because it uses IDENTITY
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES ('Alice', 'Walker', 3, 7500.00, '2023-06-01');
GO

-- EXAMPLE: Retrieve employee details for those in Department 3
SELECT 
    E.EmployeeID,
    E.FirstName,
    E.LastName,
    E.Salary,
    E.JoinDate,
    D.DepartmentName
FROM 
    Employees E
JOIN 
    Departments D ON E.DepartmentID = D.DepartmentID
WHERE 
    E.DepartmentID = 3;




