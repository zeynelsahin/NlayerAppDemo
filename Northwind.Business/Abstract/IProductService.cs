using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Concreate;
using NorthwinEntities.Concreate;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsByName(string name);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
    
}
