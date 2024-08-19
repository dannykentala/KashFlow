CREATE TABLE DocumentTypes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125)
);

CREATE TABLE Customers (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125),
    Document BIGINT(255),
    Phone VARCHAR(45),
    Address VARCHAR(75),
    Email VARCHAR(125),
    DocumentTypeId INT,
    FOREIGN KEY (DocumentTypeId) REFERENCES DocumentTypes(Id)
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Email VARCHAR(125),
    Password VARCHAR(255),
    Role ENUM('Admin', 'Employee')
);

CREATE TABLE Platforms (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(30)
);

CREATE TABLE PaymentTypes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(30)
);

CREATE TABLE Bills (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Code VARCHAR(45),
    Amount DOUBLE,
    EndPaimentDate DATE,
    PaymentTypeId INT,
    FOREIGN KEY (PaymentTypeId) REFERENCES PaymentTypes(Id)
);

CREATE TABLE Payments (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    TransactionCode VARCHAR(45),
    Date DATETIME,
    Amount DOUBLE,
    Status ENUM('Done', 'Pending', 'Fail'),
    BillId INT,
    CustomerId INT,
    PlatformId INT,
    FOREIGN KEY (BillId) REFERENCES Bills(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY (PlatformId) REFERENCES Platforms(Id)
);