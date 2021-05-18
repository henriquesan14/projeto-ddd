using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ProjetoDDD.Domain.Interfaces;
using ProjetoDDD.Domain.Interfaces.Base;
using ProjetoDDD.Infra.Data.Repository;
using ProjetoDDD.Infra.Data.Repository.Base;
using ProjetoDDD.Service.Services;
using ProjetoDDD.Service.Services.Base;

namespace ProjetoDDD.Infra.CrossCutting.IOC
{
    public static class DependencyExtension
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            //Services
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
