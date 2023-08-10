using RPS.Data;
using System.Web.Mvc;
using Unity;
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

            container.RegisterFactory<IPtUserRepository>(
                c => new PtUserRepository(tempDataContext),
                new ContainerControlledLifetimeManager()
                );

            container.RegisterFactory<IPtItemsRepository>(
                c => new PtItemsRepository(tempDataContext),
                new ContainerControlledLifetimeManager()
                );

            container.RegisterFactory<IPtDashboardRepository>(
                c => new PtDashboardRepository(tempDataContext),
                new ContainerControlledLifetimeManager()
                );

            container.RegisterFactory<IPtTasksRepository>(
                c => new PtTasksRepository(tempDataContext),
                new ContainerControlledLifetimeManager()
                );

            container.RegisterFactory<IPtCommentsRepository>(
                c => new PtCommentsRepository(tempDataContext),
                new ContainerControlledLifetimeManager()
                );


            container.Resolve<IPtItemsRepository>();
            container.Resolve<IPtUserRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}