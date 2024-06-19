using CondSys.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondSys.Model.UH;
using CondSys.Data.Context;
using System.Data.Entity;
using System.Web.Mvc;

namespace CondSys.Business
{
    public class UnidadeBusiness : IUnidadeService
    {
        private readonly ContextMySql _context;
        public UnidadeBusiness(ContextMySql context)
        {
            _context = context;
        }
        public async Task<List<Unidade>> List()
        {
            return await _context.Unidades.ToListAsync();
        }

        private async Task<bool> VerificaExisteUnidade(string numero, int id)
        {
            return await _context.Unidades.AnyAsync(a => a.Numero == numero && a.UnidadeId != id);
        }

        public async Task Salvar(Unidade unidade)
        {
            if (unidade.UnidadeId == 0)
                _context.Salvar<Unidade>(unidade);
            else
                _context.Alterar<Unidade>(unidade);

            await _context.Commit();
        }

        public async Task<Unidade> BuscarUnidade(int id)
        {
            var unidade = await _context.Unidades.Include(i => i.Moradores).FirstOrDefaultAsync(f => f.UnidadeId == id);
            return unidade;
        }

        public async Task AlterarStatus(int unidadeId, int status)
        {
            var unidade = await this.BuscarUnidade(unidadeId);
            unidade.Status = (Enumerator.StatusUnidade)status;
            _context.Alterar(unidade);
            await _context.Commit();

        }

        public async Task<Unidade> BuscarUnidade(string NroUnidade)
        {
            var unidade = await _context.Unidades.FirstOrDefaultAsync(f => f.Numero == NroUnidade);
            return unidade;
        }

        public async Task ValidaNumeroUnidade(ModelStateDictionary modelState, string numero, int id)
        {
            if(string.IsNullOrEmpty(numero))
                modelState.AddModelError("Numero", "Informe o número da unidade");

            bool existeUnidade = await VerificaExisteUnidade(numero, id);
            if(existeUnidade)
            {
                modelState.AddModelError("Numero", "Já existe uma unidade com esse código");
            }
        }
    }
}
