using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int PlanoId { get; set; }

        #region Relacionamento
        public Plano Plano { get; set; }
        public List<Dependente> Dependentes { get; set; }
        #endregion
    }
}
