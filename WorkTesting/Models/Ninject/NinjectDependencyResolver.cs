using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using WorkTesting.Models.Repository;

namespace WorkTesting.Models.Ninject
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void AddBindings() 
        {
            kernel.Bind<IRepository<StudentGroup>>().To<StudentGroupsRepository>();
            kernel.Bind<IRepository<Teacher>>().To<TeachersRepository>();
        }
    }
}