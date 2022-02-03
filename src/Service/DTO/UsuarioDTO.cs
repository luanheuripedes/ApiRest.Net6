using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    //Utilizado para fazer a comunicação com a API e Serviços. Poderia utilizar o Usuario da Domain
    //mas para não expola com os comportamentos utilizaremos essa classe para transferir os dados
    public class UsuarioDTO
    {
        public long id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get;  set; }

        public UsuarioDTO()
        {

        }

        public UsuarioDTO(long id, string nome, string email, string senha)
        {
            this.id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
