using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CondSys.Helpers;

//public class TelefoneAttribute : RegularExpressionAttribute, IClientValidatable
//{
//    public TelefoneAttribute()
//        : base(@"^[9^-]{8,10}|[8^-]{8,10}|[7^-]{8,10}|[6^-]{8,10}|[5^-]{8,10}|[4^-]{8,10}|[3^-]{8,10}|[2^-]{8,10}|[1^-]{8,10}$")
//    {
//    }

//    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
//    {
//        var rule = new ModelClientValidationRegexRule(this.ErrorMessageString, base.Pattern);
//        return new[] { rule };
//    }
//}
namespace CondSys.Attributes
{
    public class TelefoneAttribute : ValidationAttribute
    {
        private IList<string> TelefonesInvalidos;
        public TelefoneAttribute()
        {
            TelefonesInvalidos = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                TelefonesInvalidos.Add(string.Format("{0}{0}{0}{0}{0}{0}{0}{0}", i));
                TelefonesInvalidos.Add(string.Format("{0}{0}{0}{0}{0}{0}{0}{0}{0}", i));
            }
        }

        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) return true;
            var telefone = value.ToString().RemoveSpecialChars().Substring(2);
            return (!TelefonesInvalidos.Contains(telefone));
        }
    }
}