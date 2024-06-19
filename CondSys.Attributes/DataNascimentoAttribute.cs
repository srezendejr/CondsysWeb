using CondSys.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace CondSys.Attributes
{
    public class DataNascimentoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dataNascimento = new DateTime();
            if (value == null || !DateTime.TryParse(value.ToString(), out dataNascimento))
            {
                return false;
            }
            else
            {
                int idade = CalcularDatas.CalculaDataNascimento(dataNascimento);
                if ( idade >= 18)
                    return true;
                else
                    return false;
            }
        }
    }
}