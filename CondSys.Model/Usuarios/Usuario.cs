using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public GruposAcesso GrupoAcesso { get; set; }
        public bool Ativo { get; set; }
        public bool AlterarSenha { get; set; }
        public int? PessoaId { get; set; }
        public virtual Morador Morador { get; set; }
    }
}
