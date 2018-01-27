[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OneClick.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OneClick.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace OneClick.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Moq;
    using OneClick.Domain.Abstract;
    using OneClick.Domain._Entities;
    using OneClick.Domain.Concrete;
    using System.Collections.Generic;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEventRepository>(). To<EFEventRepository>();
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IAuthentication>().To<FormsAuthenticationProvider>();
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>();
            kernel.Bind<IUserAuthentication>().To<UserFormsAuthenticationProvider>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<INoteRepository>().To<EFNoteRepository>();
            
            //Mock<IEventRepository> mock = new Mock<IEventRepository>();
            //mock.Setup(m => m.Events).Returns(new List<Event>
            //{
            //    new Event { Name ="Football",Time = 12.30 },
            //    new Event { Name ="Surf" , Time = 12.00 },
            //    new Event { Name = "Running", Time = 1.00}
            //});
            //kernel.Bind <IEventRepository>().ToConstant(mock.Object);
        }        
    }
}
