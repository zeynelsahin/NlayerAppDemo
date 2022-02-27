using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace Northwind.Business.DependecyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetIntance<T>( )
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
