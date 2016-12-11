using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SObjectRepository.Repository.ChainCollection
{
	public class Chain<T> : IEnumerator<T>, IEnumerable<T>, IDisposable, IEnumerable, IFormattable
		where T:IEquatable<T>
		
	{

		public T[] items;
		private int index = -1;

		private T[] GenerateAddArray()
		{
			T[] items = new T[this.items.Length + 1];
			for (int i = 0; i < this.items.Length; i++)
				items[i] = this.items[i];
			return items;
		}
		private T[] GenerateDeleteArray(int index)
		{
			T[] items = new T[this.items.Length - 1];
			for (int i = 0, j = 0; i < this.items.Length; i++)
				if (i == index)
					continue;
				else
					items[j++] = this.items[i];
			return items;
		}
		private bool IsExistAt(int index)
		{
			return (index >= 0 && index < items.Length) ? (true) : (false);
		}

		public bool IsIncluded(T item)
		{
			foreach (var x in this)
				if (x.Equals(item))
					return true;
			return false;
		}
		public T this[int i]
		{
			get{return items[i];}
			set{items[i] = value;}
		}

		public bool Delete(T item)
		{
			return DeleteAt(IndexOf(item));
		}
		public Int32 IndexOf(T item)
		{
			for(int i=0; i< Length; i++)
				if (((object)items[i]).Equals((object)item))
					return i;
			return -1;
		}
		public bool DeleteAt(int index)
		{
			if (IsExistAt(index))
			{
				items = GenerateDeleteArray(index);
				return true;
			}
			else
				return false;			
		}
		
		
		public int Length
		{
			get
			{
				return items.Length;
			}
		}

		public void Add(T item)
		{
			items = GenerateAddArray();
			items[items.Length - 1] = item;
		}
		
		public Chain()
		{
			this.items = new T[] { };
		}
		public Chain(T[] items)
		{
			this.items = items;
		}

		public T Current
		{
			get
			{
				return items[index];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return (object)this.items[index];
			}
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (index == items.Length - 1)
			{
				Reset();
				return false;
			}
			index++;
			return true;
		}

		public void Reset()
		{
			index = -1;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			
			return String.Format("Chain<{0}>", typeof(T));
		}

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return ((IEnumerable<T>)items).GetEnumerator();
		}
	}
}
