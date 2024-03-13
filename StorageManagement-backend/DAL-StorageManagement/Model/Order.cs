using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_StorageManagement.Model
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int Amount { get; set; }

        //Navigation
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
