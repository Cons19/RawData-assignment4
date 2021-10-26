using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer.Domain
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"Date = {Product.Name}, Price = {Price}, Quantity = {Quantity}}";
        }
    }
}
