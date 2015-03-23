using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using KS.BestPractice.Cache.Infrastructure;
using KS.BestPractice.Controllers;

namespace KS.BestPractice.Cache.DI
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);

        
    }
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            //cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_static").SingleInstance();
            builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_per_request").InstancePerLifetimeScope();
            //
            builder.RegisterType<ProductController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));
        }
    }


}