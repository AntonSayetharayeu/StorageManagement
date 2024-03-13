using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }

        //navigation
        public Product Product { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }

    }
}
