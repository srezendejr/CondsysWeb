using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class PessoaEndereco
    {
        [Key]
        public int PessoaEnderecoId { get; set; }
        [StringLength(100)]
        public string Endereco { get; set; }
        [StringLength(8)]
        public string Cep { get; set; }
        [StringLength(30)]
        public string Complemento { get; set; }
        [StringLength(30)]
        public string Bairro { get; set; }
        public string Nro { get; set; }
        public int CidadeId { get; set; }
        public int? PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
