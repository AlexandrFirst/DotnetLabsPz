using Lab3_Dot_Net.Core;
using Lab3_Dot_Net.Persistence;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Lab3_Dot_Net
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}