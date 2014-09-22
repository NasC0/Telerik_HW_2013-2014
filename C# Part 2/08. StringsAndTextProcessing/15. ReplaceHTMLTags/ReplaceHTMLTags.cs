/* 15. Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. */

using System;
using System.Collections.Generic;
using System.Text;

class ReplaceHTMLTags
{
    static string HyperlinkTagReplace(string input)
    {
        string duplicate = input;
        StringBuilder sb = new StringBuilder();
        List<string> subStrings = new List<string>();
        while (true)
        {
            input = input.Remove(0, input.IndexOf(@"<a href="));
            int end = input.IndexOf(@"</a>");
            subStrings.Add(input.Substring(0, end + 4));
            int start = input.IndexOf("\"") + 1;
            int secondEnd = input.IndexOf(">") - 1;
            sb.Append("[URL=");
            sb.Append(input.Substring(start, secondEnd - start));
            sb.Append("]");
            input = input.Remove(0, input.IndexOf(">") + 1);
            sb.Append(input.Substring(0, input.IndexOf("<")));
            sb.Append("[/URL]");
            subStrings.Add(sb.ToString());
            sb.Clear();
            if (input.IndexOf("<a href") == -1)
            {
                break;
            }
            else
            {
                input = input.Remove(0, input.IndexOf("<a href"));
            }
        }
        for (int i = 0; i < subStrings.Count; i = i + 2)
        {
            duplicate = duplicate.Replace(subStrings[i], subStrings[i + 1]);
        }
        return duplicate;
    }

    static void Main()
    {
        string input = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        string duplicate = HyperlinkTagReplace(input);
        Console.WriteLine(duplicate);
    }
}
