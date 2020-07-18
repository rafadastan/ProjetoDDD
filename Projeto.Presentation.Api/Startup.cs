using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Projeto.CrossCutting;
using Projeto.Domain.Contracts.CrossCutting;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Api.Authorization;
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
                s.SwaggerDoc("v1", new OpenApiInfo
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
                });

                //configuração para realizar o envio do TOKEN atraves do SWAGGER
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = ""
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
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

            #region JWT
            //injeção de dependência da classe JwtSettings
            var settingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(settingsSection);

            //obtendo a chave secreta para criação do TOKEN
            var jwtSettings = settingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

            //configurando o projeto para usar o framework JWT
            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new JwtConfiguration(jwtSettings));
            #endregion

            #region CORS
            services.AddCors(s => s.AddPolicy("DefaultPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));
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
            #region CORS
            app.UseCors("DefaultPolicy");
            #endregion

            app.UseAuthentication();
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
