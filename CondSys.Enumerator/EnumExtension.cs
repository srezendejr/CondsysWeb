using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CondSys.Enumerator
{
    public static class EnumExtension
    {
        public static string ObtemDescricao(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                        return attr.Description;
                }
            }

            return Enum.GetName(type, value);
        }

        public static IList<string> EnumToList(this Type value)
        {
            return Enum.GetNames(value).ToList();
        }

        public static IDictionary<int, string> EnumToDictionary(this Type value)
        {
            string[] names = Enum.GetNames(value);
            Array values = Enum.GetValues(value);

            return (from i in Enumerable.Range(0, names.Length)
                    select new { Key = ((Enum)values.GetValue(i)).ObtemDescricao(), Value = (int)values.GetValue(i) })
                        .ToDictionary(k => k.Value, k => k.Key);
        }

        public static IList<SelectListItem> EnumToSelectListItem(this Type value)
        {
            string[] names = Enum.GetNames(value);
            Array values = Enum.GetValues(value);

            return (from i in Enumerable.Range(0, names.Length)
                    select new { Key = ((Enum)values.GetValue(i)).ObtemDescricao(), Value = (int)values.GetValue(i) })
                        .Select(d => new SelectListItem { Value = d.Value.ToString(), Text = d.Key }).ToList();
        }
    }
}
