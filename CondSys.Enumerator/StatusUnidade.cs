using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Enumerator
{
    public enum StatusUnidade
    {
        [Description("Ocupada")]
        Ocupada = 0,
        [Description("Desocupada")]
        Desocupada = 1,
        [Description("Em Obra")]
        [Display(Name = "Em Obra")]
        EmConstrucao = 2
    }
}
