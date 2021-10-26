﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Quantity { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"Name = {Name}, Price = {Price}, CategoryName = {Category.Name}";
        }
    }
}