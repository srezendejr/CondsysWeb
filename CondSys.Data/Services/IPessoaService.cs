using CondSys.Model;
using CondSys.Model.Visitante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Services
{
    public interface IPessoaService
    {
        Task<List<Morador>> GetMoradores();
        Task Salvar(Morador Morador, List<PessoaDocumento> Documentos, List<PessoaContato> Contatos);
        Task<Morador> BuscaMorador(int moradorId);
        Task AlteraStatus(int pessoaId);
        Task DesvincularUnidade(int pessoaId);
        Task<Visitante> BuscarVisitante(string doc);
        Task SalvarVisitante(Visitante Visitante, List<PessoaDocumento> Documentos);
        Task<List<Visitante>> BuscarVisitantes();
    }
}
