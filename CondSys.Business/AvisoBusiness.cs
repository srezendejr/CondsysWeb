using CondSys.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondSys.Model;
using CondSys.Data.Context;
using System.Data.Entity;

namespace CondSys.Business
{
    public class AvisoBusiness : IAvisoService
    {
        private ContextMySql _context;

        public AvisoBusiness(ContextMySql context)
        {
            _context = context;
        }

        public async Task<Aviso> BuscarAviso(int AvisoId)
        {
            return await _context.Avisos.FirstOrDefaultAsync(f => f.AvisoId == AvisoId);
        }

        public async Task<List<Aviso>> BuscarAvisos()
        {
            return await _context.Avisos.ToListAsync();
        }

        public async Task MarcarComoLido(int AvisoId, int MoradorId)
        {
            var not = await this.BuscarAviso(AvisoId);
            var lido = not.Moradores.FirstOrDefault(a => a.MoradorId == MoradorId);
            lido.Lida = true;
            _context.Alterar<AvisoMorador>(lido);
            await _context.Commit();
        }

        public async Task Salvar(Aviso Aviso, List<AvisoMorador> Moradores)
        {
            if(Aviso.AvisoId == 0)
            {
                _context.Salvar<Aviso>(Aviso);
                Moradores.ForEach(f => _context.Salvar<AvisoMorador>(f));
            }
            else
            {
                _context.Alterar<Aviso>(Aviso);
            }
            
            await _context.Commit();
        }
    }
}
