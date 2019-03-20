using RPS.Data;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace RPS.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            var tempDataContext = new RpsInMemoryContext();

            container.RegisterType<IRpsPtItemsRepository, RpsPtItemsRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new RpsPtItemsRepository(tempDataContext))
                );

            container.RegisterType<IRpsPtUserRepository, RpsPtUserRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new RpsPtUserRepository(tempDataContext))
                );

            container.Resolve<IRpsPtItemsRepository>();
            container.Resolve<IRpsPtUserRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}