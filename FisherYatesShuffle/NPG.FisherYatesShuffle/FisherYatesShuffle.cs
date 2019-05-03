using System;
using System.Collections.Generic;
using System.Linq;

namespace NPG.FisherYatesShuffle
{
	public class FisherYatesShuffle<T>
	{
		private readonly Random _random;
		private readonly List<T> _source;

		private int _borderIndex;

		public int Count
		{
			get { return _source.Count; }
		}

		public FisherYatesShuffle(IEnumerable<T> source = null)
		{
			if (source == null)
			{
				_source = new List<T>();
			}
			else
			{
				_source = source.ToList();
			}

			_random = new Random();

			Reset();
		}

		public void Reset()
		{
			_borderIndex = _source.Count;
		}

		public void Add(T element)
		{
			_source.Add(element);
			Reset();
		}

		public T GetRandomValue()
		{
			if (!HasRandomValue())
			{
				return default(T);
			}

			var index = _random.Next(0, _borderIndex);
			_borderIndex -= 1;
			
			var result = _source[index];
			_source[index] = _source[_borderIndex];
			_source[_borderIndex] = result;

			return result;
		}

		public bool HasRandomValue()
		{
			return _borderIndex > 0;
		}
	}
}