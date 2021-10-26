using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer
{
    public interface IDataService
    {
        // category
        Category GetCategoryById(int id);
        IList<Category> GetCategories();
        Category CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);

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
        public Category GetCategoryById(int id)
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.Find(id);
        }

        public IList<Category> GetCategories()
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.ToList();
        }

        public Category CreateCategory(Category category)
        {
            var ctx = new NorthwindContext();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            ctx.Categories.Add(category);
            ctx.SaveChanges();
            return category;
        }

        public bool UpdateCategory(Category category)
        {
            var ctx = new NorthwindContext();
            var newCategory = ctx.Categories.SingleOrDefault(x => x.Id == category.Id);
            if (newCategory != null)
            {
                newCategory = category;
                return ctx.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteCategory(Category category)
        {
            var ctx = new NorthwindContext();
            var categ = ctx.Categories.SingleOrDefault(x => x.Id == category.Id);
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
