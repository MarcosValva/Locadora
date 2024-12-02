using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Models
{
    public class Locacao
    {
        [Key]
        public int LocacaoId { get; set; } // Chave primária

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        [ForeignKey("Cliente")] // Define ClienteId como chave estrangeira
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O Filme é obrigatório.")]
        [ForeignKey("Filme")] // Define FilmeId como chave estrangeira
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "A data de locação é obrigatória.")]
        [Display(Name = "Data de Locação")]
        [DataType(DataType.Date)]
        public DateTime DataLocacao { get; set; }

        [Required(ErrorMessage = "A data de devolução é obrigatória.")]
        [Display(Name = "Data de Devolução")]
        [DataType(DataType.Date)]
        public DateTime DataDevolucao { get; set; }

        [NotMapped] // Não será persistido no banco diretamente
        public decimal ValorFilme { get; set; }

        // Propriedades de navegação
        public Cliente? Cliente { get; set; }
        public Filme? Filme { get; set; }
    }
}
