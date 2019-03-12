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

            container.RegisterType<IRpsDataPtItems, InMemoryRpsDataPtItems>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new InMemoryRpsDataPtItems())
                );

            container.RegisterType<IRpsDataPtUsers, InMemoryRpsDataPtUsers>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new InMemoryRpsDataPtUsers())
                );

            container.Resolve<IRpsDataPtItems>();
            container.Resolve<IRpsDataPtUsers>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}