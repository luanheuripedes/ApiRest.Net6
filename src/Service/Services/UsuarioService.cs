using AutoMapper;
using Core.Exceptions;
using Domain.Entities;
using Infrastructure.Interfaces;
using Services.DTO;
using Services.Interfaces;

namespace Services.Services
{
    //Onde esta as regras de negocio
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }


        public async Task<UsuarioDTO> Create(UsuarioDTO usuarioDTO)
        {
            var usuarioExists = await _usuarioRepository.GetByEmail(usuarioDTO.Email);

            if(usuarioExists != null)
            {
                throw new DomainExceptions("Já existe um úsuario cadastrado com o email informado.");
            }

            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            usuario.Validate();

            var usuarioCriado = await _usuarioRepository.Create(usuario);

            return _mapper.Map<UsuarioDTO>(usuarioCriado);
        }

        public async Task<UsuarioDTO> Update(UsuarioDTO usuarioDTO)
        {
            var usuarioExiste = await _usuarioRepository.Get(usuarioDTO.id);

            if(usuarioExiste == null)
            {
                throw new DomainExceptions("Não existe nenhum usuario com o id Informado");
            }

            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            usuario.Validate();

            var usuarioAtualizado = await _usuarioRepository.Update(usuario);

            return _mapper.Map<UsuarioDTO>(usuarioAtualizado);
        }

        public async Task Remove(long id)
        {
            await _usuarioRepository.Remove(id);
        }

        public async Task<UsuarioDTO> Get(long id)
        {
            var usuarioExiste = await _usuarioRepository.Get(id);

            if (usuarioExiste == null)
            {
                throw new DomainExceptions("Não existe nenhum usuario com o id Informado");
            }


            var usuario = _mapper.Map<UsuarioDTO>(usuarioExiste);

            return usuario;
        }


        public async Task<List<UsuarioDTO>> GetAll()
        {
            var todosUsuarios = _usuarioRepository.GetAll();

            var usuariosDto = _mapper.Map<List<UsuarioDTO>>(todosUsuarios);

            return usuariosDto;
        }

        public async Task<UsuarioDTO> GetByEmail(string email)
        {
            var usuarioEmail = _usuarioRepository.GetByEmail(email);

            if(usuarioEmail == null)
            {
                throw new DomainExceptions("Não existe nenhum usuario cadastrado com esse email");
            }

            var userEmailDTO = _mapper.Map<UsuarioDTO>(usuarioEmail);

            return userEmailDTO;
        }

        

        public async Task<List<UsuarioDTO>> SearchByEmail(string email)
        {
            var usuariosEmail = _usuarioRepository.SearchByEmail(email);

            var usuariosEmailDTO = _mapper.Map<List<UsuarioDTO>>(usuariosEmail);

            return usuariosEmailDTO;
        }

        public async Task<List<UsuarioDTO>> SearchByName(string name)
        {
            var usuariosNome = _usuarioRepository.SearchByName(name);

            var usuariosNomeDTO = _mapper.Map<List<UsuarioDTO>>(usuariosNome);

            return usuariosNomeDTO;
        }

        
    }
}
