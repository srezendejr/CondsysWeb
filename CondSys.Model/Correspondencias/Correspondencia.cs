using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Correspondencias
{
    public class Correspondencia
    {
        [Key]
        public int CorrespondenciaId { get; set; }
        [Required(ErrorMessage ="Informe a data de chegada")]
        public DateTime DataChegada { get; set; }
        public DateTime? DataEntrega { get; set; }
        public TipoCorrespondencia Tipo { get; set; }
        [StringLength(100)]
        public string Mensagem { get; set; }
        [StringLength(30)]
        public string Folha { get; set; }
        public bool Entregue { get; set; }
        public int MoradorId { get; set; }
        public virtual Morador Morador { get; set; }
        public int? UsuarioRecebimentoId { get; set; }
        public Usuario UsuarioRecebimento { get; set; }
        public int? UsuarioEntregaId { get; set; }
        public Usuario UsuarioEntrega { get; set; }
    }
}
