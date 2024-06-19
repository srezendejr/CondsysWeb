using CondSys.Model.UH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class Morador : Pessoa
    {
        public bool PermiteAutorizarPortaria { get; set; }
        public bool PermiteAutorizarVisitante { get; set; }
        public string NumeroCartao { get; set; }
        public int? UnidadeId { get; set; }
        public virtual Unidade Unidade { get; set; }
    }
}
