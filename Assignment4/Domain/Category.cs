using System.Collections.Generic;

namespace Assignment4.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Product> Product { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}";
        }
    }
}
