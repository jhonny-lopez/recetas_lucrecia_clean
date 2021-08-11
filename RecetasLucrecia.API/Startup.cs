using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RecetasLucrecia.Application.Contracts.Persistance;
using RecetasLucrecia.Application.Employees.UseCases.CreateEmployee;
using RecetasLucrecia.Application.Employees.UseCases.GetEmployeeById;
using RecetasLucrecia.Persistance;
using RecetasLucrecia.Persistance.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasLucrecia.API
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
            services.AddDbContext<RecetasLucreciaDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RecetasLucrecia"))
            );

            services.AddScoped(typeof(IRecetasLucreciaDatabaseContext), typeof(RecetasLucreciaDatabaseContext));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient(typeof(CreateEmployeeUseCase), typeof(CreateEmployeeUseCase));
            services.AddTransient(typeof(GetEmployeeByIdUseCase), typeof(GetEmployeeByIdUseCase));

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
        }
    }
}
