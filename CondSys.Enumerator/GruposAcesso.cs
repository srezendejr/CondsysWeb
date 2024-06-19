using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Enumerator
{
    public enum GruposAcesso
    {
        [Description("Portaria")]
        Portaria = 1,

        [Description("Administração")]
        [Display(Name = "Administração")]
        Administracao = 2,

        [Description("Serviços")]
        [Display(Name = "Serviços")]
        Servico = 3,

        [Description("Moradores")]
        [Display(Name = "Moradores")]
        Morador = 4
    }
}
