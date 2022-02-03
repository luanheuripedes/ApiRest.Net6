using Core.Exceptions;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : Base
    {
        //propriedades
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        //O Ef CRIA AS ENTIDADES ATRAVES DE UM CONSTRUTOR VAZIO E PROTEGIDO
        //NÃO É PUBLICO PQ QUALQUER PESSOA PODE CRIAR UMA ENTIDADE E PASSAR AS PROPRIEDADES,
        //POR ISSO ELA SO FICA ABERTA PRO EF
        protected Usuario() { }

        public Usuario(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            _errors = new List<string>(); // instanciado aqui para nao dar nullPointer na hora de criar o metodo validate

            Validate();
        }

        //Comportamentos
        public void MudaNome(string nome)
        {
            this.Nome = nome;
            Validate();
        }

        public void MudaEmail(string email)
        {
            this.Email = email;
            Validate();
        }

        public void MudaSenha(string senha)
        {
            this.Senha = senha;
            Validate();
        }

        //Auto valida
        public override bool Validate()
        {

            var validator = new UsuarioValidator(); //A classe que vai validar 
            var validation = validator.Validate(this);  //Resultado da validação //o this é pra mostrar que eu quero validar essa classe

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                }
                throw new DomainExceptions("Alguns campos estão invalidos: " , _errors);
            }

            return true;
        }
    }
}
