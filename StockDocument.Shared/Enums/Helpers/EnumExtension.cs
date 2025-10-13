using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Shared.Enums.Helpers
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            DescriptionAttribute? attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }


        public static StockType? ToInvoiceType(this string? izahatString)
        {
            if (string.IsNullOrWhiteSpace(izahatString))
            {
                return null;
            }

            foreach (StockType type in Enum.GetValues(typeof(StockType)))
            {

                if (type.ToString().Equals(izahatString, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }

                if (type.GetDescription().Equals(izahatString, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }
            return null;
        }
    }
}
