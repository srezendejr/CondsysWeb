using CondSys.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondSys.Model.Configuracao;
using CondSys.Data.Context;
using System.Data.Entity;

namespace CondSys.Business
{
    public class ConfiguracaoBusiness : IConfiguracaoService
    {
        private ContextMySql _context;
        public ConfiguracaoBusiness(ContextMySql context)
        {
            _context = context;
        }
        public async Task<Configuracao> BuscaConfiguracao()
        {
            return await _context.Configuracoes.FirstOrDefaultAsync();
        }

        public async Task Salvar(Configuracao config)
        {
            if (config.ConfiguracaoId == 0)
                _context.Salvar<Configuracao>(config);
            else
                _context.Alterar<Configuracao>(config);

            await _context.Commit();
        }
    }
}
