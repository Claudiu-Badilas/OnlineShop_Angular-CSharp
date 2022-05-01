insert into users (username, email_address, password_hash, password_salt, full_name) values
 ('test_user', 'emai@asd.com', 'password_hash', 'password_salt', 'full_name');

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
 