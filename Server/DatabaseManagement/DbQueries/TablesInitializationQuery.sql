/*
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    username VARCHAR(100) NOT NULL,
    email_address VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    full_name VARCHAR(100) 
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
    order_number INT NOT NULL,
    date DATE NOT NULL,
    total_price DOUBLE NOT NULL,
    status VARCHAR(30) NOT NULL,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE orders_products (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);
*/