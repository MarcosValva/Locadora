using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Diretor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo {1} caracteres.")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Diretor), "ValidarDataNascimento")]
        public DateTime DataNascimento { get; set; }

        public string? Nacionalidade { get; set; }

        public ICollection<Filme>? Filmes { get; set; }
        public static ValidationResult ValidarDataNascimento(DateTime dataNascimento, ValidationContext context)
        {
            // Definir a data limite de 31/12/1999
            DateTime dataLimite = new DateTime(1999, 12, 31);

            if (dataNascimento > dataLimite)
            {
                return new ValidationResult("A data de nascimento não pode ser posterior a 31/12/1999.");
            }

            return ValidationResult.Success;
        }
    }
}

