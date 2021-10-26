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
        Product GetProductById(int productId);
        IList<Product> SearchProduct(string searchText);
        Product GetProductByCategoryId(int categoryId);

        // order details
        OrderDetails GetOrderDetailsByOrderId(int orderId);
        OrderDetails GetOrderDetailsByProductId(int productId);

        // order
        Order GetOrderyById(int id);
        Order GetOrderyByShippingName(int shippingName);
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



        public IList<Product> GetProducts()
        {
            var ctx = new NorthwindContext();
            return ctx.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> SearchProduct(string searchText)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetOrderDetailsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetOrderDetailsByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderyById(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderyByShippingName(int shippingName)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
