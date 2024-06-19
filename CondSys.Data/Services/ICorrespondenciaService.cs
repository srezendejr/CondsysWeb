using CondSys.Model.Correspondencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Services
{
    public interface ICorrespondenciaService
    {
        Task<List<Correspondencia>> BuscarCorrespondencias();
        Task<Correspondencia> BuscarCorrespondencia(int CorrespondenciaId);
        Task Salvar(Correspondencia Correspondencia);
        Task MarcarEntregue(int CorrespondenciaId);
    }
}
