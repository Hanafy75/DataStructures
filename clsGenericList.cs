using System.Collections;

internal class clsGenericList<T> : IEnumerable<T>
{
	#region Fields
	T[] _Items;
	int _Count;
	const int _DefaultCapacity = 4;
	IEqualityComparer<T> _Comparer;
	#endregion

	public T this[int index]
	{
		get
		{
			if ((uint)index >= _Count)
				throw new IndexOutOfRangeException();
			return _Items[index];
		}
		set
		{
			if ((uint)index >= _Count)
				throw new IndexOutOfRangeException();
			_Items[index] = value;

		}
	}

	#region Ctors
	public clsGenericList()
	{
		this._Items = new T[_DefaultCapacity];
		this._Count = 0;
		_Comparer = EqualityComparer<T>.Default;
	}

	public clsGenericList(IEqualityComparer<T> Comparer)
	{
		this._Items = new T[_DefaultCapacity];
		this._Count = 0;
		_Comparer = Comparer;
	}
	public clsGenericList(int Capacity)
	{
		if (Capacity < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(Capacity), "Capacity must be non-negative.");
		}
		this._Items = new T[Capacity];
		this._Count = 0;
		_Comparer = EqualityComparer<T>.Default;
	}
	#endregion

	#region Prop
	public int Count => _Count;

	public int Capacity => _Items.Length;
	#endregion


	#region Methods

	void _AddWithResize(T item)
	{
		int newCapacity = _Items.Length == 0 ? _DefaultCapacity : 2 * _Items.Length;
		T[] newItem = new T[newCapacity];
		Array.Copy(this._Items, newItem, _Count);
		this._Items = newItem;
		this._Items[_Count++] = item;
	}

	void _ShiftForInsertion(int index, int steps = 1)
	{
		for (int i = _Count - 1; i >= index; i--) // {1,2,3,4,null} ==> index 2 -> 3
		{
			_Items[i + steps] = _Items[i];
		}
	}

	public void Add(T Value)
	{
		if (_Count + 1 < _Items.Length) ///////
		{
			_Items[_Count++] = Value;
		}
		else
		{
			_AddWithResize(Value);
		}
	}

	public void RemoveAt(int index)
	{
		if ((uint)index > Count - 1) throw new ArgumentOutOfRangeException();
		Array.Copy(_Items, index + 1, _Items, index, Count - index);/////////
		_Count--;
	}

	public int IndexOf(T Value)
	{
		for (int i = 0; i < _Count; i++)
		{

			if (_Comparer.Equals(Value, _Items[i]))
				return i;
		}
		return -1;
	}

	public int IndexOf(T Value, IEqualityComparer<T> Comparer)
	{// Note That EqualityComparer implement IEqualityComparer so if we passed any class that inherit from EqualityComparer it will be Valid

		for (int i = 0; i < _Count; i++)
		{
			if (Comparer.Equals(Value, _Items[i]))
				return i;
		}
		return -1;
	}

	public bool Remove(T item)
	{
		int index = IndexOf(item);
		if (index < 0) return false;
		RemoveAt(index);
		return true;
	}

	public void Insert(int index, T item)
	{
		// insertion at the end is legal
		if ((uint)index > Count) throw new ArgumentOutOfRangeException();
		_ShiftForInsertion(index);
		_Items[index] = item;
		_Count++;
	}

	public void AddRange(T[] arr)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			Add(arr[i]);
		}
	}

	public void AddRange(IEnumerable<T> Collection)
	{
		foreach (T item in Collection)
			Add(item);
	}

	#endregion

	#region IEnumerable Methods
	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < Count; i++)
		{
			yield return _Items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
	#endregion
}

