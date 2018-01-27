using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain._Entities
{
    public class CartLine
    {
        public Product product { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
