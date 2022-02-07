using Api.Token;
using Api.Utilities;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        public IActionResult Login([FromBody]LoginViewModel loginViewModel)
        {
            try
            {
                //Pega a senha e login de configuração, mas seria o usuario e senha do bd se fosse o caso
                //por isso esta fixo
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if (loginViewModel.Login == tokenLogin && loginViewModel.Password == tokenPassword)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, ResponsesErrors.UnauthorizedErrorMessage());
                }
            }
            catch (Exception)
            {

                return StatusCode(500, ResponsesErrors.ApplicationErrorMessage("Não Autorizado"));
            }
        }
    }
}
