using Assignment4.Domain;
using System.Collections.Generic;

namespace WebService.ViewModels
{
    public class ProductViewModel
    {
        public int Url { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public IList<OrderDetails> OrderDetails { get; set; }
    }
}
