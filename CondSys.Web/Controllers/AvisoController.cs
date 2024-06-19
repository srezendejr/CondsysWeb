using AutoMapper;
using CondSys.Data.Services;
using CondSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CondSys.Web.Controllers
{
    public class AvisoController : Controller
    {
        private IAvisoService _avisoService;
        private IUsuarioService _usuarioService;
        private IPessoaService _moradorService;
        private static Usuario UsuarioLogado;
        public AvisoController(IAvisoService avisoService, IUsuarioService usuarioService, IPessoaService moradorService)
        {
            _avisoService = avisoService;
            _usuarioService = usuarioService;
            _moradorService = moradorService;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            int idUsuario = int.Parse(HttpContext.User.Identity.Name);
            UsuarioLogado = await _usuarioService.BuscarUsuario(idUsuario);
            ViewBag.MoradorUsuario = UsuarioLogado.PessoaId.HasValue;
            var lstAvisos = await _avisoService.BuscarAvisos();
            var dto = Mapper.Map<List<AvisosDto>>(lstAvisos.Where(a => !UsuarioLogado.PessoaId.HasValue || a.Moradores.Any(b => b.MoradorId == UsuarioLogado.PessoaId.Value)));
            return View(dto);
        }

        [Authorize]
        public ActionResult Novo()
        {
            return View("Aviso", new AvisosDto { AvisoId = 0});
        }

        [Authorize]
        public async Task<ActionResult> Salvar(AvisosDto dto)
        {
            if(!ModelState.IsValid)
                return View("Aviso", dto);

            var aviso = Mapper.Map<Aviso>(dto);
            if (aviso.AvisoId == 0)
                aviso.Data = DateTime.Now;
            var moradores = await _moradorService.GetMoradores();
            var AvisoMoradores = moradores.Select(s => new AvisoMorador {
                Aviso = aviso,
                MoradorId = s.PessoaId
            }).ToList();
                
            await _avisoService.Salvar(aviso, AvisoMoradores);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<ActionResult> Editar(int id)
        {
            var aviso = await _avisoService.BuscarAviso(id);
            var dto = Mapper.Map<AvisosDto>(aviso);
            return View("Aviso", dto);
        }

        [Authorize]
        public async Task<ActionResult> MarcarComoLido(int id, int morador)
        {
            await _avisoService.MarcarComoLido(id, morador);
            return RedirectToAction("Index", "Home");
        }
    }
}