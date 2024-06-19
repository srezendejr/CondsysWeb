using AutoMapper;
using CondSys.Data.Services;
using CondSys.Model;
using CondSys.Model.Correspondencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CondSys.Web.Controllers
{
    public class CorrespondenciaController : Controller
    {
        private readonly ICorrespondenciaService _correspondenciaService;
        private readonly IUsuarioService _usuarioService;
        private static Usuario UsuarioLogado;
        public CorrespondenciaController(ICorrespondenciaService correspondenciaService, IUsuarioService usuarioService)
        {
            _correspondenciaService = correspondenciaService;
            _usuarioService = usuarioService;
        }

        // GET: Correspondencia
        public async Task<ActionResult> Index()
        {
            int idUsuario = int.Parse(HttpContext.User.Identity.Name);
            UsuarioLogado = await _usuarioService.BuscarUsuario(idUsuario);
            var lstCorrespondencia = await _correspondenciaService.BuscarCorrespondencias();
            ViewBag.MoradorUsuario = UsuarioLogado.PessoaId.HasValue;
            var lstDto = Mapper.Map<List<CorrespondenciaDto>>(lstCorrespondencia.Where(a => !UsuarioLogado.PessoaId.HasValue || a.MoradorId == UsuarioLogado.PessoaId.Value));
            return View(lstDto);
        }

        public ActionResult Novo()
        {
            var dto = new CorrespondenciaDto
            {
                DataChegada = DateTime.Now,
                Entregue = false,
                DataEntrega = null,
                Id = 0,
                RecebidoPorId = int.Parse(HttpContext.User.Identity.Name)
            };
            return View("Correspondencia", dto);
        }

        public async Task<ActionResult> Editar(int id)
        {
            var corresp = await _correspondenciaService.BuscarCorrespondencia(id);
            var dto = Mapper.Map<CorrespondenciaDto>(corresp);
            return View("Correspondencia", dto);
        }

        public async Task<ActionResult> Salvar(CorrespondenciaDto viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Correspondencia", viewModel);
            }
            var corresp = Mapper.Map<Correspondencia>(viewModel);
            await _correspondenciaService.Salvar(corresp);
            return RedirectToAction("Index");
        }

        public async Task Entregar(int Id)
        {
            var usuario = await _usuarioService.BuscarUsuario(int.Parse(HttpContext.User.Identity.Name));
            var corresp = await _correspondenciaService.BuscarCorrespondencia(Id);
            corresp.Entregue = true;
            corresp.DataEntrega = DateTime.Now;
            corresp.UsuarioEntregaId = usuario.UsuarioId;
            corresp.Mensagem = $"Correspondência entregue em {DateTime.Now} por {usuario.Nome}";
            await _correspondenciaService.Salvar(corresp);
        }
    }
}