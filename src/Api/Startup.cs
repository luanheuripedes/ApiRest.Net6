using Api.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Services.DTO;
using Services.Interfaces;
using Services.Services;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using Api.Configuration;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //Relacionado ao Banco
            services.AddSingleton(d => Configuration);
            services.AddDbContext<ManagerContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection"), ServerVersion.AutoDetect(Configuration.GetConnectionString("MySqlConnection")));
            });
            

            services.AddControllers();

            
            //Configuração do autoMaPPER
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDTO>().ReverseMap();
                cfg.CreateMap<CreateUsuarioViewModel, UsuarioDTO>().ReverseMap();
                cfg.CreateMap<UpdateUsuarioViewModel, UsuarioDTO>().ReverseMap();
            });
            

            services.AddSingleton(autoMapperConfig.CreateMapper());
            //FIM




            services.AddEndpointsApiExplorer();

            /*
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
                
            });
            */
            services.AddSwaggerGen();
            services.ResolveDependencies();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseAuthorization();
            app.MapControllers();
        }

    }
}
