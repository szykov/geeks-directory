using System.Collections.Generic;
using System.Linq;

namespace GeeksDirectory.SharedTypes.Extensions
{
    public static class NotNullOrEmptyExtension
    {
        public static bool NotNullOrEmpty<T>(this IEnumerable<T> source) => source != null && source.Any();

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();
    }
}
