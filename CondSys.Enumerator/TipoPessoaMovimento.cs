using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Enumerator
{
    public enum TipoPessoaMovimento
    {
        [Description("Morador")]
        Morador = 1,

        [Description("Visitante")]
        Visitante = 2,

        [Description("Locatário")]
        Locatario = 3,

        [Description("Prestador de Serviço")]
        [Display(Name = "Prestador de Serviço")]
        PrestadorServico = 4,

        [Description("Proprietário")]
        [Display(Name = "Proprietário")]
        Proprietario = 5,
    }
}
