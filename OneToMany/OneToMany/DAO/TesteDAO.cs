using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using OneToMany.Models;

namespace OneToMany.DAO
{
    class TesteDAO
    {
        private IDbConnection _db =
            new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString);

        public List<Category> GetMultipleEntities()
        {
            var sql = "Select c.CategoryId, c.CategoryName, c.Description, c.Picture," +
                      " p.ProductId as 'Products_ProductId', p.ProductName as 'Products_ProductName', p.Discontinued as 'Products_Discontinued' " +
                      "from Categories c " +
                      "Inner join Products p on p.CategoryID = c.CategoryId";

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Category), new List<string> { "CategoryId" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Product), new List<string> { "ProductId" });

            var sqlReturn = _db.Query<dynamic>(sql);
            var categories = (Slapper.AutoMapper.MapDynamic<Category>(sqlReturn) as IEnumerable<Category>).ToList();
            return categories;
        }
    }
}
