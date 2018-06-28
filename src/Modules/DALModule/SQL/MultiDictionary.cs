using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SQL
{
    [SerializableAttribute]
    [ComVisibleAttribute(false)]
    public class MultiDictionary<TKey, TValue> :
    ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>,
    IEnumerable, ICollection,
    IReadOnlyCollection<KeyValuePair<TKey, TValue>>
    {

        private IDictionary<TKey, List<TValue>> _singleDictionary = new Dictionary<TKey, List<TValue>>();


        public ICollection<TKey> Keys => _singleDictionary.Keys;

        public ICollection<TValue> Values {
            get
            {
                ICollection<TValue> values = new List<TValue>();
                foreach (var key in _singleDictionary.Keys)
                {
                    var currentValue = _singleDictionary[key];
                    foreach (var current in currentValue)
                    {
                        values.Add(current);
                    }
                }
                return values;
            }
           
        }

        public int Count => Keys.Count;

        public bool IsReadOnly => false;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => false;

        public bool IsFixedSize => false;
        //  public T this[int i]

        public ICollection<TValue> this[TKey tkey]
        {
            get { return _singleDictionary[tkey]; }
            set
            {
                Add(tkey, value);
            }
        }
        public void Add(TKey key, TValue value)
        {
            if (_singleDictionary.ContainsKey(key))
            {
                // ok add the multivalue
                _singleDictionary[key].Add(value);
          
            }
            else
            {
                var list = new List<TValue>();
                list.Add(value);
                _singleDictionary.Add(key, list);
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            var key = item.Key;
            var value = item.Value;
            Add(key, value);
        }

        public void Add(object key, object value)
        {
            if ((key is TKey) && (value is TValue))
            {
                Add((TKey)key, (TValue)value);
                return;
            }
            throw new FormatException();
        }
        public void Clear()
        {
            var keys = Keys;

            foreach (var key in Keys)
            {
                var list = _singleDictionary[key];
                list.Clear();
                list = null;
            }
            _singleDictionary.Clear();
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var key = item.Key;
            var value = item.Value;
            if (!_singleDictionary.ContainsKey(key))
            {
                return false;
            }
            var line = _singleDictionary[key];
            return line.Contains(value);
        }

        public bool Contains(object key)
        {
            if (!(key is TValue))
                return false;
            var tmp = (TValue)key;
            var list = _singleDictionary.Values;
            bool contains = true;
            foreach (var bucket in list)
            {
                contains = contains && bucket.Contains(tmp);
            }
            return contains;
        }

        public bool ContainsKey(TKey key)
        {
            return _singleDictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var currentPos = GetEnumerator();

            for (int i = arrayIndex; i < array.Length; ++i)
            {
                if (currentPos.MoveNext())
                {
                    var copy = new KeyValuePair<TKey, TValue>(currentPos.Current.Key, currentPos.Current.Value);
                    array[i] = copy;
                }
                else
                {
                    break;
                }
            }
        }

        public void CopyTo(Array array, int index)
        {
            CopyTo(array, index);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            ICollection<KeyValuePair<TKey, TValue>> flatten = new List<KeyValuePair<TKey, TValue>>();
            foreach (var key in _singleDictionary.Keys)
            {
                var myDictionary = _singleDictionary[key];
                foreach (var item in myDictionary)
                {
                    var tmpKeys = new KeyValuePair<TKey, TValue>(key, item);
                    flatten.Add(tmpKeys);
                }
            }
            return flatten.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            if (!_singleDictionary.ContainsKey(key))
            {
                return false;
            }
            else
            {
                // i shall remove the item and each item in the list
                var currentList = _singleDictionary[key];
                currentList.Clear();
                currentList = null;
                _singleDictionary.Remove(key);
            }
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var key = item.Key;
            return Remove(key);
        }

        public void Remove(object key)
        {
            if (key is TKey)
            {
                Remove(key);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!_singleDictionary.ContainsKey(key))
            {
                value = default(TValue);
                return false;
            }
            var currentList = _singleDictionary[key];
            var currentFirst = currentList.FirstOrDefault<TValue>();
            value = currentFirst;
            return true;
        }
        public bool TryGetValue(TKey key, out ICollection<TValue> values)
        {
            if (!_singleDictionary.ContainsKey(key))
            {
                values = new List<TValue>();
                return false;
            }
            var currentList = _singleDictionary[key];
            values = currentList;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _singleDictionary.GetEnumerator();
        }
      
    }
}
