using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.CrossCutting;
using Projeto.Domain.Contracts.CrossCutting;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;
using ProjetoApplication.Contracts;
using ProjetoApplication.Services;

namespace Projeto.Presentation.Api
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
            services.AddControllers();

            #region Swagger
            //configurando a documentação da API gerada pelo swagger
            services.AddSwaggerGen(s =>
            {
                new OpenApiInfo
                {
                    Title = "API de controle de clientes e planos",
                    Version = "v1",
                    Description = "Sistema desenvolvido em NET CORE API com arquitetura DDD (Domain Driven Design)",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Url = new Uri("http://www.cotiinformatica.com.br"),
                        Email = "contato@cotiinformatica.com.br"
                    }
                };
            });

            #endregion

            #region EntityFrameworkCore
            services.AddDbContext<DataContext>(options=> 
                                    options.UseSqlServer(Configuration.GetConnectionString("ProjetoDDD")));
            #endregion

            #region Injeção de Dependencia

            services.AddTransient<IPlanoApplicationService, PlanoApplicationService>();
            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();
            services.AddTransient<IDependenteApplicationService, DependenteApplicationService>();
            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();

            services.AddTransient<IPlanoDomainService, PlanoDomainService>();
            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IDependenteDomainService, DependenteDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            services.AddTransient<IPlanoRepository, PlanoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IDependenteRepository, DependenteRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IMD5Cryptography, MD5Cryptography>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "apicoti"));

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
