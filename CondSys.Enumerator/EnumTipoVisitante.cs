using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Enumerator
{
    public enum EnumTipoVisitante
    {
        [Description("Visitante")]
        Visitante = 1,

        [Description("Prestador Serviço")]
        [Display(Name = "Prestador de Serviço")]
        PrestadorServico = 2,

        [Description("Outros")]
        Outros = 3
    }
}
