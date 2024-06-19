using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;
using System.Web.Routing;
using CondSys.IoC;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http;

namespace CondSys.Web
{
    public class StructuremapDependencyResolver : IDependencyResolver
    {

        private readonly IContainer _container;

        public StructuremapDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null) return null;
            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                         ? _container.TryGetInstance(serviceType)
                         : _container.GetInstance(serviceType);
            }
            catch
            {

                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                return controllerType == null
                           ? base.GetControllerInstance(requestContext, null)
                           : StructureMapContainer.Container.GetInstance(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
        }
    }

    public class ServiceActivator : IHttpControllerActivator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var type = controllerDescriptor.ControllerType;
            if (type.BaseType != typeof(ApiController))
                throw new InvalidOperationException("Invalid API Controller");

            var controller = StructureMapContainer.Container.GetInstance(controllerType) as IHttpController;
            return controller;
        }
    }
}