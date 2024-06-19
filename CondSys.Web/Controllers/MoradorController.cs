using AutoMapper;
using CondSys.Business;
using CondSys.Data.Services;
using CondSys.Enumerator;
using CondSys.Helpers;
using CondSys.Model;
using CondSys.Model.UH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;

namespace CondSys.Web.Controllers
{
    public class MoradorController : Controller
    {
        private readonly IPessoaService _morador;
        private readonly IUnidadeService _unidade;
        private readonly IUsuarioService _usuarioService;
        private static Usuario UsuarioLogado;

        public MoradorController(IPessoaService morador, IUnidadeService unidade, IUsuarioService usuarioService)
        {
            _morador = morador;
            _unidade = unidade;
            _usuarioService = usuarioService;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            int idUsuario = int.Parse(HttpContext.User.Identity.Name);
            UsuarioLogado = await _usuarioService.BuscarUsuario(idUsuario);
            var lstMoradores = await _morador.GetMoradores();
            ViewBag.MoradorUsuario = UsuarioLogado.PessoaId.HasValue;
            var lstMoradoresDto = Mapper.Map<List<MoradorDto>>(lstMoradores.Where(w => !UsuarioLogado.PessoaId.HasValue || w.PessoaId == UsuarioLogado.PessoaId.Value));
            return View(lstMoradoresDto);
        }

        [Authorize]
        public ActionResult Novo()
        {
            ViewBag.MoradorUsuario = UsuarioLogado.PessoaId.HasValue;
            return View("Morador", new MoradorDto { Ativo = true, Proprietario = true, Tipo = TipoPessoaMovimento.Morador });
        }
        [Authorize]
        public async Task<ActionResult> Salvar(MoradorDto Morador)
        {
            if (ModelState.IsValid)
            {
                var pessoa = Mapper.Map<Morador>(Morador);
                if (Morador.Unidade != null && !string.IsNullOrEmpty(Morador.Unidade.Numero))
                {
                    var unidade = Mapper.Map<Unidade>(Morador.Unidade);
                    unidade.Status = StatusUnidade.Ocupada;
                    await _unidade.Salvar(unidade);
                    pessoa.Unidade = unidade;
                    pessoa.UnidadeId = unidade.UnidadeId;
                }
                else
                {
                    pessoa.Unidade = null;
                    pessoa.UnidadeId = null;
                }

                var documentos = pessoa.AdicionaDocumentos(Morador, pessoa);
                var contatos = pessoa.AdicionarContato(Morador, pessoa);
                await _morador.Salvar(pessoa, documentos, contatos);
                if (Morador.PessoaId == 0)
                {
                    string senha = Encriptacao.GeraSenha();
                    await _usuarioService.Salvar(new Usuario
                    {
                        Admin = false,
                        AlterarSenha = true,
                        Ativo = true,
                        Email = Morador.Email,
                        GrupoAcesso = GruposAcesso.Morador,
                        Morador = pessoa,
                        Nome = Morador.Nome,
                        PessoaId = pessoa.PessoaId,
                        Senha = senha,
                        UsuarioId = 0
                    });
                    var mensagem = new StringBuilder();
                    mensagem.AppendFormat("Olá, {0}.", Morador.Nome)
                        .AppendLine("Não responda a este e-mail, ele tem visa informar que o seu acesso ao sistema foi criado e para ter completar a validação ")
                        .AppendLine("do seu cadastro, é necessário que você acesse o sistema pelo link http://www.condsys.com.br")
                        .AppendLine("Será solicitado que você altere sua senha para uma nova")
                        .AppendLine().AppendFormat("Senha atual {0}", senha);
                    Sender.Email.EnviarEmail(Morador.Email, "Acesso ao sistema", mensagem.ToString());
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MoradorUsuario = UsuarioLogado.PessoaId.HasValue;
                return View("Morador", Morador);
            }
        }

        [Authorize]
        public async Task<ActionResult> Editar(int id)
        {
            int idUsuario = int.Parse(HttpContext.User.Identity.Name);
            ViewBag.MoradorUsuario = UsuarioLogado.PessoaId.HasValue;
            var morador = await _morador.BuscaMorador(id);
            var moradorDto = Mapper.Map<MoradorDto>(morador);
            return View("Morador", moradorDto);
        }

        [Authorize]
        public async Task AlteraStatus(int PessoaId)
        {
            await _morador.AlteraStatus(PessoaId);
        }

        [Authorize]
        public async Task DesvincularUnidade(int PessoaId)
        {
            await _morador.DesvincularUnidade(PessoaId);
        }

        [Authorize]
        public async Task<JsonResult> BuscarMoradoresAtivos()
        {
            var moradores = await _morador.GetMoradores();
            return Json(moradores.Where(a => a.Ativo), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public async Task<JsonResult> PesquisaMorador(string doc)
        {
            var morador = await _morador.GetMoradores();
            var moradorPesquisado = morador.Where(a => a.Unidade != null && a.Ativo && a.PermiteAutorizarPortaria && (a.Nome.ToLower().Contains(doc.ToLower()) || a.Unidade.Numero.ToLower().Contains(doc.ToLower()))).ToList();
            var result = Mapper.Map<List<MoradorPesquisa>>(moradorPesquisado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}