using System.Text.Json.Serialization;

namespace DAL.Model
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }

        //Navigation
        public User User { get; set; }
        public ICollection<OrderDetails> Details { get; set; }
    }
}
