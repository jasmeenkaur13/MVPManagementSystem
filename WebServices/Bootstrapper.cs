using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer;
using DataModels.UnitOfWork;
using Microsoft.Practices.Unity;
using Shared.Logger;
using Unity.Mvc3;

namespace WebServices
{
    /// <summary>
    /// 
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here

            container.RegisterType<GlobalLogger>();
            container.RegisterType<IAdvertiseCarDetailsService, AdvertisedCarDetailService>();
            container.RegisterType<IOwnerValidationService, OwnerValidationService>();
            container.RegisterType<IOwnerService, OwnerService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IAdvertiseCarService, AdvertisedCarService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<ICarOwnerReferenceService, CarOwnerReferenceService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnquiryService, EnquiryService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}