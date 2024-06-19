using CondSys.Model.Correspondencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Home
{
    public class HomeDto
    {
        public HomeDto()
        {
            Avisos = new List<AvisosDto>();
            Correspondencias = new List<CorrespondenciaDto>();
        }
        public List<AvisosDto> Avisos { get; set; }
        public List<CorrespondenciaDto> Correspondencias { get; set; }
    }
}
