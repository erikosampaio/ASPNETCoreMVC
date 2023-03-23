using System.ComponentModel.DataAnnotations;

namespace Site01.Models
{
    public class Contato
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres!")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres!")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres!")]
        public string Mensagem { get; set; }
    }
}
