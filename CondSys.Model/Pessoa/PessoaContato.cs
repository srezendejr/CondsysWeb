using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class PessoaContato
    {
        public int PessoaContatoId { get; set; }
        [StringLength(150)]
        public string Contato { get; set; }
        public TipoContato Tipo { get; set; }

        public int? PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
