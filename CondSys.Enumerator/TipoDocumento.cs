using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Enumerator
{
    public enum TipoDocumento
    {
        [Description("CPF")]
        cpf = 1,
        [Description("CNPJ")]
        cnfpj = 2,
        [Description("RG")]
        rg = 3,
        [Description("Passaport")]
        passport = 4
    }
}
