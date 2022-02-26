using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwinEntities.Concreate;

namespace Northwind.DataAccess.Abstract
{
    internal interface ICategoryDal:IEntityRepository<Category>
    {

    }
}
