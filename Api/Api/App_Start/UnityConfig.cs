using System.Web.Mvc;
using Api.Bll.Services;
using Unity;
using Unity.Mvc5;

namespace Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}