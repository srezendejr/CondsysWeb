using AutoMapper;
using CondSys.Data.Services;
using CondSys.Model.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CondSys.Web.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private IConfiguracaoService _configService;
        public ConfiguracaoController(IConfiguracaoService configService)
        {
            _configService = configService;
        }
        // GET: Configuracao
        public async Task<ActionResult> Index()
        {
            var config = await _configService.BuscaConfiguracao();
            var model = Mapper.Map<ConfiguracaoDto>(config ?? new Configuracao());
            return View("Configuracao", model);
        }

        public async Task<ActionResult> Salvar(ConfiguracaoDto model)
        {
            if (!ModelState.IsValid)
            {
                return View("Configuracao", model);
            }
            else
            {
                var config = Mapper.Map<Configuracao>(model);
                await _configService.Salvar(config);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}