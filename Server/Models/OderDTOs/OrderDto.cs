namespace Server.Models.OderDTOs {
    public class OrderDto {
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public double TotalPrice { get; set; }
        public long UserId { get; set; }
    }
}
