using System;
namespace BiDictionaryImplementation
{
    public class BiDictionaryImplementation
    {
        public static void Main()
        {
            BiDictionary<string, int, int> biDictionary = new BiDictionary<string, int, int>();
            biDictionary.Add("One", 2, 3);

            var stringKeysValues = biDictionary.FindFirstKey("One");
            foreach (var pair in stringKeysValues)
            {
                Console.WriteLine(pair);
            }

            var intKeysValues = biDictionary.FindSecondKey(2);
            foreach (var pair in intKeysValues)
            {
                Console.WriteLine(pair);
            }
        }
    }
}
