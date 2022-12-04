using System;
using System.Collections.Generic;
using System.Linq;

namespace d_04.Model
{
    public interface ISearchable
    {
        public string Title { get; }
        public bool IsBest { get;  }
    }
    
    public static class SearchableExtensions
    {
        public static T[] Search<T>(this IEnumerable<T> list, string search)
        where T : ISearchable
        {
            IEnumerable<T> res =
                from searchable in list
                where searchable.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                select searchable;
            return res.ToArray();
        }

        public static T Best<T>(this IEnumerable<T> list)
            where T : ISearchable
        {
            return list.FirstOrDefault(x => x.IsBest);
        }
    }

}