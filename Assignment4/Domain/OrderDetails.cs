using System.ComponentModel.DataAnnotations;

namespace Assignment4.Domain
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

        public override string ToString()
        {
            return $"Product = {Product.Name}, ProductCategory = {Product.Category.Name}, Price = {UnitPrice}, Quantity = {Quantity}";
        }
    }
}
