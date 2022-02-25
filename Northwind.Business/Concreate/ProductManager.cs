using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concreate;
using Northwind.DataAccess.Concreate.EntityFramework;

namespace Northwind.Business.Concreate
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal ;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Business code
           
            return _productDal.GetAll();
        }
    }
}
