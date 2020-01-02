using SmtpWebService.Domain;
using Grace.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using SmtpWebService.Data.Services;
using SmtpWebService.Domain.Services;

namespace SmtpWebService.DependencyInjection
{
    public class GraceContainer : IContainer
    {
        private DependencyInjectionContainer _container;
        private readonly IConfiguration _configuration;

        internal GraceContainer(IConfiguration configuration)
        {
            _configuration = configuration;
            _container = ConfigureContainer(configuration);
        }

        private static DependencyInjectionContainer ConfigureContainer(IConfiguration configuration)
        {
            var container = new DependencyInjectionContainer();
            ConfigureContainer(container, configuration);
            return container;
        }

        public static void ConfigureContainer(IInjectionScope scope, IConfiguration configuration)
        {
            scope.Configure(c => c.ExportInstance(configuration).As<IConfiguration>());

            scope.Configure(c => c.Export<MailService>().As<IMailService>());
        }

        public T Get<T>()
        {
            return _container.Locate<T>();
        }

        public void Replace<I, T>()
        {
            _container.Dispose();
            _container = ConfigureContainer(_configuration);
            _container.Configure(c => c.Export<T>().As<I>());
        }

        public void Replace<T>(T instance)
        {
            _container.Dispose();
            _container = ConfigureContainer(_configuration);
            _container.Configure(c => c.ExportInstance(instance).As<T>());
        }

        public object GetService(Type serviceType)
        {
            return _container.Locate(serviceType);
        }
    }
}
