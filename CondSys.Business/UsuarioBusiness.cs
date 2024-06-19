using CondSys.Data.Context;
using CondSys.Data.Services;
using CondSys.Sender;
using CondSys.Model;
using CondSys.Model.Usuarios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Web.Mvc;
using CondSys.Helpers;
using System.Linq;

namespace CondSys.Business
{
    public class UsuarioBusiness: IUsuarioService
    {
        ContextMySql _context;
        public UsuarioBusiness(ContextMySql context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidaLogin(Login model)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(f => f.Email == model.Email && f.Senha == model.Senha && f.Ativo);
        }

        public async Task<List<Usuario>>ListarUsuario()
        {
            return await _context.Usuarios.Where(w => w.PessoaId == null).ToListAsync();
        }

        public async Task Salvar(Usuario user)
        {
            if (user.UsuarioId == 0)
                _context.Salvar<Usuario>(user);
            else
                _context.Alterar<Usuario>(user);

            await _context.Commit();
        }

        public async Task<Usuario> BuscarUsuario(int id)
        {
            return await _context.Usuarios.Include(i => i.Morador).FirstOrDefaultAsync(a => a.UsuarioId == id);
        }

        public async Task AlteraStatus(int id)
        {
            var usuario = await BuscarUsuario(id);
            usuario.Ativo = !usuario.Ativo;
            await Salvar(usuario);
        }

        public async Task ValidaEmail(ModelStateDictionary modelState, string email, int usuarioId)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(a => a.Email == email && a.Ativo && a.UsuarioId != usuarioId);
            if (usuario != null)
            {
                modelState.AddModelError("Email", "Email já cadastrado para outro usuário");
            }
        }

        public async Task ResetaSenha(ModelStateDictionary modelState, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                modelState.AddModelError("Email", "Email não pode ser branco");
            }
            else
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(a => a.Email == email && a.Ativo);
                if (usuario == null)
                {
                    modelState.AddModelError("Email", "Email não cadastrado");
                }
                else
                {
                    var novaSenha = Encriptacao.GeraSenha();
                    usuario.Senha = Encriptacao.Encrypt(novaSenha);
                    usuario.AlterarSenha = true;
                    _context.Alterar<Usuario>(usuario);
                    await _context.Commit();
                    try
                    {
                        Email.EnviarEmail(usuario.Nome, usuario.Email, "Nova senha", novaSenha, true);
                    }
                    catch(Exception ex)
                    {
                        modelState.AddModelError("Email", ex.Message);
                    }
                }
            }
        }

        public async Task ValidaAlteracaoSenha(ModelStateDictionary modelState, AlterarSenhaDto dto)
        {
            var usuario = await this.BuscarUsuario(dto.UsuarioId);
            var novaSenha = Encriptacao.Encrypt(dto.NovaSenha);
            if(novaSenha == usuario.Senha)
            {
                modelState.AddModelError("NovaSenha", "Deve ser selecionada uma nova senha.");
            }
        }
    }
}
