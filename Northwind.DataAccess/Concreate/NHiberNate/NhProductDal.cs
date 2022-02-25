using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Abstract;

namespace Northwind.DataAccess.Concreate.NHiberNate
{
    public class NhProductDal:IProductDal
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ProductId = 1,CategoryId = 5,ProductName = "Laptop",QuantityPerUnit = "1 in a box",UnitPrice = 3000,UnitsInStock = 11}
            };
            return products;
        }

        public Product Get(int id)
        {
            return null;
        }

        public void Add(Product product)
        {
        }

        public void Update(Product product)
        {
        }

        public void Delete(Product product)
        {
        }
    }
}
