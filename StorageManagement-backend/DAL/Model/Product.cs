using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Product
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string Photo { get; set; }
        public int CategoryID { get; set; }

        //Navigation
        public Category Category { get; set; }
    }
}
