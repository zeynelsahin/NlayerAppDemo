using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Concreate;
using NorthwinEntities.Concreate;

namespace Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product> 
    {

    }
}
