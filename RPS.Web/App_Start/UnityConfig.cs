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

            var tempDataContext = new PtInMemoryContext();

            container.RegisterType<IPtUserRepository, PtUserRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new PtUserRepository(tempDataContext))
                );

            container.RegisterType<IPtItemsRepository, PtItemsRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new PtItemsRepository(tempDataContext))
                );

            container.RegisterType<IPtDashboardRepository, PtDashboardRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new PtDashboardRepository(tempDataContext))
                );

            container.RegisterType<IPtTasksRepository, PtTasksRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new PtTasksRepository(tempDataContext))
                );

            container.RegisterType<IPtCommentsRepository, PtCommentsRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new PtCommentsRepository(tempDataContext))
                );


            container.Resolve<IPtItemsRepository>();
            container.Resolve<IPtUserRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}