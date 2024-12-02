using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [Phone(ErrorMessage = "Formato de telefone inválido.")]
        public string? Telefone { get; set; }

        // Relacionamento um para muitos com Locacao
        public List<Locacao> Locacoes { get; set; } = new List<Locacao>();
    }
}