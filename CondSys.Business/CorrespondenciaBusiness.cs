using CondSys.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondSys.Data.Context;
using CondSys.Model.Correspondencias;
using System.Data.Entity;
using CondSys.Sender;

namespace CondSys.Business
{
    public class CorrespondenciaBusiness : ICorrespondenciaService
    {
        private readonly ContextMySql _context;
        public CorrespondenciaBusiness(ContextMySql context)
        {
            _context = context;
        }
        public async Task<Correspondencia> BuscarCorrespondencia(int CorrespondenciaId)
        {
            return await _context.Correspondencias.Include(i => i.Morador).FirstOrDefaultAsync(f => f.CorrespondenciaId == CorrespondenciaId);
        }

        public async Task<List<Correspondencia>> BuscarCorrespondencias()
        {
            return await _context.Correspondencias.Include(i => i.Morador).ToListAsync();
        }

        public async Task MarcarEntregue(int CorrespondenciaId)
        {
            var corresp = await this.BuscarCorrespondencia(CorrespondenciaId);
            corresp.DataEntrega = DateTime.Now;
            corresp.Entregue = true;
            _context.Alterar<Correspondencia>(corresp);
            await _context.Commit();
        }

        public async Task Salvar(Correspondencia Correspondencia)
        {
            if(Correspondencia.CorrespondenciaId == 0)
            {
                _context.Salvar<Correspondencia>(Correspondencia);
            }
            else
            {
                _context.Alterar<Correspondencia>(Correspondencia);
            }

            await _context.Commit();
        }
    }
}
