using System.ComponentModel.DataAnnotations;

namespace CondSys.Attributes
{
    public class CPFAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            return CPF.ValidaCpfCnpj(value.ToString());
        }
    }

    public static class CPF
    {
        /// <summary>
        /// Método que valida o CPF e o CNPJ informado. Calcula o valor dos dígitos e compara com os valores informados.
        /// </summary>
        /// <param name="CpfCnpj">Valor do CPF ou CNPJ sem os caracteres especiais</param>
        /// <returns>Retorna verdadeiro para confirmação do Cpf/CNPJ ou falso para CPF/CNPJ incorreto.</returns>
        public static bool ValidaCpfCnpj(string CpfCnpj)
        {
            CpfCnpj = CpfCnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Trim();
            int Tamanho = CpfCnpj.Length;
            int Soma = 0;
            bool Valido = false;
            int Digito1 = 0;
            int Digito2 = 0;
            int Contador = 0;
            if (Tamanho == 14)
                Contador = 5;
            else
                Contador = Tamanho - 1;
            for (int i = 0; i < Tamanho - 2; i++)
            {
                int numero = int.Parse(CpfCnpj.Substring(i, 1));
                Soma += int.Parse(CpfCnpj.Substring(i, 1)) * (Contador - i);
                if ((Contador - i) == 2)
                    Contador = 10 + i;
            }

            Digito1 = (11 - (Soma % 11));
            if (Digito1 >= 10)
                Digito1 = 0;

            Soma = 0;
            if (Tamanho == 14)
                Contador = 6;
            else
                Contador = Tamanho;
            for (int i = 0; i < Tamanho - 1; i++)
            {
                int numero = int.Parse(CpfCnpj.Substring(i, 1));
                Soma += int.Parse(CpfCnpj.Substring(i, 1)) * (Contador - i);
                if ((Contador - i) == 2)
                    Contador = 10 + i;
            }

            Digito2 = (11 - (Soma % 11));
            if (Digito2 >= 10)
                Digito2 = 0;

            if (Digito1 == int.Parse(CpfCnpj.Substring(Tamanho - 2, 1))
                && Digito2 == int.Parse(CpfCnpj.Substring(Tamanho - 1, 1)))
                Valido = true;

            return Valido;
        }

        //public static bool Validar(string cpf)
        //{
        //    if (cpf == null)
        //        return false;

        //    cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty).Trim();

        //    if (cpf.Length != 11)
        //        return false;

        //    switch (cpf)
        //    {
        //        case "00000000000":
        //        case "11111111111":
        //        case "22222222222":
        //        case "33333333333":
        //        case "44444444444":
        //        case "55555555555":
        //        case "66666666666":
        //        case "77777777777":
        //        case "88888888888":
        //        case "99999999999":
        //            return false;
        //    }

        //    int soma = 0;
        //    for (int i = 0, j = 10, d; i < 9; i++, j--)
        //    {
        //        if (!int.TryParse(cpf[i].ToString(), out d))
        //            return false;
        //        soma += d * j;
        //    }

        //    var resto = soma % 11;

        //    var digito = (resto < 2 ? 0 : 11 - resto).ToString();
        //    var prefixo = cpf.Substring(0, 9) + digito;

        //    soma = 0;
        //    for (int i = 0, j = 11; i < 10; i++, j--)
        //        soma += int.Parse(prefixo[i].ToString()) * j;

        //    resto = soma % 11;
        //    digito += (resto < 2 ? 0 : 11 - resto).ToString();

        //    return cpf.EndsWith(digito);
        //}

        public static string Formatar(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return string.Empty;

            cpf = cpf.Trim();

            if (cpf.Length != 11)
                return string.Empty;

            return string.Format("{0}.{1}.{2}-{3}", cpf.Substring(0, 3), cpf.Substring(3, 3), cpf.Substring(6, 3), cpf.Substring(9));
        }
    }
}