using CondSys.Model;
using CondSys.Model.Visitante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Services
{
    public interface IMovimentoService
    {
        Task Salvar(Movimento Visitante);
        Task<List<Movimento>> VisitantesNoCondominio();
        Task MarcarSaidaVisitante(Movimento movimento);
        Task<Movimento> BuscarMovimento(int id);
    }
}
