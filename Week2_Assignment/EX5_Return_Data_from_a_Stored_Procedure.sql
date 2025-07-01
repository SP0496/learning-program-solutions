-- Step 1: Create Database
CREATE DATABASE OrgDB_StaffCounter;
GO
USE OrgDB_StaffCounter;
GO

-- Step 2: Create Division Table
CREATE TABLE Divisions (
    DivisionID INT PRIMARY KEY IDENTITY(1,1),
    DivisionName VARCHAR(100) NOT NULL
);
GO

-- Step 3: Create Staff Table
CREATE TABLE Staff (
    StaffID INT PRIMARY KEY IDENTITY(1,1),
    First_Name VARCHAR(50) NOT NULL,
    Last_Name VARCHAR(50) NOT NULL,
    DivisionID INT NOT NULL,
    Pay DECIMAL(10,2),
    HireDate DATE,
    FOREIGN KEY (DivisionID) REFERENCES Divisions(DivisionID)
);
GO

-- Step 4: Insert Sample Divisions
INSERT INTO Divisions (DivisionName) VALUES
('Operations'),
('Accounts'),
('Technology'),
('Sales');
GO

-- Step 5: Insert Sample Staff
INSERT INTO Staff (First_Name, Last_Name, DivisionID, Pay, HireDate) VALUES
('Ananya', 'Iyer', 3, 85000, '2024-03-05'),     -- Technology
('Rahul', 'Verma', 3, 74000, '2023-08-10'),     -- Technology
('Meera', 'Nair', 1, 91000, '2022-06-22'),      -- Operations
('Arjun', 'Patel', 2, 77000, '2024-02-15');     -- Accounts
GO

-- Step 6: Create Stored Procedure to Return Staff Count by Division
CREATE PROCEDURE sp_GetStaffCountByDivision
    @DivisionID INT
AS
BEGIN
    SELECT 
        COUNT(*) AS TotalStaff
    FROM 
        Staff
    WHERE 
        DivisionID = @DivisionID;
END;
GO

-- Example Query: Get Staff Count for Technology Division (DivisionID = 3)
EXEC sp_GetStaffCountByDivision @DivisionID = 3;
GO
