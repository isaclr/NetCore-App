using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using NetCore.Dominio.Entidades;
using NetCore.Dados.Repositorios.Interfaces;
using NetCore.Dados.Repositorios;
using NetCore.Dados.UnitOfWork.Interfaces;
using NetCore.Dados.UnitOfWork;

namespace NetCore.UI.AspNetCore
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = @"Server=(localdb)\mssqllocaldb;Database=NetCore.ContextoDB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ContextoDB>(options => options.UseSqlServer(connection));

            services.AddScoped<IRepositorio<Categoria>, Repositorio<Categoria>>();
            services.AddScoped<IRepositorio<Cliente>, Repositorio<Cliente>>();
            //services.AddScoped<IRepositorio<Cliente>, ClienteRepositorio >();            
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();



            services.AddScoped<IUnitOfWork, UnitOfWork >();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
