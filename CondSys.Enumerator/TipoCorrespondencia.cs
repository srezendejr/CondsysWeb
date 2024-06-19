using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Enumerator
{
    public enum TipoCorrespondencia
    {
        [Description("Sedex")]
        Sedex = 0,

        [Description("Carta Registrada")]
        [Display(Name ="Carta Registrada")]
        CartaRegistrada =1,

        [Description("Carta Simples")]
        [Display(Name = "Carta Simples")]
        CartaSimples = 2,

        [Description("Encomenda")]
        Encomenda = 3,

        [Description("Outros")]
        Outros = 4
    }
}
