using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Appli.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<TItem, TValue>
            (this IEnumerable<TItem> enumerable, Func<TItem, TValue> value, Func<TItem, string> text)
        {
            return enumerable.Select(x => new SelectListItem { Value = value(x).ToString(), Text = text(x) }).ToList();
        }
    }
}