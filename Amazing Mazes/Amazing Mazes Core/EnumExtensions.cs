using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore
{
    /// <summary>
    /// Provides extension methods for working with enum types.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieves the <see cref="DescriptionAttribute"/> value of an enum member, if present; otherwise, returns the enum member's name as a string.
        /// </summary>
        /// <param name="value">The enum value to get the description for.</param>
        /// <returns>The description string if available; otherwise, the enum member's name.</returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo? fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[]?)fi?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes?.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }
    }
}
