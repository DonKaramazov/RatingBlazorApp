using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RatingBlazorApp.Code
{
    public class Enums
    {
        public enum EBeerColorTypes
        {
            BLANCHE,
            BLONDE,
            AMBREE,
            BRUNE
        }

        public enum EBeerStyles
        {
            GARDE,
            ABBAYE,
            LAGER,
            PALEALE,
            IPA,
            TRIPLE,
            STOUT,
            BLANCHE,
            SAISON,
            SOUR,
            FUT,
            FRUIT
        }

    }

    public static class EnumEx
    {
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field,typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // or return default(T);
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            return attributes != null && attributes.Any() 
                ? attributes.First().Description 
                : value.ToString();
        }
    }
}
