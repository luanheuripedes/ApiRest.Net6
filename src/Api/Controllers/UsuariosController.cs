using Api.Utilities;
using Api.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;

namespace Api.Controllers
{
    //O cara que recebe a requisição e vai mandando para a outras camadas fazerem o serviço
    //A porta de entrada

    [ApiController]
    public class UsuariosController:ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/usuarios/create")] //v1 e´a versão do controller, caso precise passar parametros novos ou coisas do tipo a gente versiona a rota
        public async Task<IActionResult> Create([FromBody] CreateUsuarioViewModel userViewModel) //[FromBody] vem do corpo da requisição
        {
            try
            {
                var usuarioDTO = _mapper.Map<UsuarioDTO>(userViewModel);

                var usuarioCriado = await _usuarioService.Create(usuarioDTO);

                //return Ok();
                return Ok(ResponsesEntitys.Success("Teste", usuarioDTO));
            }
            catch (DomainExceptions ex) //validação de dominio
            {
                return BadRequest(ResponsesErrors.DomainErrorMessage(ex.Message,ex.Erros));
                
            }
            catch (Exception e)
            {
                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage(e.Message));
            }

            
        }

        [HttpPut]
        [Route("/api/v1/usuarios/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioViewModel userViewModel)
        {
            try
            {
                var usuarioDto = _mapper.Map<UsuarioDTO>(userViewModel);

                var usuarioCriado = await _usuarioService.Update(usuarioDto);

                return Ok(ResponsesEntitys.Success("Usuario atualizado com sucesso", usuarioCriado));

            }
            catch (DomainExceptions ex)
            {

                return BadRequest(ResponsesErrors.DomainErrorMessage(ex.Message));
            }
            catch (Exception e)
            {

                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage(e.Message));
            }
        }

        [HttpDelete]
        [Route("/api/v1/usuarios/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _usuarioService.Remove(id);

                return Ok(ResponsesEntitys.Success("Usuario atualizado com sucesso"));
            }
            catch (DomainExceptions ex) //validação de dominio
            {
                return BadRequest(ResponsesErrors.DomainErrorMessage(ex.Message, ex.Erros));

            }
            catch (Exception e)
            {
                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage(e.Message));
            }
        }

        [HttpGet]
        [Route("/api/v1/usuarios/get/id")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var usuario = await _usuarioService.Get(id);

                if(usuario == null)
                {
                    return Ok(ResponsesEntitys.SuccessGet("Nenhum usuario foi encontrado", usuario));
                }

                return Ok(ResponsesEntitys.Success("Usuario encontrado", usuario));
            }
            catch (DomainExceptions ex) //validação de dominio
            {
                return BadRequest(ResponsesErrors.DomainErrorMessage(ex.Message, ex.Erros));

            }
            catch (Exception e)
            {
                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage(e.Message));
            }
        }

        [HttpGet]
        [Route("/api/v1/usuarios/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allUsuario = await _usuarioService.GetAll();

                return Ok(ResponsesEntitys.Success("Usuarios encontrados com sucesso", allUsuario));
          
            }
            catch (DomainExceptions ex) //validação de dominio
            {
                return BadRequest(ResponsesErrors.DomainErrorMessage(ex.Message, ex.Erros));

            }
            catch (Exception e)
            {
                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage(e.Message));
            }
        }

        [HttpGet]
        [Route("/api/v1/usuarios/get-by-email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var usuario = await _usuarioService.GetByEmail(email);

                if (usuario == null)
                {
                    return Ok(ResponsesEntitys.SuccessGet("Nenhum usuario foi encontrado", usuario));
                }
                return Ok(ResponsesEntitys.Success("Usuarios encontrados com sucesso", usuario));

            }
            catch (DomainExceptions ex) //validação de dominio
            {
                return BadRequest(ResponsesErrors.DomainErrorMessage(ex.Message, ex.Erros));

            }
            catch (Exception e)
            {
                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage(e.Message));
            }
        }
        [HttpGet]
        [Route("/api/v1/usuarios/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _usuarioService.SearchByName(name);

                if (allUsers == null)
                {
                    return Ok(ResponsesEntitys.SuccessGet("Nenhum usuario foi encontrado", allUsers));
                }
                return Ok(ResponsesEntitys.Success("Usuarios encontrados com sucesso", allUsers));

            }
            catch (DomainExceptions ex) //validação de dominio
            {
                return BadRequest(ResponsesErrors.DomainErrorMessage(ex.Message, ex.Erros));

            }
            catch (Exception e)
            {
                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage(e.Message));
            }
        }



        /*
        [HttpGet]
        [Route("/api/v1/usuario")]
        public async Task<>
        */
    }
}
