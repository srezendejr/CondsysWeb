using CondSys.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondSys.Model;
using CondSys.Data.Context;
using CondSys.Enumerator;
using System.Data.Entity;
using CondSys.Model.Visitante;

namespace CondSys.Business
{
    public class PessoaBusiness : IPessoaService
    {
        private ContextMySql _context;
        public PessoaBusiness(ContextMySql context)
        {
            _context = context;
        }

        public async Task<List<Morador>> GetMoradores()
        {
            return await _context.Pessoas.OfType<Morador>().Include(i=> i.Contatos).Include(i => i.Documentos).Include(i => i.Unidade).Where(a => a.TipoPessoaMovimento == TipoPessoaMovimento.Morador).ToListAsync();
        }

        public async Task Salvar(Morador morador, List<PessoaDocumento> Documentos, List<PessoaContato> Contatos)
        {
            if (morador.PessoaId == 0)
            {
                _context.Salvar<Pessoa>(morador);
                Documentos.ForEach(f => { _context.Salvar<PessoaDocumento>(f); });
                Contatos.ForEach(f => { _context.Salvar<PessoaContato>(f); });
            }
            else
            {
                _context.Alterar<Pessoa>(morador);
                Documentos.ForEach(f => {
                    if (f.PessoaDocumentoId > 0 && !string.IsNullOrEmpty(f.Documento))
                    {
                        _context.Alterar<PessoaDocumento>(f);
                    }
                    else if(f.PessoaDocumentoId == 0)
                    {
                        _context.Salvar<PessoaDocumento>(f);
                    }
                    else if (f.PessoaDocumentoId > 0 && string.IsNullOrEmpty(f.Documento))
                    {
                        _context.Remove<PessoaDocumento>(f);
                    }
                });
                Contatos.ForEach(f =>
                {
                    if (f.PessoaContatoId > 0 && !string.IsNullOrEmpty(f.Contato))
                    {
                        _context.Alterar<PessoaContato>(f);
                    }
                    else if(f.PessoaContatoId == 0)
                    {
                        _context.Salvar<PessoaContato>(f);
                    }
                    else if(f.PessoaContatoId > 0 && string.IsNullOrEmpty(f.Contato))
                    {
                        _context.Remove<PessoaContato>(f);
                    }
                });
            }

            await _context.Commit();
        }

        public async Task<Morador> BuscaMorador(int moradorId)
        {
            return await _context.Pessoas.OfType<Morador>().FirstOrDefaultAsync(f => f.PessoaId == moradorId);
        }

        public async Task AlteraStatus(int pessoaId)
        {
            var pessoa = await _context.Pessoas.OfType<Morador>().FirstOrDefaultAsync(a => a.PessoaId == pessoaId);
            pessoa.Ativo = !pessoa.Ativo;
            _context.Alterar<Pessoa>(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task DesvincularUnidade(int pessoaId)
        {
            var pessoa = await _context.Pessoas.OfType<Morador>().FirstOrDefaultAsync(a => a.PessoaId == pessoaId);
            pessoa.UnidadeId = null;
            pessoa.Unidade = null;
            _context.Alterar<Pessoa>(pessoa);
            await _context.SaveChangesAsync();

        }

        public async Task<Visitante> BuscarVisitante(string doc)
        {
            var visitante = await _context.Pessoas.OfType<Visitante>().Include(i => i.Documentos).Where(a => (a.TipoPessoaMovimento == TipoPessoaMovimento.Visitante || a.TipoPessoaMovimento == TipoPessoaMovimento.PrestadorServico)
            && a.Documentos.Any(s => s.Documento == doc)).FirstOrDefaultAsync();
            return visitante ?? new Visitante();
        }

        public async Task SalvarVisitante(Visitante Visitante, List<PessoaDocumento> Documentos)
        {
            if (Visitante.PessoaId == 0)
            {
                _context.Salvar<Pessoa>(Visitante);
                Documentos.ForEach(f => { _context.Salvar<PessoaDocumento>(f); });
            }
            else
            {
                _context.Alterar<Pessoa>(Visitante);
                Documentos.ForEach(f => { _context.Alterar<PessoaDocumento>(f); });
            }

            await _context.Commit();
        }

        public async Task<List<Visitante>> BuscarVisitantes()
        {
            return await _context.Pessoas.OfType<Visitante>().ToListAsync();
        }
    }
}
