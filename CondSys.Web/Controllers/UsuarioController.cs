using AutoMapper;
using CondSys.Data.Services;
using CondSys.Helpers;
using CondSys.Model;
using CondSys.Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CondSys.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private static Usuario UsuarioLogado;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            int idUsuario = int.Parse(HttpContext.User.Identity.Name);
            UsuarioLogado = await _usuarioService.BuscarUsuario(idUsuario);
            ViewBag.UsuarioAdmin = UsuarioLogado.Admin;
            var usuario = await _usuarioService.ListarUsuario();
            var lstDto = Mapper.Map<List<UsuarioDto>>(usuario);
            return View(lstDto);
        }

        public ActionResult Novo()
        {
            ViewBag.UsuarioAdmin = UsuarioLogado.Admin;
            var userDto = new UsuarioDto { Ativo = true, Email=string.Empty };
            return View("Usuario", userDto);
        }

        public async Task<ActionResult> Salvar(UsuarioDto Model)
        {
            await _usuarioService.ValidaEmail(ModelState, Model.Email, Model.UsuarioId);
            if (!ModelState.IsValid)
            {
                return View("Usuario", Model);
            }
            else
            {
                string senha = Encriptacao.GeraSenha();
                var User = Mapper.Map<Usuario>(Model);
                if (User.UsuarioId == 0)
                {
                    User.Senha = Encriptacao.Encrypt(senha);
                    string link = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                    Sender.Email.EnviarEmail(User.Email, "Senha de acesso", $"Olá {User.Nome}. {Environment.NewLine} A senha de acesso ao sistema é {senha}. {Environment.NewLine} Use o link para ter acesso ao sistema: {link}");
                }
                await _usuarioService.Salvar(User);
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Editar(int id)
        {
            ViewBag.UsuarioAdmin = UsuarioLogado.Admin;
            var user = await _usuarioService.BuscarUsuario(id);
            var userDto = Mapper.Map<UsuarioDto>(user);
            userDto.ConfirmaSenha = userDto.Senha;
            return View("Usuario", userDto);
        }

        public async Task AlteraStatus(int id)
        {
            await _usuarioService.AlteraStatus(id);
        }

        public async Task<ActionResult> AlterarSenha(int id)
        {
            var usuario = await _usuarioService.BuscarUsuario(id);
            AlterarSenhaDto dto = new AlterarSenhaDto { UsuarioId = id };
            return View(dto);
        }

        public async Task<ActionResult> SalvarSenha(ModelState modelState, AlterarSenhaDto dto)
        {

            await _usuarioService.ValidaAlteracaoSenha(ModelState, dto);
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("AlterarSenha", new RouteValueDictionary(new
                //{
                //    controller = "Usuario",
                //    action = "AlterarSenha",
                //    Id = dto.UsuarioId
                //}));
                return View("AlterarSenha", dto);
            }
            else
            {
                var usuario = await _usuarioService.BuscarUsuario(dto.UsuarioId);
                usuario.Senha = Encriptacao.Encrypt(dto.NovaSenha);
                usuario.AlterarSenha = false;
                await _usuarioService.Salvar(usuario);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}