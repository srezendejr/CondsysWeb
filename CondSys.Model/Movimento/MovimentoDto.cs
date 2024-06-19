using CondSys.Enumerator;
using CondSys.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class MovimentoDto
    {
        public int MovimentoId { get; set; }

        [Display(Name ="Entrada")]
        public DateTime DataHoraEntrada { get; set; }

        [Display(Name = "Saída")]
        public DateTime? DataHoraSaida { get; set; }

        [Display(Name = "Cartão")]
        public string NroCartao { get; set; }

        public int MoradorId { get; set; }

        [Display(Name = "Morador")]
        public string MoradorNome { get; set; }

        [Display(Name = "Placa Veículo")]
        public string PlacaVeiculo { get; set; }

        [Display(Name = "Tipo Visitante")]
        public EnumTipoVisitante Tipo { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage ="Informe o documento do visitante")]
        public string Doc { get; set; }

        public int DocId { get; set; }

        [Display(Name = "Tipo Documento")]
        public TipoDocumento TipoDoc { get; set; }

        [Display(Name = "Nome Visitante")]
        public string NomeVisitante { get; set; }

        public int PessoaId { get; set; }

        public string Foto { get; set; }

        [NotMapped]
        public string Entrada => DataHoraEntrada.ToString("dd/MM/hhhh HH:mm");

        public List<PessoaDocumento> AdicionarDocumento(MovimentoDto dto, Pessoa pessoa)
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
    }
}
