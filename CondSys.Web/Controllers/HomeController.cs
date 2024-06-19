using AutoMapper;
using CondSys.Data.Services;
using CondSys.Model;
using CondSys.Model.Correspondencias;
using CondSys.Model.Home;
using CondSys.Model.Menu;
using CondSys.Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CondSys.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICorrespondenciaService _correspondenciaService;
        private readonly IUsuarioService _usuarioService;
        private IAvisoService _avisoService;
        private static Usuario UsuarioLogado;
        public HomeController(ICorrespondenciaService correspondenciaService, IUsuarioService usuarioService, IAvisoService avisoService)
        {
            _correspondenciaService = correspondenciaService;
            _usuarioService = usuarioService;
            _avisoService = avisoService;
        }
        [Authorize]
        public async Task<ActionResult> Index()
        {
            int id = int.Parse(HttpContext.User.Identity.Name);
            UsuarioLogado = await _usuarioService.BuscarUsuario(id);
            
            
            ViewBag.MoradorUsuario = UsuarioLogado.PessoaId.HasValue;
            HomeDto home = new HomeDto();
            var lstAvisos = await _avisoService.BuscarAvisos();
            var dto = lstAvisos.
                SelectMany(s => s.Moradores.Where(w => (!UsuarioLogado.PessoaId.HasValue || w.MoradorId == UsuarioLogado.PessoaId.Value) && !w.Lida)).
                Select(s => new AvisosDto
                {
                    AvisoId = s.AvisoId,
                    Data = s.Aviso.Data,
                    Mensagem = s.Aviso.Texto,
                    Titulo = s.Aviso.Titulo,
                    Lido = s.Lida,
                    PessoaId = UsuarioLogado.PessoaId
                }).ToList();
            home.Avisos = dto;

            var correspondencias = await _correspondenciaService.BuscarCorrespondencias();
            var lstCorrespDto = Mapper.Map<List<CorrespondenciaDto>>(correspondencias);
            home.Correspondencias = lstCorrespDto.Where(w => (!UsuarioLogado.PessoaId.HasValue || w.MoradorId == UsuarioLogado.PessoaId.Value) && !w.Entregue).ToList();
            
            return View(home);
        }
    }
}
