using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.UH
{
    public class Unidade
    {
        [Key]
        public int UnidadeId { get; set; }
        public string Numero { get; set; }
        public string Localizacao { get; set; }
        [StringLength(10)]
        public string Bloco { get; set; }
        [StringLength(10)]
        public string Andar { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal AreaTotalConstruida { get; set; }
        public StatusUnidade Status { get; set; }
        public virtual ICollection<Morador> Moradores { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
