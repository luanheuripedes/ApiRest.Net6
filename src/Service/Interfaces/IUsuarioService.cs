using Services.DTO;

namespace Services.Interfaces
{
    //Todos usam UsuarioDTO, pq eu nao quero que API tenha conhecimento sobre minhas entidades de Dominio
    //quem tem que manipular as regras de negocio é a camada de serviço
    //por isso que a comunicação entre a Api e serviços e´feita com DTO
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Create(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Update(UsuarioDTO usuarioDTO);
        Task Remove(long id);
        Task<UsuarioDTO> Get(long id);
        Task<List<UsuarioDTO>> GetAll();

        Task<List<UsuarioDTO>> SearchByName(string name);
        Task<List<UsuarioDTO>> SearchByEmail(string email);
        Task<UsuarioDTO> GetByEmail(string email);
    }
}
