using Microsoft.EntityFrameworkCore;
using System;

namespace Data_layer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataService = new DataService();

            foreach (var category in dataService.GetCategories())
            {
                Console.WriteLine(category);
            }
        }

    }
}
