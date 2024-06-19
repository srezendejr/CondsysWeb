using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Visitante
{
    public class VisitanteDto
    {
        public int VisitanteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Foto { get; set; }
        public TipoDocumento Tipo { get; set; }
        [NotMapped]
        public string TipoDocumento => Tipo.ObtemDescricao();
    }
}
