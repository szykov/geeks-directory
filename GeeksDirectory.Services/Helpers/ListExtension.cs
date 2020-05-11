using System.Collections.Generic;

namespace GeeksDirectory.Services.Helpers
{
    public static class ListExtension
    {
        public static void AddIfNotEmpty<T>(this List<T> list, T item)
        {
            if (item != null)
                list.Add(item);
        }
    }
}
