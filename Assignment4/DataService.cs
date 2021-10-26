using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4.Domain;
using Microsoft.EntityFrameworkCore;

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
        OrderDetails GetOrderDetailsByOrderId(int orderId);
        OrderDetails GetOrderDetailsByProductId(int productId);

        // order
        Order GetOrder(int id);
        IList<Order> GetOrderyByShippingName(string shippingName);
        IList<Order> GetOrders();
    }

    public class DataService : IDataService
    {
        public Category GetCategory(int id)
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.Find(id);
        }

        public IList<Category> GetCategories()
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.ToList();
        }

        public Category CreateCategory(string categoryName, string categoryDescription)
        {
            var ctx = new NorthwindContext();
            Category category = new Category();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            category.Name = categoryName;
            category.Description = categoryDescription;
            ctx.Categories.Add(category);
            ctx.SaveChanges();
            return category;
        }

        public bool UpdateCategory(int id, string categoryName, string categoryDescription)
        {
            var ctx = new NorthwindContext();
            var newCategory = ctx.Categories.SingleOrDefault(x => x.Id == id);
            if (newCategory != null)
            {
                newCategory.Name = categoryName;
                newCategory.Description = categoryDescription;
                return ctx.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteCategory(int id)
        {
            var ctx = new NorthwindContext();
            var categ = ctx.Categories.SingleOrDefault(x => x.Id == id);
            if (categ != null)
            {
                ctx.Categories.Remove(categ);
                return ctx.SaveChanges() > 0;
            }
            return false;
        }

        public Product GetProduct(int productId)
        {
            var ctx = new NorthwindContext();
            return ctx.Products.Where(x => x.Id == productId).Include("Category").FirstOrDefault();
        }

        public IList<Product> GetProductByName(string productName)
        {
            var ctx = new NorthwindContext();
            IList<Product> allProducts = ctx.Products.ToList();
            return allProducts.Where(x => x.Name.Contains(productName)).ToList();
        }

        public IList<Product> GetProductByCategory(int categoryId)
        {
            var ctx = new NorthwindContext();
            IList<Product> allProducts = ctx.Products.Include("Category").ToList();
            return allProducts.Where(x => x.CategoryId == categoryId).ToList();
        }

        public OrderDetails GetOrderDetailsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetOrderDetailsByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            var ctx = new NorthwindContext();
            var orders = ctx.Orders.Where(x => x.Id == id).Include(x => x.OrderDetails).FirstOrDefault();
            Console.WriteLine(orders);
            return orders;
        }

        public IList<Order> GetOrderyByShippingName(string shippingName)
        { 
            var ctx = new NorthwindContext();
            IList<Order> allOrders = ctx.Orders.Include("OrderDetails.Product.Category").ToList();
            return allOrders.Where(x => x.ShipName.Contains(shippingName)).ToList();
        }

        public IList<Order> GetOrders()
        {
            var ctx = new NorthwindContext();
            return ctx.Orders.ToList();
        }
    }
}
