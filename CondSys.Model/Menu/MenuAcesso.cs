using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Menu
{
    public class MenuAcesso
    {
        public int MenuAcessoId { get; set; }
        public int MenuId { get; set; }
        public GruposAcesso GrupoAcesso { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
