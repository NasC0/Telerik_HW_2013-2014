namespace ImplementHashedTable
{
    public class ImplementHashedTable
    {
        public static void Main()
        {
            HashedTable<int, string> table = new HashedTable<int, string>();
            table.Add(5, "200");
            table[10] = "300";
            table.Add(5, "100");

            System.Console.WriteLine(table.Count);

            foreach (var pair in table)
            {
                System.Console.WriteLine(pair.Value);
            }

            table.Remove(5);

            System.Console.WriteLine(table.Count);

            table.Remove(5);

            System.Console.WriteLine(table.Count);
        }
    }
}
