using Microsoft.Extensions.Configuration;
using SmtpWebService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpWebService.DependencyInjection
{
    public static class ContainerFactory
    {
        public static IContainer GetContainer(IConfiguration configuration)
        {
            return new GraceContainer(configuration);
        }
    }
}
