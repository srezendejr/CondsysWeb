using CondSys.Model.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Services
{
    public interface IConfiguracaoService
    {
        Task<Configuracao> BuscaConfiguracao();
        Task Salvar(Configuracao config);
    }
}
