using CondSys.Attributes;
using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Correspondencias
{
    public class CorrespondenciaDto
    {
        public int Id { get; set; }

        [Display(Name = "Data Chegada")]
        [Required(ErrorMessage = "Data de chegada é obrigatório")]
        [DataType(DataType.Date)]
        [DataTimeAttribute("DataEntrega")]
        public DateTime DataChegada { get; set; }
        public string DataHoraChegada { get { return DataChegada.ToString("dd/MM/yyyy HH:mm:ss"); } set { throw new InvalidOperationException(); } }

        [Display(Name = "Data Entrega")]
        [DataType(DataType.Date)]
        public DateTime? DataEntrega { get; set; }
        public string DataHoraEntrega { get { return DataEntrega?.ToString("dd/MM/yyyy HH:mm:ss"); } set { throw new InvalidOperationException(); } }


        [Display(Name = "Entregue")]
        public bool Entregue { get; set; }
        public string JaEntregue { get { return Entregue ? "Sim" : "Não"; } set { throw new InvalidOperationException(); } }
        [Display(Name = "Morador")]
        [Required(ErrorMessage = "Morador é obrigatório ")]
        public string MoradorNome { get; set; }
        public int MoradorId { get; set; }
        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }
        [Display(Name = "Folha")]
        public string Folha { get; set; }
        public TipoCorrespondencia Tipo { get; set; }
        [Display(Name = "Tipo")]
        public string TipoCorrespondencia { get { return Tipo.ObtemDescricao(); } set { throw new InvalidOperationException(); } }

        public int RecebidoPorId { get; set; }
        public string RecebidoPor { get; set; }
        public int? EntreguePorId { get; set; }
        public string EntreguePor { get; set; }
    }
}
