using AutoMapper;
using CondSys.Business;
using CondSys.Data.Services;
using CondSys.Enumerator;
using CondSys.Helpers;
using CondSys.Model.Menu;
using CondSys.Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CondSys.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMenuService _menuService;

        public LoginController(IUsuarioService usuarioService, IMenuService menuService)
        {
            _usuarioService = usuarioService;
            _menuService = menuService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Acessar(Login model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                model.Senha = Encriptacao.Encrypt(model.Senha);
                var usuario = await _usuarioService.ValidaLogin(model);
                if (usuario != null)
                {
                    if(usuario.AlterarSenha)
                    {
                        return RedirectToAction("AlterarSenha", "Usuario", new { id = usuario.UsuarioId });
                    }
                    var usuarioDto = Mapper.Map<UsuarioDto>(usuario);
                    var menu = await _menuService.GetMenuGrupoAcesso(usuarioDto.GrupoAcesso);
                    usuarioDto.Menus = Mapper.Map<List<MenuDto>>(menu);
                    ViewBag.Usuario = usuarioDto;
                    Session.Add("Usuario", usuarioDto);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                                      1,
                                                      usuario.UsuarioId.ToString(),  // Id do usuário é muito importante
                                                      DateTime.Now,
                                                      DateTime.Now.AddMinutes(30),  // validade 30 min tá bom demais
                                                      model.Lembrar ?? false, // Se você deixar true, o cookie ficará no PC do usuário
                                                      usuario.Admin.ToString(),
                                                      usuario.Nome);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("Senha", "E-mail ou senha inválidos");
                    return View("Index");
                }
            }

        }

        [Authorize]
        public ActionResult Logoff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login", string.Empty);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ResetarSenha(string email)
        {
            await _usuarioService.ResetaSenha(ModelState, email);
            if (ModelState.IsValid)
            {
                return Json("A senha foi enviada para o email informado", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage, JsonRequestBehavior.AllowGet);
            }
        }
    }
}