using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Models
{
    public class Filme
    {
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "Título é obrigatório.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Gênero é obrigatório.")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Ano de Lançamento é obrigatório.")]
        [Display(Name = "Ano de Lançamento")]
        [Range(1888, int.MaxValue, ErrorMessage = "Ano de Lançamento deve ser um ano válido.")]
        public int AnoLancamento { get; set; }

        [Required(ErrorMessage = "O Diretor é obrigatório.")]
        [ForeignKey("Diretor")] // Define DiretorId como chave estrangeira
        public int DiretorId { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        [Display(Name = "Preço")]
        public decimal? Preco {  get; set; }

        // Relacionamento muitos para muitos com Locacao
        public List<Locacao> Locacoes { get; set; } = new List<Locacao>();

        public Diretor? Diretor { get; set; }
    }
}
