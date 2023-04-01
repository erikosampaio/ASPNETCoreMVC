using Site01.Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Models
{
    public class Palavra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres!")]
        [UnicoNomePalavra]
        public string Nome { get; set; }

        // 1 - Fácil, 2 - Médio, 3 - Difícil
        public byte? Nivel { get; set; }
    }
}
