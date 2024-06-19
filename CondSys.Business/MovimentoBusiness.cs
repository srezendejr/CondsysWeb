using CondSys.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondSys.Model.Visitante;
using CondSys.Data.Context;
using System.Data.Entity;
using CondSys.Enumerator;
using CondSys.Model;
using CondSys.Sender;

namespace CondSys.Business
{
    public class MovimentoBusiness : IMovimentoService
    {
        private ContextMySql _context;
        public MovimentoBusiness (ContextMySql context)
        {
            _context = context;
        }
        public async Task Salvar(Movimento Visitante)
        {
            if(Visitante.MovimentoId == 0)
            {
                _context.Salvar<Movimento>(Visitante);
            }
            else
            {
                _context.Alterar<Movimento>(Visitante);
            }
            await _context.Commit();
        }

        public async Task<List<Movimento>> VisitantesNoCondominio()
        {
            return await _context.Movimentos.Include(i => i.Morador).Include(i => i.Visitante).Where(a => a.DataHoraSaida == null || a.DataHoraSaida == DateTime.MinValue).OrderBy(a => a.DataHoraEntrada).AsNoTracking().ToListAsync();
        }

        public async Task<Movimento> BuscarMovimento(int id)
        {
            return await _context.Movimentos.Include(i => i.Morador).Include("Morador.Contatos").Include(i => i.Visitante).FirstOrDefaultAsync(f => f.MovimentoId == id);
        }

        public async Task MarcarSaidaVisitante(Movimento movimento)
        {
            _context.Alterar<Movimento>(movimento);
            await _context.Commit();
        }
    }
}
