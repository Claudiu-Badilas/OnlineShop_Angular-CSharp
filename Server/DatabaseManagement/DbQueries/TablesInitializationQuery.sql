/*CREATE TABLE roles (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    role_name VARCHAR(100) NOT NULL
);

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash BLOB NOT NULL,
    password_salt BLOB NOT NULL, 
    join_date DATETIME,
    last_login DATETIME,
    is_active BOOLEAN Default true,
    role_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES roles(id) ON UPDATE CASCADE ON DELETE CASCADE
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
    FOREIGN KEY (category_id) REFERENCES categories(id) ON UPDATE CASCADE ON DELETE CASCADE
);  

CREATE TABLE orders (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    order_number INT NOT NULL,
    date DATE NOT NULL,
    total_price DOUBLE NOT NULL,
    status VARCHAR(30) NOT NULL,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id)  ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE orders_products (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(id)  ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (product_id) REFERENCES products(id)  ON UPDATE CASCADE ON DELETE CASCADE
);

insert into roles (role_name) values
 ('SUPER-ADMIN'),
 ('ADMIN'),
 ('USER');

insert into users (email, password_hash, password_salt, role_id ) values
 ('emai@asd.com', 'password_hash', 'password_salt', 2);

insert into categories (name) values
 ('Oats'),
 ('Lemonade'),
 ('Cookies'),
 ('Pancakes');

INSERT INTO products (description, image, name, price, category_id)  values
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/ovaz.png','Ovaz cu fructe de padure', 20.0, 1),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/lemonade.png','Limonada cu menta', 20.0, 2),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/biscuiti.jpg','Biscuiti cu ciocolata', 20.0, 3),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/clatite.jpg','Clatite cu zmeura', 20.0, 4),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/ovaz.png','Ovaz cu fructe de padure', 20.0, 1),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/lemonade.png','Limonada cu menta', 20.0, 2),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/biscuiti.jpg','Biscuiti cu ciocolata', 20.0, 3),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/clatite.jpg','Clatite cu zmeura', 20.0, 4),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/ovaz.png','Ovaz cu fructe de padure', 20.0, 1),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/lemonade.png','Limonada cu menta', 20.0, 2),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/biscuiti.jpg','Biscuiti cu ciocolata', 20.0, 3),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/clatite.jpg','Clatite cu zmeura', 20.0, 4),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/ovaz.png','Ovaz cu fructe de padure', 20.0, 1),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/lemonade.png','Limonada cu menta', 20.0, 2),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/biscuiti.jpg','Biscuiti cu ciocolata', 20.0, 3),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/clatite.jpg','Clatite cu zmeura', 20.0, 4),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/ovaz.png','Ovaz cu fructe de padure', 20.0, 1),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/lemonade.png','Limonada cu menta', 20.0, 2),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/biscuiti.jpg','Biscuiti cu ciocolata', 20.0, 3),
('Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 'assets/images/clatite.jpg','Clatite cu zmeura', 20.0, 4);


insert into orders(order_number, date, status, total_price, user_id ) values
 (123213,'2022-04-06 21:13:57','finalized', 40.0, 1 ),
 (12344, '2022-03-07 21:13:57','pending', 120.0, 1 );

insert into orders_products (order_id, product_id) values
 (1, 1),
 (1, 2),
 (2, 1),
 (2, 2),
 (2, 2),
 (2, 3);