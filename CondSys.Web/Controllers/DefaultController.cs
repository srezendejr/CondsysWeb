using AutoMapper;
using CondSys.Data.Services;
using CondSys.Enumerator;
using CondSys.Helpers;
using CondSys.Model;
using CondSys.Model.Configuracao;
using CondSys.Model.UH;
using CondSys.Model.Usuarios;
using CondSys.Model.Visitante;
using CondSys.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CondSys.Web.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPessoaService _pessoaService;
        private readonly IMovimentoService _movimentoService;
        private readonly IUnidadeService _unidadeService;
        private readonly IConfiguracaoService _configService;

        public DefaultController(IUsuarioService usuarioService, IPessoaService pessoaService,
            IMovimentoService movimentoService, IUnidadeService unidadeService, IConfiguracaoService configService)
        {
            _usuarioService = usuarioService;
            _pessoaService = pessoaService;
            _movimentoService = movimentoService;
            _unidadeService = unidadeService;
            _configService = configService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> LoginContingencia(string email, string senha)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
            {
                var model = new Login
                {
                    Email = email,
                    Senha = senha,
                    Lembrar = false
                };
                var usuario = await _usuarioService.ValidaLogin(model);
                if (usuario != null)
                {
                    var usuarioConectado = new
                    {
                        Nome = usuario.Nome,
                        UsuarioId = usuario.UsuarioId,
                        Email = usuario.Email
                    };
                    return Ok(usuarioConectado);
                }
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> BuscarMoradoresContingencia()
        {
            var moradores = await _pessoaService.GetMoradores();
            var lstMoradores = moradores.Where(a => a.Ativo).Select(s => new
            {
                PessoaId = s.PessoaId,
                Nome = s.Nome,
                NroUnidade = s?.Unidade?.Numero ?? string.Empty,
                Profissao = s.Profissao,
                DataNascimento = s.DataNascimento,
                Sexo = s.Genero,
                NumeroCartao = s.NumeroCartao,
                ProprietarioMorador = s.ProprietarioMorador,
                Email = s?.Contatos?.FirstOrDefault(a => a.Tipo == TipoContato.Email)?.Contato ?? string.Empty,
                Telefone = s?.Contatos?.FirstOrDefault(a => a.Tipo == TipoContato.Telefone)?.Contato ?? string.Empty,
                Celular = s?.Contatos?.FirstOrDefault(a => a.Tipo == TipoContato.Celular)?.Contato ?? string.Empty,
                Cpf = s?.Documentos?.FirstOrDefault(a => a.Tipo == TipoDocumento.cpf)?.Documento ?? string.Empty,
                RG = s?.Documentos?.FirstOrDefault(a => a.Tipo == TipoDocumento.rg)?.Documento ?? string.Empty,
                Ativo = s.Ativo,
                PermiteAutorizarVisitante = s.PermiteAutorizarVisitante,
                DocCpfId = s?.Documentos?.FirstOrDefault(a => a.Tipo == TipoDocumento.cpf)?.PessoaDocumentoId ?? 0,
                DocRgId = s?.Documentos?.FirstOrDefault(a => a.Tipo == TipoDocumento.rg)?.PessoaDocumentoId ?? 0,
                ContatoEmailId = s?.Contatos?.FirstOrDefault(a => a.Tipo == TipoContato.Email)?.PessoaContatoId ?? 0,
                ContatoFoneId = s?.Contatos?.FirstOrDefault(a => a.Tipo == TipoContato.Telefone)?.PessoaContatoId ?? 0,
                ContatoCelularId = s?.Contatos?.FirstOrDefault(a => a.Tipo == TipoContato.Celular)?.PessoaContatoId ?? 0,
                Tipo = s.Tipo,
                TipoPessoaMovimento = s.TipoPessoaMovimento,
                UnidadeId = s?.Unidade?.UnidadeId ?? 0,
                StatusUnidade = s?.Unidade?.Status ?? 0,
            });
            return Ok(lstMoradores);
        }

        [HttpGet]
        public async Task<IHttpActionResult> BuscarVisitantesNoCondominioContigencia()
        {
            var visitantesNoCondominio = await _movimentoService.VisitantesNoCondominio();
            var movimento = visitantesNoCondominio.Select(s => new
            {
                MovimentoId = s.MovimentoId,
                Nome = s.Visitante.Nome,
                UnidadeDestino = s?.Morador?.Unidade?.Numero ?? string.Empty,
                NomeMorador = s?.Morador?.Nome ?? string.Empty,
                DataHoraEntrada = s.DataHoraEntrada,
                NroCartao = string.IsNullOrEmpty(s.NroCartao) ? string.Empty : s.NroCartao,
                PlacaVeiculo = string.IsNullOrEmpty(s.PlacaVeiculo) ? string.Empty : s.PlacaVeiculo,
                Tipo = s.Tipo,
                VisitanteId = s.VisitanteId,
                MoradorId = s.MoradorId,
                Documento = s.Visitante?.Documentos?.FirstOrDefault()?.Documento ?? string.Empty,
                TipoDoc = s.Visitante?.Documentos?.FirstOrDefault()?.Tipo ?? 0,
                DocId = s.Visitante?.Documentos?.FirstOrDefault()?.PessoaDocumentoId ?? 0,
            });
            return Ok(movimento);
        }

        [HttpGet]
        public async Task<IHttpActionResult> BuscarVisitantesContigencia()
        {
            var visitantes = await _pessoaService.BuscarVisitantes();
            var movimento = visitantes.Select(s => new
            {
                Nome = s.Nome,
                Tipo = s.Tipo,
                VisitanteId = s.PessoaId,
                Documento = s?.Documentos?.FirstOrDefault()?.Documento ?? string.Empty,
                TipoDoc = s?.Documentos?.FirstOrDefault()?.Tipo ?? 0,
                DocId = s?.Documentos?.FirstOrDefault()?.PessoaDocumentoId ?? 0,
                Foto = s?.Foto?.ToString() ?? string.Empty
            });
            return Ok(movimento);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SalvarMorador(MoradorDto morador)
        {
            try
            {
                var p = Mapper.Map<Morador>(morador);
                if (morador.Unidade != null && !string.IsNullOrEmpty(morador.Unidade.Numero))
                {
                    var unidade = Mapper.Map<Unidade>(morador.Unidade);
                    unidade.Status = StatusUnidade.Ocupada;
                    await _unidadeService.Salvar(unidade);
                    p.Unidade = unidade;
                    p.UnidadeId = unidade.UnidadeId;
                }
                var documentos = p.AdicionaDocumentos(morador, p);
                var contatos = p.AdicionarContato(morador, p);
                await _pessoaService.Salvar(p, documentos, contatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        [HttpPost]
        public async Task EntradaVisitante(MovimentoDto Dto)
        {
            try
            {
                var Mov = Mapper.Map<Movimento>(Dto);
                if (Mov.VisitanteId == 0)
                {
                    var visitante = new Visitante { PessoaId = Dto.PessoaId, Nome = Dto.NomeVisitante, Ativo = true, TipoPessoaMovimento = TipoPessoaMovimento.Visitante, Foto = ImageHelper.Base64ToByteArray(Dto.Foto) };
                    await _pessoaService.SalvarVisitante(visitante, Dto.AdicionarDocumento(Dto, visitante));
                    Mov.Visitante = visitante;
                    Mov.VisitanteId = visitante.PessoaId;
                }
                await _movimentoService.Salvar(Mov);
                var morador = await _pessoaService.BuscaMorador(Mov.MoradorId);
                var emailMorador = morador.Contatos?.FirstOrDefault(f => f.Tipo == TipoContato.Email).Contato;
                Email.EnviarEmailVisitante(DateTime.Now, null, Dto.Foto, emailMorador, Dto.NomeVisitante, "Entrada Visitante");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task SaidaVisitante(MovimentoDto dto)
        {
            try
            {
                Movimento movimento = await _movimentoService.BuscarMovimento(dto.MovimentoId);
                movimento.DataHoraSaida = DateTime.Now;
                await _movimentoService.MarcarSaidaVisitante(movimento);
                var emailMorador = movimento.Morador.Contatos?.FirstOrDefault(f => f.Tipo == TipoContato.Email).Contato;
                var nomeVisitante = movimento.Visitante.Nome;
                Email.EnviarEmailVisitante(movimento.DataHoraEntrada, movimento.DataHoraSaida, ImageHelper.ArrayByteToBase64(movimento.Visitante.Foto), emailMorador, nomeVisitante, "Saída Visitante");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> BuscarConfiguracao()
        {
            try
            {
                var config = await _configService.BuscaConfiguracao();
                var result = new
                {
                    IPEntradaVisitante = config.IPEntradaVisitante,
                    PortaEntradaVisitante = config.PortaEntradaVisitante,
                    IPSaidaVisitante = config.IPSaidaVisitante,
                    PortaSaidaVisitante = config.PortaSaidaVisitante,

                    IPEntradaMorador = config.IPEntradaMorador,
                    PortaEntradaMorador = config.PortaEntradaMorador,

                    IPSaidaMorador = config.IPSaidaMorador,
                    PortaSaidaMorador = config.PortaSaidaMorador,

                    IPEntradaPedestre = config.IPEntradaPedestre,
                    PortaEntradaPedestre = config.PortaEntradaPedestre,

                    IPSaidaPedestre = config.IPSaidaPedestre,
                    PortaSaidaPedestre = config.PortaSaidaPedestre
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SalvarConfiguracao(ConfiguracaoDto model)
        {
            try
            {
                var config = await _configService.BuscaConfiguracao();
                config.IPEntradaVisitante = model.IPEntradaVisitante;
                config.PortaEntradaVisitante = model.PortaEntradaVisitante;
                config.IPSaidaVisitante = model.IPSaidaVisitante;
                config.PortaSaidaVisitante = model.PortaSaidaVisitante;
                config.IPEntradaMorador = model.IPEntradaMorador;
                config.PortaEntradaMorador = model.PortaEntradaMorador;

                config.IPSaidaMorador = model.IPSaidaMorador;
                config.PortaSaidaMorador = model.PortaSaidaMorador;

                config.IPEntradaPedestre = model.IPEntradaPedestre;
                config.PortaEntradaPedestre = model.PortaEntradaPedestre;

                config.IPSaidaPedestre = model.IPSaidaPedestre;
                config.PortaSaidaPedestre = model.PortaSaidaPedestre;
                await _configService.Salvar(config);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
