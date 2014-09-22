using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;
namespace BiDictionaryImplementation
{
    public class BiDictionary<KeyOne, KeyTwo, T>
    {
        private MultiDictionary<KeyOne, T> firstKeyDictionary;
        private MultiDictionary<KeyTwo, T> secondKeyDictionary;
        private MultiDictionary<Tuple<KeyOne, KeyTwo>, T> bothKeysDictionary;

        public BiDictionary()
        {
            this.firstKeyDictionary = new MultiDictionary<KeyOne, T>(true);
            this.secondKeyDictionary = new MultiDictionary<KeyTwo, T>(true);
            this.bothKeysDictionary = new MultiDictionary<Tuple<KeyOne, KeyTwo>, T>(true);
        }

        public void Add(KeyOne firstKey, KeyTwo secondKey, T value)
        {
            this.firstKeyDictionary.Add(firstKey, value);
            this.secondKeyDictionary.Add(secondKey, value);
            var keysTuple = new Tuple<KeyOne, KeyTwo>(firstKey, secondKey);
            this.bothKeysDictionary.Add(keysTuple, value);
        }

        public ICollection<T> FindFirstKey(KeyOne key)
        {
            return this.firstKeyDictionary[key];
        }

        public ICollection<T> FindSecondKey(KeyTwo key)
        {
            return this.secondKeyDictionary[key];
        }

        public ICollection<T> Find(KeyOne firstKey, KeyTwo secondKey)
        {
            var keysTuple = new Tuple<KeyOne, KeyTwo>(firstKey, secondKey);
            return this.bothKeysDictionary[keysTuple];
        }
    }
}
