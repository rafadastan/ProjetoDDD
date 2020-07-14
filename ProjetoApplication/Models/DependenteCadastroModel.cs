using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoApplication.Models
{
    public class DependenteCadastroModel
    {
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do dependente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do dependente.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sexo do dependente.")]
        [RegularExpression("^[MF]{1}$", ErrorMessage = "Informe somente 'M' ou 'F'.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]
        public int ClienteId { get; set; }
    }
}
