using Ninject;
using Ninject.Modules;
using ProblemShare.Web.Entities;
using ProblemShare.Web.Interface;

namespace ProblemShare.Web.Business
{
    public class BusinessIoCModule : INinjectModule
    {
        public IKernel Kernel { get; private set; }

        public string Name => this.GetType().Name;

        public void OnLoad(IKernel kernel)
        {
            Kernel = kernel;
            Kernel.Bind<IFileManagerBO>().To(typeof(LocalFileManagerBO));
            Kernel.Bind<IInstitutionBO>().To(typeof(InstitutionBO));
            Kernel.Bind<IDocumentBO>().To(typeof(DocumentBO));
            Kernel.Bind<IProblemBO>().To(typeof(ProblemBO));
            Kernel.Bind<IUserBO>().To(typeof(UserBO));
        }

        public void OnUnload(IKernel kernel)
        {
            Kernel = kernel;
            Kernel.Unbind<IFileManagerBO>();
            Kernel.Unbind<IInstitutionBO>();
            Kernel.Unbind<IDocumentBO>();
            Kernel.Unbind<IProblemBO>();
            Kernel.Unbind<IUserBO>();
            Kernel = null;
        }

        public void OnVerifyRequiredModules()
        {
            
        }
    }

    public static class Context
    {
        public static PSContext Get() => new PSContext("ProblemShareDB");
    }
}
