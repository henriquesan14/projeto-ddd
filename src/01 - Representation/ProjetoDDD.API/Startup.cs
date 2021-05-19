using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoDDD.Application.AutoMapper;
using ProjetoDDD.Infra.CrossCutting.IOC;
using ProjetoDDD.Infra.Data.Context;

namespace ProjetoDDD.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlServerDbContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DbConnection")), ServiceLifetime.Singleton);

            
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserMapper>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);


            services.ResolveDependencies();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoDDD API", Version = "v1" });
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoDDD API V1");
            });
        }
    }
}
