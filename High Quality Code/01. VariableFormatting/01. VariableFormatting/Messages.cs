using System.Text;

namespace VariableFormatting
{
    public static class Messages
    {
        private static readonly StringBuilder output = new StringBuilder();

        public static StringBuilder Output
        {
            get
            {
                return output;
            }
        }

        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int eventCount)
        {
            if (eventCount == 0)
                NoEventsFound();

            else
                output.AppendFormat("{0} events deleted\n", eventCount);
        }

        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }
}