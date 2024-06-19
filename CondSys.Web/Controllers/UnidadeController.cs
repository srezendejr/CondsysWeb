using AutoMapper;
using CondSys.Data.Services;
using CondSys.Model.UH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CondSys.Web.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IUnidadeService _unidadeService;
        public UnidadeController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }
        // GET: Unidade
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var listUnidade = await _unidadeService.List();
            var listDto = Mapper.Map<List<UnidadeDto>>(listUnidade);
            return View(listDto);
        }

        [Authorize]
        public ActionResult Novo()
        {
            return View("Form", new UnidadeDto { UnidadeId = 0});
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Salvar(UnidadeDto model)
        {
            await _unidadeService.ValidaNumeroUnidade(ModelState, model.Numero, model.UnidadeId ?? 0);
            if (ModelState.IsValid)
            {
                var unidade = Mapper.Map<Unidade>(model);
                await _unidadeService.Salvar(unidade);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);

            }
        }

        [Authorize]
        public async Task<ActionResult> Editar(int id)
        {
            var unidade = await _unidadeService.BuscarUnidade(id);
            var dto = Mapper.Map<UnidadeDto>(unidade);

            return View("Form", dto);
        }

        [Authorize]
        public async Task<ActionResult> AlteraStatus(int id, int status)
        {
            await _unidadeService.AlterarStatus(id, status);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> BuscarUnidade(string nroUnidade)
        {
            var unidadeDto = Mapper.Map<UnidadeDto>(await _unidadeService.BuscarUnidade(nroUnidade));
            return Json(unidadeDto, JsonRequestBehavior.AllowGet);
        }
    }
}