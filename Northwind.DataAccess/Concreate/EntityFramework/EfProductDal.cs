using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Abstract;
using NorthwinEntities.Concreate;

namespace Northwind.DataAccess.Concreate.EntityFramework
{
    public class EfProductDal :EfEntityReposistoryBase<Product,NorthwindContext>, IProductDal
    {
        
    }
}
