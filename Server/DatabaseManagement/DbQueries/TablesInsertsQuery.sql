insert into roles values
 (1, 'USER'),
 (2, 'ADMIN'),
 (3, 'SUPER_ADMIN');

 insert into users (username, email_address, password_hash, password_salt, first_name, last_name, join_date, last_login, active, role_id) values
 ('admin', 'emai@asd.com', '6z8A50veHAAp3hHRIilRl6Or4tpyoj2aAZ4rSVG+6ZQsFwlgYWybMlxrGpr45lKfMrL18V4UMA4qeMR2Cyb/IA==', '6ygGLJr1hOp3o3M3JfzCE69KW77uwgB+AOLkXWjjuXa5Dsbt1qipkIQE/fxVhSHO5nQpSetiByj8HdZZ7tLN305Zfr+o6KWXeSRwLqx/rpVq7AEqRQ9OzrP2GXFLgC7saEt+sEcAVRY0NrQJXfwuMHMXRp5a5LP3p1+AEzGT1W0=', 'test_first_name','test_last_name', '2022-04-06 21:13:57', '2022-04-06 21:13:57', 1, 2);

insert into categories values
 (1, 'Oats'),
 (2, 'Lemonade'),
 (3, 'Cookies'),
 (4, 'Pancakes');
 

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
 ('1232213','2020-01-01T00:00:00','finalized', 40.0, 1 ),
 ('122344', '2020-01-01T00:00:00','pending', 120.0, 1 );

insert into order_items (order_id, product_name, product_price, requested_quantity, product_image) values
 (1, 'Ovaz cu fructe de padure', 20.0, 1, 'assets/images/ovaz.png'),
 (1, 'Clatite cu zmeura', 20.0, 1, 'assets/images/clatite.jpg'),
 (1, 'Limonada cu menta', 20.0, 6, 'assets/images/lemonade.jpg');
 