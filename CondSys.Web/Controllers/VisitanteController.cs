using AutoMapper;
using CondSys.Data.Services;
using CondSys.Enumerator;
using CondSys.Helpers;
using CondSys.Model;
using CondSys.Model.Visitante;
using CondSys.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CondSys.Web.Controllers
{
    public class VisitanteController : Controller
    {
        IMovimentoService _movimentoService;
        IPessoaService _pessoaService;
        public VisitanteController(IMovimentoService movimentoService, IPessoaService pessoaService)
        {
            _movimentoService = movimentoService;
            _pessoaService = pessoaService;
        }
        // GET: Visitante
        public ActionResult Index()
        {
            var dto = new MovimentoDto { DataHoraEntrada = DateTime.Now, TipoDoc = TipoDocumento.rg, Tipo = EnumTipoVisitante.Visitante };
            return View(dto);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> PesquisaVisitante(string doc)
        {
            var visitante = await _pessoaService.BuscarVisitante(doc);
            var dto = Mapper.Map<VisitanteDto>(visitante);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Salvar(MovimentoDto Dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", Dto);
            }
            else
            {
                var Mov = Mapper.Map<Movimento>(Dto);
                if (Mov.VisitanteId == 0)
                {
                    var pessoa = new Visitante {PessoaId = Dto.PessoaId, Nome = Dto.NomeVisitante, Ativo = true, TipoPessoaMovimento = TipoPessoaMovimento.Visitante, Foto = ImageHelper.Base64ToByteArray(Dto.Foto) };
                    await _pessoaService.SalvarVisitante(pessoa, AdicionarDocumento(Dto, pessoa));
                    Mov.Visitante = pessoa;
                    Mov.VisitanteId = pessoa.PessoaId;
                }
                await _movimentoService.Salvar(Mov);
                var morador = await _pessoaService.BuscaMorador(Mov.MoradorId);
                var emailMorador = morador.Contatos?.FirstOrDefault(f => f.Tipo == TipoContato.Email).Contato;
                Email.EnviarEmailVisitante(DateTime.Now, null, Dto.Foto, emailMorador, Dto.NomeVisitante, "Entrada Visitante");
                TwillioIntegracao.MensagemWhatsapp(Dto.NomeVisitante, morador.Contatos?.FirstOrDefault(a => a.Tipo == TipoContato.Celular)?.Contato);
                return RedirectToAction("Index");
            }
        }

        private List<PessoaDocumento> AdicionarDocumento(MovimentoDto dto, Pessoa pessoa)
        {
            var Documentos = new List<PessoaDocumento>();
            if (!string.IsNullOrEmpty(dto.Doc))
            {
                Documentos.Add(new PessoaDocumento
                {
                    Documento = dto.Doc.RemoveSpecialChars(),
                    PessoaId = dto.PessoaId,
                    Tipo = dto.TipoDoc,
                    PessoaDocumentoId = dto.DocId,
                    Pessoa = pessoa
                });
            }
            return Documentos;
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> VisitantesNoCondominio()
        {
            var lstVisitantes = await _movimentoService.VisitantesNoCondominio();
            var lstDto = Mapper.Map<List<MovimentoDto>>(lstVisitantes);
            return Json(lstDto, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public async Task SaidaVisitante(string id)
        {
            var movimento = await _movimentoService.BuscarMovimento(Convert.ToInt32(id));
            movimento.DataHoraSaida = DateTime.Now;
            
            await _movimentoService.MarcarSaidaVisitante(movimento);
            var emailMorador = movimento.Morador.Contatos?.FirstOrDefault(f => f.Tipo == TipoContato.Email).Contato;
            var nomeVisitante = movimento.Visitante.Nome;
            Email.EnviarEmailVisitante(movimento.DataHoraEntrada, movimento.DataHoraSaida, ImageHelper.ArrayByteToBase64(movimento.Visitante.Foto), emailMorador, nomeVisitante, "Saída Visitante");

        }
    }
}