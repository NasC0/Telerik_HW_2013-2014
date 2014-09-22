using BugsReporter.Data;
using BugsReporter.Models;

namespace BugsReporter.ConsoleClient
{
    public class ConsoleClient
    {
        public static void Main()
        {
            var bugsData = new BugsData();
            var bug = new Bug()
            {
                Text = "Pishki"
            };

            bugsData.Bugs.Add(bug);
            bugsData.SaveChanges();
        }
    }
}
