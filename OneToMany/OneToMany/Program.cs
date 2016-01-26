using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneToMany.DAO;
using OneToMany.Models;

namespace OneToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            TesteDAO teste = new TesteDAO();
            IEnumerable<Category> resultado = teste.GetMultipleEntities();

            foreach (Category category in resultado)
            {
                Console.WriteLine("- " + category.CategoryName);
                foreach (var product in category.Products)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            Console.ReadLine();
        }
    }
}
