using CondSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Services
{
    public interface IAvisoService
    {
        Task Salvar(Aviso Aviso, List<AvisoMorador> Moradores);
        Task<Aviso> BuscarAviso(int NotificacaoId);
        Task<List<Aviso>> BuscarAvisos();
        Task MarcarComoLido(int NotificacaoId, int MoradorId);
    }
}
