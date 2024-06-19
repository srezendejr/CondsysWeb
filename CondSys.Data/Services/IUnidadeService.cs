using CondSys.Model.UH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CondSys.Data.Services
{
    public interface IUnidadeService
    {
        Task<List<Unidade>> List();
        Task Salvar(Unidade unidade);
        Task<Unidade> BuscarUnidade(int id);
        Task<Unidade> BuscarUnidade(string NroUnidade);
        Task AlterarStatus(int unidadeId, int status);
        Task ValidaNumeroUnidade(ModelStateDictionary modelState, string numero, int id);
    }
}
