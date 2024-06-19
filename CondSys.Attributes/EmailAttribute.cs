using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CondSys.Attributes
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //define a expressão regulara para validar o email
            Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;
            // testa o email com a expressão
            if (expressaoRegex.IsMatch(value.ToString()))
            {
                // o email é valido
                return true;
            }
            else
            {
                // o email é inválido
                return false;
            }
        }
    }
}