using Business.Abstracts;
using Business.Contretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concreates;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistiration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services) //Extension yazımı
        {
            services.AddSingleton<MarketAppContext>();
            services.AddSingleton<IUserDal, EfUserDal>();
            //services.AddSingleton<BrandBusinessRules>();
            services.AddSingleton<IUserService, UserService>();

            services.AddSingleton<IShoppingCartDal, ShoppingCartDal>();
            //services.AddSingleton<BrandBusinessRules>();
            services.AddSingleton<IShoppingCartService, ShoppingCartService>();
            /*  services.AddAutoMapper(assemblies: AppDomain.CurrentDomain.GetAssemblies());*/ //Services, .NET'e ait.
                                                                                               //AddAutoMapper'ın gelmesi : Extensions.
                                                                                               //.NET'e ait değil, sonradan ekleniyor.

            return services;
        }
    }
}

