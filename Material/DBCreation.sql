-- Create ProductCategory table
CREATE TABLE Category (
    c_id INT PRIMARY KEY Identity(1,1),
    name NVARCHAR(100),
    description NVARCHAR(255)
);

-- Create Product table
CREATE TABLE Product (
    p_id INT PRIMARY KEY Identity(1,1),
    name NVARCHAR(100),
    price DECIMAL(10, 2),
    c_id INT,
    FOREIGN KEY (c_id) REFERENCES Category(c_id)
);

-- Create Address table (references AspNetUsers for u_id)
CREATE TABLE Address (
    a_id INT PRIMARY KEY Identity(1,1),
    city NVARCHAR(100),
    state NVARCHAR(100),
    country NVARCHAR(100),
    u_id NVARCHAR(450),
    FOREIGN KEY (u_id) REFERENCES AspNetUsers(Id)
);

-- Create Payment table (references AspNetUsers for u_id)
CREATE TABLE Payment (
    p_id INT PRIMARY KEY Identity(1,1),
    method NVARCHAR(50),
    amount DECIMAL(10, 2),
    u_id NVARCHAR(450),
    FOREIGN KEY (u_id) REFERENCES AspNetUsers(Id)
);

-- Create Order table (references AspNetUsers for u_id)
CREATE TABLE [Order] (
    order_no INT PRIMARY KEY Identity(1,1),
    amount DECIMAL(10, 2),
    order_date DATE,
    u_id NVARCHAR(450),
    FOREIGN KEY (u_id) REFERENCES AspNetUsers(Id)
);

-- Create TrackingDetail table
CREATE TABLE TrackingDetail (
    t_id INT PRIMARY KEY Identity(1,1),
    status NVARCHAR(50),
    order_no INT,
    FOREIGN KEY (order_no) REFERENCES [Order](order_no)
);

-- Create OrderProduct junction table
CREATE TABLE OrderProduct (
    order_no INT,
    p_id INT,
    PRIMARY KEY (order_no, p_id),
    FOREIGN KEY (order_no) REFERENCES [Order](order_no),
    FOREIGN KEY (p_id) REFERENCES Product(p_id)
);

-- Create Cart table (references AspNetUsers for u_id)
CREATE TABLE Cart (
    cart_id INT PRIMARY KEY Identity(1,1),
    u_id NVARCHAR(450),
    FOREIGN KEY (u_id) REFERENCES AspNetUsers(Id)
);

-- Create CartProduct junction table
CREATE TABLE CartProduct (
    cart_id INT,
    p_id INT,
    PRIMARY KEY (cart_id, p_id),
    FOREIGN KEY (cart_id) REFERENCES Cart(cart_id),
    FOREIGN KEY (p_id) REFERENCES Product(p_id)
);

-- Create Review table (references AspNetUsers and Product)
CREATE TABLE Review ( -- can make PK(u_id, p_id)
    r_id INT PRIMARY KEY Identity(1,1),
    rating INT CHECK (rating >= 1 AND rating <= 5),
    comment NVARCHAR(1000),
    review_date DATE,
    u_id NVARCHAR(450),
    p_id INT,
    FOREIGN KEY (u_id) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (p_id) REFERENCES Product(p_id)
);