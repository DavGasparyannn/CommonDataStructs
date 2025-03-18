using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataStructs.Structs.HashStructs
{
    public record MultiValuedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, List<TValue>>>
    {
        private int _size;
        private int _currentCount;
        private List<DictionaryEntry>[] _buckets = default!;

        private int Initialize(int capacity)
        {
            int size = GetNextPrime(capacity);
            var buckets = new List<DictionaryEntry>[size];
            _size = size;
            _buckets = buckets;
            return size;
        }
        public MultiValuedDictionary() { }
        public MultiValuedDictionary(int size)
        {
            _size = size;
            _buckets = new List<DictionaryEntry>[size];
        }
        public List<TValue> this[TKey key]
        {
            get => GetValues(key);
            set
            {
                uint index = GetIndex(key);
                if (_buckets![index] == null)
                {
                    _buckets[index] = new List<DictionaryEntry>();
                }

                for (int i = 0; i < _buckets[index].Count; i++)
                {
                    var entry = _buckets[index][i];
                    if (entry.key!.Equals(key))
                    {
                        _buckets[index][i] = new DictionaryEntry { key = key, values = value };
                        return;
                    }
                }

                _buckets[index].Add(new DictionaryEntry { key = key, values = value });
                _currentCount++;

                if (_currentCount >= _size)
                {
                    Resize();
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Argument is null");
            }
            if (_buckets == null)
            {
                Initialize(3);
            }
            var index = GetIndex(key);
            if (_buckets![index] == null)
            {
                _buckets[index] = new List<DictionaryEntry>();
            }


            foreach (var entry in _buckets[index])
            {
                if (entry.key!.Equals(key))
                {
                    entry.values.Add(value);
                    return;
                }
            }
            _buckets[index].Add(new DictionaryEntry { key = key, values = new List<TValue> { value } });
            _currentCount++;

            if (_currentCount >= _size)
            {
                Resize();
            }
        }
        public void Remove(TKey key)
        {
            var index = GetIndex(key);
            if (_buckets[index].Count == 0)
            {
                throw new KeyNotFoundException($"Key {key} not found");
            }

            foreach (var entry in _buckets[index])
            {
                if (entry.key!.Equals(key))
                {
                    _buckets[index].Remove(entry);
                    return;
                }
            }
        }
        public bool ContainsKey(TKey key)
        {
            var index = GetIndex(key);
            if (_buckets[index].Count == 0)
            {
                return false;
            }
            foreach (var entry in _buckets[index])
            {
                if (entry.key!.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ContainsValue(TValue value)
        {
            foreach (var bucket in _buckets)
            {
                if (bucket != null || bucket!.Count != 0)
                {
                    foreach (var entry in bucket)
                    {
                        if (entry.values.Contains(value))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool ContainsValueFromKey(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Argument is null");
            }
            uint index = GetIndex(key);
            if (_buckets![index] == null || _buckets[index].Count == 0)
            {
                throw new KeyNotFoundException($"Key {key} not found");
            }
            bool keyFound = false;
            foreach (var entry in _buckets[index])
            {
                if (entry.key!.Equals(key))
                {
                    keyFound = true;
                    if (entry.values.Contains(value))
                    {
                        return true;
                    }
                }
            }
            if (!keyFound)
            {
                throw new KeyNotFoundException($"Key {key} not found");
            }
            return false;
        }
        public List<TValue> GetValues(TKey key)
        {
            var index = GetIndex(key);
            if (_buckets[index].Count == 0)
            {
                throw new KeyNotFoundException($"Key {key} not found");
            }
            foreach (var entry in _buckets[index])
            {
                if (entry.key!.Equals(key))
                {
                    return entry.values;
                }
            }
            throw new KeyNotFoundException($"Key {key} not found");

        }
        public bool TryGetValue(TKey key, out List<TValue> values)
        {
            var index = GetIndex(key);
            try
            {
                var getedValues = GetValues(key);
                values = getedValues;
                return true;
            }
            catch (KeyNotFoundException)
            {
                values = default!;
                return false;

            }
        }
        public void Clear()
        {
            _buckets = new List<DictionaryEntry>[_size];
            _currentCount = 0;
        }
        public int Count() => _currentCount;
        private void Resize()
        {
            var newSize = GetNextPrime(_size * 2);
            _size = newSize;
            var newBuckets = new List<DictionaryEntry>[newSize];


            for (int i = 0; i < newSize; i++)
            {
                newBuckets[i] = new List<DictionaryEntry>();
            }

            // Переносим элементы из старого массива
            foreach (var bucket in _buckets)
            {
                if (bucket != null)
                {
                    foreach (var entry in bucket)
                    {
                        var index = GetIndex(entry.key);
                        newBuckets[index].Add(entry);
                    }
                }
            }

            _buckets = newBuckets;
        }
        private uint GetIndex(TKey key)
        {
            return (uint)Math.Abs(key!.GetHashCode() % _size);
        }
        private struct DictionaryEntry
        {
            public TKey key;
            public List<TValue> values;
        }
        private int GetNextPrime(int size)
        {
            if (size < 2)
                return 2;
            int next = size + 1;
            while (!isPrime(next))
            {
                next++;
            }
            return next;

        }
        private bool isPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            if (number == 2 || number == 3)
            {
                return true;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
        {
            foreach (var bucket in _buckets)
            {
                if (bucket != null)
                {
                    foreach (var entry in bucket)
                    {
                        yield return new KeyValuePair<TKey, List<TValue>>(entry.key, entry.values);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
