using Api.ViewModels;
using AutoMapper;
using Domain.Entities;
using Services.DTO;

namespace Api.Configuration
{
    //Configuração do autoMapper
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<CreateUsuarioViewModel, UsuarioDTO>().ReverseMap();
        }
    }
}
