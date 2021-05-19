using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Application.Interfaces.Base;
using ProjetoDDD.Application.Services;
using ProjetoDDD.Application.Services.Base;
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

            //Applications
            services.AddScoped(typeof(IBaseApplication<,,>), typeof(BaseApplication<,,>));
            services.AddTransient<IUserApplication, UserApplication>();

            return services;
        }
    }
}
