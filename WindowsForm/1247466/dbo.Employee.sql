CREATE TABLE [dbo].[Employee] (
    [EmployeeID] INT           IDENTITY (1, 1) NOT NULL,
    [EName]      NVARCHAR (30) NULL,
    [Gender]     NVARCHAR (15) NULL,
    [Religion]   NVARCHAR (20) NULL,
    [DOB]        DATE          DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);
GO

INSERT INTO Employee(Ename,Gende,Religion,DOB) VALUES ('Akib','Others','Budho','01-01-2000')
go


