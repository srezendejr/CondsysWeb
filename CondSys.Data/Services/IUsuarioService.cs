using CondSys.Model;
using CondSys.Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CondSys.Data.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> ValidaLogin(Login model);
        Task<List<Usuario>> ListarUsuario();
        Task Salvar(Usuario user);
        Task<Usuario> BuscarUsuario(int id);
        Task AlteraStatus(int id);
        Task ResetaSenha(ModelStateDictionary modelState, string email);
        Task ValidaEmail(ModelStateDictionary modelState, string email, int usuarioId);
        Task ValidaAlteracaoSenha(ModelStateDictionary modelState, AlterarSenhaDto dto);
    }
}
