using System.Collections.Generic;
using Assignment4.Domain;

namespace Assignment4
{
    public interface IDataService
    {
        // category
        Category GetCategory(int id);
        IList<Category> GetCategories();
        Category CreateCategory(string categoryName, string categoryDescription);
        bool UpdateCategory(int id, string categoryName, string categoryDescription);
        bool DeleteCategory(int id);

        // product
        Product GetProduct(int productId);
        IList<Product> GetProductByName(string productName);
        IList<Product> GetProductByCategory(int categoryId);

        // order details
        IList<OrderDetails> GetOrderDetailsByOrderId(int orderId);
        IList<OrderDetails> GetOrderDetailsByProductId(int productId);

        // order
        Order GetOrder(int id);
        IList<Order> GetOrderyByShippingName(string shippingName);
        IList<Order> GetOrders();
    }
}
