using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class AvisosDto
    {
        public int AvisoId { get; set; }

        [Display(Name = "Data")]
        [Required]
        public DateTime Data { get; set; }
        public string DataHoraAviso { get { return Data.ToString("dd/MM/yyyy HH:mm:ss"); } set { throw new InvalidOperationException(); } }

        [Display(Name = "Título")]
        [Required]
        public string Titulo { get; set; }
        
        public string Mensagem { get; set; }

        public bool Lido { get; set; }

        public int? PessoaId { get; set; }
    }
}
