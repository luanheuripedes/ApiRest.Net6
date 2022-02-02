using Domain.Entities;
using FluentValidation;


namespace Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            //Validação Para a entidade
            RuleFor(x => x)
                    .NotEmpty()
                    .WithMessage("A entidaade não pode ser vazia.")

                    .NotNull()
                    .WithMessage("A entidade não pode ser nula.");

            //Validação para o nome
            RuleFor(x => x.Nome)
                    .NotNull()
                    .WithMessage("O Nome não pode ser nulo.")

                    .NotEmpty()
                    .WithMessage("O Nome não pode ser vazio")

                    .MinimumLength(3)
                    .WithMessage("O Nome deve ter no mínimo 3 caracteres.")

                    .MaximumLength(80)
                    .WithMessage("O Nome deve ter no maximo 80 caracteres.");

            //Validação para o email
            RuleFor(x => x.Email)
                    .NotNull()
                    .WithMessage("O Email não pode ser nulo.")

                    .NotEmpty()
                    .WithMessage("O Email não pode ser vazio")

                    .MinimumLength(10)
                    .WithMessage("O Email deve ter no minimo 10 caracteres.")

                    .MaximumLength(180)
                    .WithMessage("O Email deve ter no maximo 180 carateres.")

                    //Epressão regular(regex) pra validar se é um email valido
                    .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") 
                    .WithMessage("O Email informado não é valido");

            //Validação para a senha
            RuleFor(x => x.Senha)
                    .NotNull()
                    .WithMessage("A Senha não pode ser nula.")

                    .NotEmpty()
                    .WithMessage("A Senha não pode ser vazia")

                    .MinimumLength(6)
                    .WithMessage("A Senha deve ter no minimo 6 caracteres")

                    .MaximumLength(30)
                    .WithMessage("O Senha deve ter no maximo 30 caracteres.");

        }
    }
}
