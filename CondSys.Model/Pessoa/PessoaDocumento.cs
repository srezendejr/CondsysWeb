using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class PessoaDocumento
    {
        [Key]
        public int PessoaDocumentoId { get; set; }
        public string Documento { get; set; }
        public TipoDocumento Tipo { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
