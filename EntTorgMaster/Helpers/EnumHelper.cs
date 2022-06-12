using System.ComponentModel;
using System.Reflection;

namespace EntTorgMaster.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(this Enum value)
        {
            if (value == null) return null;
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null) return null;
            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

    }
}
