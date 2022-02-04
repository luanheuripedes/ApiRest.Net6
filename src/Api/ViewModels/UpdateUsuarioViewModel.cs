using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    
    public class UpdateUsuarioViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser menor que 1")]
        public int Id { get; set; }


        [Required(ErrorMessage = "O Nome não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O Nome deve ter no maximo 80 caracteres.")]
        public string Nome { get;  set; }

        [Required(ErrorMessage = "O Email não pode ser vazio")]
        [MinLength(10, ErrorMessage = "O Email deve ter no minimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no maximo 180 carateres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O email informado não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser vazia")]
        [MinLength(6, ErrorMessage = "A Senha deve ter no minimo 6 caracteres")]
        [MaxLength(30, ErrorMessage = "O Senha deve ter no maximo 30 caracteres.")]
        public string Senha { get; set; }
    }
}
