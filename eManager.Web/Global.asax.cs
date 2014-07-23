using eManager.Web.DAL.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eManager.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterDependencyResolver();
            //Database.SetInitializer(new DropCreateDatabaseAlways<eManager.Web.DAL.eManagerContext>());
        }

        private void RegisterDependencyResolver()
        {
            var kernel = new StandardKernel();

            // container configuration goes here
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IDependentRepository>().To<DependentRepository>();
            kernel.Bind<IEventRepository>().To<EventRepository>();
            kernel.Bind<IServiceRepository>().To<ServiceRepository>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public class NinjectDependencyResolver : IDependencyResolver
        {
            private readonly IKernel kernel;

            public NinjectDependencyResolver(IKernel kernel)
            {
                this.kernel = kernel;
            }

            public object GetService(Type serviceType)
            {
                return this.kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return this.kernel.GetAll(serviceType);
                }
                catch (Exception)
                {
                    return new List<object>();
                }
            }
        }
    }
}
