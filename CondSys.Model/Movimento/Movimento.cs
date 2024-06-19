using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class Movimento
    {
        [Key]
        public int MovimentoId { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public string NroCartao { get; set; }
        public int MoradorId { get; set; }
        public int VisitanteId { get; set; }
        public string PlacaVeiculo { get; set; }
        public EnumTipoVisitante Tipo {get;set;}
        public virtual Morador Morador { get; set; }
        public virtual Visitante.Visitante Visitante { get; set; }
        
    }
}
