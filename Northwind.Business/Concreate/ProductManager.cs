using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.ValidationRules.FluentValidition;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concreate;
using Northwind.DataAccess.Concreate.EntityFramework;
using NorthwinEntities.Concreate;

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

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId==categoryId);
        }

        public List<Product> GetProductsByName(string name)
        {
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(name.ToLower()));
        }

        public void Add(Product product)
        {
            ProductValidatior productValidatior = new ProductValidatior();
            var result=productValidatior.Validate(product);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);

            }
            catch (DbUpdateException exception)
            {
                throw new Exception("Güncelleme Gerçekleştirilemedi");
            }
        }
    }
}
