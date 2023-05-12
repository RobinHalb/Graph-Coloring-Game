using System;
using System.Collections.Generic;

namespace GraphColoringGame
{
    public static class Extensions
    {
        /*
         * ForEach - performs the action on each element.
         */
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection) action.Invoke(item);
        }
    }
}
