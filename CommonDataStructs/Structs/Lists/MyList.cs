using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataStructs.Structs.Lists
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _size;
        private int _capacity;
        private double resizeIndex = 0.75;
        public MyList()
        {
            _capacity = 4;
            _array = new T[_capacity];
            _size = 0;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > _size)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index > _capacity)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }
        public void Add(T item)
        {
            if(_size != 0 && (double)_size/_capacity  >= resizeIndex)
            {
                Resize();
            }
            _array[_size++] = item;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public void Remove(T item)
        {
            int index = Array.IndexOf(_array, item, 0, _size);
            if (index == -1)
            {
                return;
            }
            RemoveAt(index);
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _size - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _size--;
        }
        public int Length => _size;
        public int Capacity() => _capacity;
        private void Resize()
        {
            _capacity *= 2;
            T[] newArray = new T[_capacity];
            Array.Copy(_array, newArray, _size);
            _array = newArray;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
