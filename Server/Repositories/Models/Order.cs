using Server.Models;

namespace Server.Repositories.Models {
    public class Order {

        public int Id { get; set; }
        public long OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
    }

    public class OrderItems {
        public int Id { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

}
