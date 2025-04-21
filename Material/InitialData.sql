-- Sample Categories
INSERT INTO Category (name, description) VALUES
('Electronics', 'Devices and gadgets'),
('Books', 'Fiction and educational books'),
('Clothing', 'Men and women apparel');

-- Sample Products
INSERT INTO Product (name, price, c_id) VALUES
('Smartphone', 699.99, 1),
('Laptop', 1199.50, 1),
('Fantasy Novel', 19.99, 2),
('T-Shirt', 15.00, 3);

-- Sample Users (Assuming AspNetUsers already has some users)
-- Replace with actual Ids from AspNetUsers
-- Let's assume user1 = 'user-guid-1', user2 = 'user-guid-2'
DECLARE @User1 NVARCHAR(450) = '227dc717-b979-4332-b26d-a51b9fe6365d';
DECLARE @User2 NVARCHAR(450) = 'e275541b-f2ad-4e98-aba3-4b9def049a95';

-- Sample Addresses
INSERT INTO Address (city, state, country, u_id) VALUES
('Cairo', 'Cairo', 'Egypt', @User1),
('Alexandria', 'Alex', 'Egypt', @User2);

-- Sample Payments
INSERT INTO Payment (method, amount, u_id) VALUES
('Credit Card', 719.99, @User1),
('Cash on Delivery', 34.99, @User2);

-- Sample Orders
INSERT INTO [Order] (amount, order_date, u_id) VALUES
(719.99, '2025-04-10', @User1),
(34.99, '2025-04-09', @User2);

-- Sample Tracking Details
INSERT INTO TrackingDetail (status, order_no) VALUES
('Shipped', 1),
('Delivered', 2);

-- Sample OrderProduct entries
INSERT INTO OrderProduct (order_no, p_id) VALUES
(1, 1), -- Order 1, Smartphone
(2, 3); -- Order 2, Fantasy Novel

-- Sample Carts
INSERT INTO Cart (u_id) VALUES
(@User1),
(@User2);

-- Sample CartProduct entries
INSERT INTO CartProduct (cart_id, p_id) VALUES
(1, 2), -- Laptop in user1's cart
(2, 4); -- T-Shirt in user2's cart

-- Sample Reviews
INSERT INTO Review (rating, comment, review_date, u_id, p_id) VALUES
(5, 'Amazing phone!', '2025-04-11', @User1, 1),
(4, 'Nice story.', '2025-04-10', @User2, 3);
