using Site01.Database;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Validation
{
    public class UnicoNomePalavraAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Palavra palavra = validationContext.ObjectInstance as Palavra;
            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));

            // Verificar se já existe no banco 1 registro
            // - Verificar se nome existe
            // - Verificar se Id é o mesmo do registro no banco

            var PalavraBanco = _db.Palavras.Where(a => a.Nome.ToLower() == palavra.Nome.ToLower() && a.Id != palavra.Id).FirstOrDefault();

            if (PalavraBanco == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A palavra '" + palavra.Nome + "' já foi cadastrada!");
            }
        }
    }
}
