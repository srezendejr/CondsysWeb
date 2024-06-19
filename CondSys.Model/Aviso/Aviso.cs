using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class Aviso
    {
        [Key]
        public int AvisoId { get; set; }
        public DateTime Data { get; set; }
        [StringLength(100)]
        public string Titulo { get; set; }
        [StringLength(5000)]
        public string Texto { get; set; }

        public virtual ICollection<AvisoMorador> Moradores { get; set; }
    }

    public class AvisoMorador
    {
        public int AvisoMoradorId { get; set; }
        public int MoradorId { get; set; }
        public int AvisoId { get; set; }
        public bool Lida { get; set; }

        public virtual Morador Morador { get; set; }
        public virtual Aviso Aviso { get; set; }
    }
}
