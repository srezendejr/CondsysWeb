using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CondSys.Helpers
{
    public static class StringExtension
    {
        public static string EscrevePorExtenso(this string[] lista)
        {
            if (lista.Length <= 0)
                return string.Empty;
            if (lista.Length == 1)
                return lista.FirstOrDefault();

            var ultimoElemento = lista.Last();
            var listaPorExtenso = string.Join(", ", lista.Where(item => item != ultimoElemento));
            listaPorExtenso = string.Format("{0} e {1}", listaPorExtenso, ultimoElemento);

            return listaPorExtenso;
        }

        public static string RemoveSpecialChars(this string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-Z]", string.Empty);
        }
    }
}
