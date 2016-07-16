using eManager.Web.DAL.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eManager.Web.Infrastructure
{
    class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver()
        {
            this.kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IDependentRepository>().To<DependentRepository>();
            kernel.Bind<IEventRepository>().To<EventRepository>();
            kernel.Bind<IServiceRepository>().To<ServiceRepository>();
        }
    }
}
