﻿using System.Reflection;
using System.Web.Http;

using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

using Exam.Data;
using Exam.WebApi;
using Exam.WebApi.Infrastructure;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace Exam.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel)
               .UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);

            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IExamData>()
                  .To<ExamData>()
                  .WithConstructorArgument("context", c => new ExamDbContext());

            kernel.Bind<IUserIdProvider>().To<AspUserIDProvider>();
        }
    }
}
