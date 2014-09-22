using MVCDevTools.Models;
using MVCDevTools.Models.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCDevTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.Kernel = kernel;
            this.AddBindings();
        }

        private IKernel Kernel
        {
            get
            {
                return this.kernel;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Kernel value cannot be null.");
                }

                this.kernel = value;
            }
        }

        private void AddBindings()
        {
            this.Kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }

        public object GetService(Type serviceType)
        {
            var result = this.Kernel.TryGet(serviceType);
            return result;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var result = this.Kernel.GetAll(serviceType);
            return result;
        }
    }
}