-- Insert data for DocumentTypes
INSERT INTO DocumentTypes (Name) VALUES
('Cedula'),
('Passport');

-- Insert data for Customers
INSERT INTO Customers (Name, Document, Phone, Address, Email, DocumentTypeId) VALUES
('John Doe', 1234567890, '+123456789', '123 Main St', 'johndoe@example.com', 1),
('Jane Smith', 6543210, '+987654321', '456 Elm St', 'janesmith@example.com', 1),
('Alice Johnson', 5555555, '+555555555', '789 Oak St', 'alicejohnson@example.com', 1),
('Bob Brown', 222233, '+1111222233', '101 Pine St', 'bobbrown@example.com', 1),
('Charlie Davis', 2222333, '+2222333344', '202 Cedar St', 'charliedavis@example.com', 1);

-- Insert data for Payments
INSERT INTO Payments (TransactionCode, Date, Amount, Status, BillId, CustomerId, PlatformId) VALUES
('TXN001', '2024-08-13 10:00:00', 150.00, 'Done', 1, 1, 1),
('TXN002', '2024-08-14 11:00:00', 200.50, 'Pending', 2, 2, 2),
('TXN003', '2024-08-15 12:00:00', 75.25, 'Fail', 3, 3, 3),
('TXN004', '2024-08-16 13:00:00', 300.00, 'Done', 4, 4, 1),
('TXN005', '2024-08-17 14:00:00', 125.75, 'Pending', 5, 5, 2);

-- Insert data for Bills
INSERT INTO Bills (Code, Amount, EndPaimentDate, PaymentTypeId) VALUES
('BILL001', 150.00, '2024-08-13', 1),
('BILL002', 200.50, '2024-08-14', 2),
('BILL003', 75.25, '2024-08-15', 3),
('BILL004', 300.00, '2024-08-16', 1),
('BILL005', 125.75, '2024-08-17', 2);

-- Insert data for Platforms
INSERT INTO Platforms (Name) VALUES
('Nequi'),
('Daviplata');

-- Insert data for PaymentTypes
INSERT INTO PaymentTypes (Name) VALUES
('Credit Card'),
('Bank Transfer'),
('Cash');

-- Insert data for Employees
INSERT INTO Employees (Email, Password, Role) VALUES
('admin1@example.com', 'adminpassword1', 'Admin'),
('robinson.cortes@riwi.io', 'password', 'Admin');