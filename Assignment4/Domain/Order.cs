using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Require { get; set; }
        public DateTime Shipped { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public OrderDetails OrderDetails { get; set; }

        public override string ToString()
        {
            return $"Date = {Date}, Require = {Require}, Shipped = {Shipped}, Freight = {Freight}, ShipName = {ShipName}, ShipCity = {ShipCity}, OrderDetails = {OrderDetails}";
        }
    }
}
