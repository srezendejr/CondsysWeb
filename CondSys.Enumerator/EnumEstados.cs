using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Enumerator
{
    public enum EnumEstados
    {
        [Display(Name = "Acre")]
        Acre = 1,
        [Display(Name = "Alagoas")]
        Alagoas = 2,
        [Display(Name = "Amapá")]
        Amapa = 3,
        [Display(Name = "Amazonas")]
        Amazonas = 4,
        [Display(Name = "Bahia")]
        Bahia = 5,
        [Display(Name ="Ceará")]
        Ceara = 6,
        [Display(Name ="Distrito Federal")]
        DistritoFederal = 7,
        [Display(Name ="Espirito Santo")]
        EspiritoSanto = 8,
        [Display(Name ="Goiás")]
        Goias = 9,
        [Display(Name ="Maranhão")]
        Maranhao = 10,
        [Display(Name ="Mato Grosso")]
        MatoGrosso = 11,
        [Display(Name ="Mato Grosso do Sul")]
        MatoGrossoSul = 12,
        [Display(Name ="Minas Gerais")]
        MinasGerais = 13,
        [Display(Name ="Pará")]
        Para = 14,
        [Display(Name ="Paraíba")]
        Paraiba = 15,
        [Display(Name ="Paraná")]
        Parana = 16,
        [Display(Name = "Permambuco")]
        Pernambuco = 17,
        [Display(Name ="Piauí")]
        Piaui = 18,
        [Display(Name ="Rio de Janeiro")]
        RiodeJaneiro = 19,
        [Display(Name ="Rio Grande do Norte")]
        RioGrandedoNorte = 20,
        [Display(Name ="Rio Grande do Sul")]
        RioGrandedoSul = 21,
        [Display(Name ="Rondônia")]
        Rondonia = 22,
        [Display(Name = "Roraíma")]
        Roraima = 23,
        [Display(Name ="Santa Catarina")]
        SantaCatarina = 24,
        [Display(Name ="São Paulo")]
        SaoPaulo = 25,
        [Display(Name = "Sergipe")]
        Sergipe = 26,
        [Display(Name = "Tocantins")]
        Tocantins = 27
    }
}
