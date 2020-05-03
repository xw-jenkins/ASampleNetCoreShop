﻿using ASample.NetCore.Extension;
using Autofac;
using Microsoft.Extensions.Configuration;


namespace ASample.NetCore.MailKit
{
    public static class Extension
    {
        public static void AddMailKit(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<MailKitOptions>("mailkit");

                return options;
            }).SingleInstance();
        }
    }
}
