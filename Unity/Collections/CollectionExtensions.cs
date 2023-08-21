// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace Unity.Collections
{
    [VisibleToOtherModules]
    internal static class CollectionExtensions
    {
        /// <summary>
        /// Add element to the correct position in presorted List. This methods reduce need to call Sort() on the List.
        /// </summary>
        /// <param name="list">Presorted List</param>
        /// <param name="item">Element to add</param>
        /// <param name="comparer">Comparator if Comparer<T>.Default is not suite</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException">Can throw exception if list is null</exception>
        internal static void AddSorted<T>([DisallowNull] this List<T> list, T item, IComparer<T> comparer = null)
        {
            if (list == null)
                throw new ArgumentNullException($"{nameof(list)} must not be null.");

            comparer ??= Comparer<T>.Default;

            //No elements in the list yet
            if (list.Count == 0)
            {
                list.Add(item);
                return;
            }

            if (comparer.Compare(list[^1], item) <= 0)
            {
                list.Add(item);
                return;
            }

            if (comparer.Compare(list[0], item) >= 0)
            {
                list.Insert(0, item);
                return;
            }

            var index = list.BinarySearch(item, comparer);
            if (index < 0)
                index = ~index;
            list.Insert(index, item);
        }

        /// <summary>
        /// Adds <paramref name="count"/> elements <paramref name="value"/> to the list.
        /// </summary>
        /// <param name="dest">The list to modify.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="count">The number of values to add.</param>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dest"/> is null.</exception>
        public static void Fill<T>(this List<T> dest, T value, int count)
        {
            if (dest == null)
            {
                throw new ArgumentNullException(nameof(dest));
            }

            dest.Capacity = Math.Max(dest.Capacity, dest.Count + count);
            while (count-- > 0)
            {
                dest.Add(value);
            }
        }

        /// <summary>
        /// Returns collections as a string. This can be useful for debug collections in Debug.Log.
        /// String is also Json compatible. It use [ , , ] convention.
        /// </summary>
        /// <param name="collection">Serializable collection</param>
        /// <param name="serializeElement">Function to serialize element of collection</param>
        /// <typeparam name="T">Collection type</typeparam>
        /// <returns>Serialized collection</returns>
        /// <exception cref="ArgumentNullException">Can produce exception if collection or serialize method is null</exception>
        internal static string SerializedView<T> ([DisallowNull] this IEnumerable<T> collection, [DisallowNull] Func<T, string> serializeElement)
        {
            if(collection == null)
                throw new ArgumentNullException($"{nameof(collection)} must not be null.");

            if(serializeElement == null)
                throw new ArgumentNullException($"Argument {nameof(serializeElement)} must not be null.");

            return "[" + string.Join(",", collection.Select(t => t == null ? "null" : serializeElement.Invoke(t))) + "]";
        }
    }
}
