namespace HashedSetImplementation
{
    public class HashedSetImplementation
    {
        public static void Main()
        {
            HashedSet<string> hashedSet = new HashedSet<string>();
            hashedSet.Add("Pesho");
            hashedSet.Add("Gosho");
            hashedSet.Add("Misho");

            string foundString = hashedSet.Find("Pesho");

            System.Console.WriteLine(foundString);

            hashedSet.Remove("Pesho");
            System.Console.WriteLine(hashedSet.Count);
            hashedSet.Clear();
            System.Console.WriteLine(hashedSet.Count);
        }
    }
}
