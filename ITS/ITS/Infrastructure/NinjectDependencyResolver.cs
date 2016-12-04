using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ITS.Domain.Entities;
using ITS.Domain.Concrete;
using ITS.Domain.Abstract;
using Ninject;

namespace ITS.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
    //        kernel.Bind<IUserStore<ApplicationUser>()
    //.To<UserStore<ApplicationUser>>()
    //.WithConstructorArgument(new ConstructorArgument("context", new ApplicationDbContext())

            //kernel.Bind<ApplicationDbContext>().ToSelf()
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<IIssueRepository>().To<EFIssueRepository>();
            kernel.Bind<IAttachmentChangeRepository>().To<EFAttachmentChangeRepository>();

            kernel.Bind<ICommentRepository>().To<EFCommentRepository>();

        }
    }
}