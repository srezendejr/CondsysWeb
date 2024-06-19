using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CondSys.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime DataOut = new DateTime();
            if (value == null || !DateTime.TryParse(value.ToString(), out DataOut))
                return false;
            else
                return true;
        }

        public DataTimeAttribute(string dateToCompareToFieldName)
        {
            DateToCompareToFieldName = dateToCompareToFieldName;
        }

        private string DateToCompareToFieldName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime earlierDate = (DateTime)value;

            DateTime? laterDate = (Nullable<DateTime>)validationContext.ObjectType.GetProperty(DateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);

            if (earlierDate.Date > DateTime.Now.Date)
            {
                return new ValidationResult("A data não pode ser maior que a atual");
            }

            if (!laterDate.HasValue || laterDate.Value.Date >= earlierDate.Date)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A data de recebimento não pode ser maior que a data de entrega");
            }
        }
    }
}