using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace ContactManagement
{
    public class UnityResolver : IDependencyResolver 
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer unityContainer)
        {
            this.container = unityContainer;
        }
        
        public IDependencyScope BeginScope()
        {
            try
            {
                var child = container.CreateChildContainer();
                return new UnityResolver(child);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                container.Dispose();
            }
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}