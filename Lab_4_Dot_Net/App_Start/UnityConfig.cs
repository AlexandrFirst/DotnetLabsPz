using Lab_4_Dot_Net.Core;
using Lab_4_Dot_Net.Persistence;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Lab_4_Dot_Net
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<LostAndFoundContext, LostAndFoundContext>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}