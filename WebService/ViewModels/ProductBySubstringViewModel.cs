using Assignment4.Domain;
using System.Collections.Generic;

namespace WebService.ViewModels
{
    public class ProductByCategoryViewModel
    {
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
