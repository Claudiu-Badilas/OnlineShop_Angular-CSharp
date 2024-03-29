﻿using Server.Repositories.Models;

namespace Server.Models {
    public class Product {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}
