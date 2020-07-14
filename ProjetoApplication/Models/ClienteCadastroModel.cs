using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoApplication.Models
{
    public class ClienteCadastroModel
    {
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }

        [StringLength(11, ErrorMessage = "Informe exatamente {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do plano.")]
        public int PlanoId { get; set; }
    }
}
