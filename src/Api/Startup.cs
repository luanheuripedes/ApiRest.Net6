using Api.Configuration;
using Api.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.DTO;

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



            var secretKey = Configuration["Jwt:Key"];
            /*
            #region Jwt
            //Aqui vai a nossa key secreta, o recomendado é guarda-la no arquivo de configuração
            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x => // parte do aspNet
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion
            */

            services.ConfigurationJtw(secretKey);

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


            //Swagger
            /*
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
                
            });
            */

            services.SwaggerConfigurationGen();



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

            //Para o jwt autenticação e autorização
            app.UseAuthentication();
            app.UseHttpsRedirection();
            
            app.UseAuthorization();
            app.MapControllers();
            
        }

    }
}
