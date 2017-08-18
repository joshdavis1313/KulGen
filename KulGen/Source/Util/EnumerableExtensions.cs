using System;
using System.Collections.Generic;
using System.Linq;

namespace KulGen.Util
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Iterates through this enumerable and applies the provided action to each item.
		/// </summary>
		/// <param name="action">The action to apply to each item.</param>
		/// <param name="ignoreNulls">If true, null values within this enumerable will be skipped.</param>
		public static void DoForEach<E>(this IEnumerable<E> list, Action<E> action, bool ignoreNulls = false)
		{
			foreach (var item in list)
			{
#pragma warning disable RECS0017 // Possible compare of value type with 'null'
				if (ignoreNulls && item == null)
				{
#pragma warning restore RECS0017 // Possible compare of value type with 'null'
					continue;
				}
				action (item);
			}
		}

		/// <summary>
		/// Returns a copy of this enumerable with any null references excluded.
		/// </summary>
		public static IEnumerable<E> ExcludingNulls<E>(this IEnumerable<E> list) where E : class
		{
			return list.Where ((item) => { return item != null; });
		}

		public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> instance, int partitionSize)
		{
			return instance
				.Select ((value, index) => new { Index = index, Value = value })
				.GroupBy (i => i.Index / partitionSize)
				.Select (i => i.Select (i2 => i2.Value));
		}

		public static int CountSafe<TData>(this IEnumerable<TData> enumerable)
		{
			return (enumerable?.Count ()).GetValueOrDefault ();
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) where T : class
		{
			return list == null || list.CountSafe () == 0;
		}

		public static List<TData> BoundDataWithoutModification<TData>(this IEnumerable<TData> data, Func<TData, double> dataSelector, Func<TData, double, TData> newValue, double? min = null, double? max = null)
		{
			var newData = new List<TData> ();

			if (min.HasValue && max.HasValue && max.Value < min.Value)
			{
				max = min.Value;
			}

			foreach (var p in data)
			{
				var val = dataSelector (p);

				if (min.HasValue && val < min.Value)
				{
					val = min.Value;
				}
				if (max.HasValue && val > max.Value)
				{
					val = max.Value;
				}

				newData.Add (newValue (p, val));
			}

			return newData;
		}
	}
}
