using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Configuracao
{
    public class Configuracao
    {
        [Key]
        public int ConfiguracaoId { get; set; }
        [StringLength(100)]
        public string RazaoSocial { get; set; }
        [StringLength(100)]
        public string NomeFantasia { get; set; }
        [StringLength(12)]
        public string TelefoneContato { get; set; }
        [StringLength(100)]
        public string Logradouro { get; set; }
        [StringLength(8)]
        public string Cep { get; set; }
        [StringLength(50)]
        public string Bairro { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        [StringLength(100)]
        public string Cidade { get; set; }
        
        public EnumEstados Estado { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string SenhaEmail { get; set; }
        [StringLength(100)]
        public string NomeSindico { get; set; }
        [StringLength(100)]
        public string NomeZelador { get; set; }
        public string CNPJ { get; set; }

        [StringLength(15)]
        public string IPEntradaVisitante { get; set; }
        public int PortaEntradaVisitante { get; set; }
        [StringLength(15)]
        public string IPSaidaVisitante { get; set; }
        public int PortaSaidaVisitante { get; set; }

        [StringLength(15)]
        public string IPEntradaMorador { get; set; }
        public int PortaEntradaMorador { get; set; }
        [StringLength(15)]
        public string IPSaidaMorador { get; set; }
        public int PortaSaidaMorador { get; set; }

        [StringLength(15)]
        public string IPEntradaPedestre { get; set; }
        public int PortaEntradaPedestre { get; set; }
        [StringLength(15)]
        public string IPSaidaPedestre { get; set; }
        public int PortaSaidaPedestre { get; set; }

        [StringLength(50)]
        public string AccountSidWhatsApp { get; set; }
        [StringLength(50)]
        public string TokenWhatsapp { get; set; }
        [StringLength(12)]
        public string CelularContato { get; set; }
    }
}
