using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.UH
{
    public class UnidadeDto
    {
        public int? UnidadeId { get; set; }
        [Display(Name ="Número")]
        public string Numero { get; set; }
        [Display(Name ="Localização")]
        public string Localizacao { get; set; }
        public string Bloco { get; set; }
        public string Andar { get; set; }
        public StatusUnidade Status { get; set; }
        [Display(Name ="Status")]
        public string StatusDesc { get; set; }
        [Display(Name ="Área Total")]
        public decimal AreaTotal { get; set; }
        [Display(Name = "Área Total Construída")]
        public decimal AreaTotalConstruida { get; set; }
        public List<MoradorDto> Moradores { get; set; }
    }
}
