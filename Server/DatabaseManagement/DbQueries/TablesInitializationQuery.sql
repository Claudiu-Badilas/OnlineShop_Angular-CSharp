/*
CREATE TABLE roles (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    username VARCHAR(100) NOT NULL UNIQUE,
    email_address VARCHAR(100) NOT NULL UNIQUE,
    password_hash BLOB NOT NULL,
    password_salt BLOB NOT NULL,
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    join_date DATETIME,
    last_login DATETIME,
    active TINYINT,
    role_id INT NOT NULL,
	FOREIGN KEY (role_id) REFERENCES roles(id)
);

CREATE TABLE categories (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE products (
	id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
	description VARCHAR(500) NOT NULL,
	image VARCHAR(500) NOT NULL,
    price DOUBLE NOT NULL,
    category_id INT NOT NULL,
    FOREIGN KEY (category_id) REFERENCES categories(id) 
);  

CREATE TABLE orders (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    order_number VARCHAR(100) UNIQUE NOT NULL,
    date DATE NOT NULL,
    total_price DOUBLE NOT NULL,
    status VARCHAR(30) NOT NULL,
	user_id INT NOT NULL,	
    FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE addresses (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(50) NOT NULL,
    city VARCHAR(50) NOT NULL,
    state VARCHAR(50) NOT NULL,
     address VARCHAR(50) NOT NULL,
    observations VARCHAR(300),
	order_id INT NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(id)
);

CREATE TABLE order_items (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    product_name VARCHAR(30) NOT NULL,
    product_price INT NOT NULL,
    requested_quantity INT NOT NULL,
    product_image VARCHAR(500) NOT NULL,
	order_id INT NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(id)
);
