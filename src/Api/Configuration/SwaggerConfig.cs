using Microsoft.OpenApi.Models;

namespace Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection SwaggerConfigurationGen(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Manager API",
                    Version = "v1",
                    Description = "API construída na serie de vídeos no canal Lucas Eschechola.",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Eschechola",
                        Email = "lucas.gabriel@eu.com",
                        Url = new Uri("https://eschechola.com.br")
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            return services;

            //FIM
        }

    }
}
