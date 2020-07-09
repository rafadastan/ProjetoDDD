using Projeto.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain
{
    public class Dependente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public int ClienteId { get; set; }

        #region Relacionamento
        public Cliente Cliente { get; set; }

        #endregion

    }
}
