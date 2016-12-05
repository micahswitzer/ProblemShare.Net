using System;

using Ninject;
using Ninject.Modules;

using ProblemShare.Web.Interface;

namespace ProblemShare.Web.Business
{
    public class BusinessIoCModule : INinjectModule
    {
        private IKernel _kernel;

        public IKernel Kernel
        {
            get
            {
                return _kernel;
            }
        }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public void OnLoad(IKernel kernel)
        {
            _kernel = kernel;
            _kernel.Bind<IDocumentBO>().To(typeof(DocumentBO));
        }

        public void OnUnload(IKernel kernel)
        {
            _kernel = kernel;
            _kernel.Unbind<IDocumentBO>();
            _kernel = null;
        }

        public void OnVerifyRequiredModules()
        {
            
        }
    }
}
