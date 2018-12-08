using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
  public class BoxScanner
  {
    public static IEnumerable<string> ReadBoxIds()
    {
      return File.ReadAllLines("./Day2/box-ids.txt");
    }

    public int CalculateChecksum(IEnumerable<string> ids)
    {
      int containsDouble = 0;
      int containsTriple = 0;

      foreach (string id in ids)
      {
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();

        foreach (char c in id)
        {
          if (!letterCounts.ContainsKey(c))
          {
            letterCounts.Add(c, 1);
          }
          else
          {
            letterCounts[c]++;
          }
        }

        if (letterCounts.Values.Any(count => count == 2))
        {
          containsDouble++;
        }

        if (letterCounts.Values.Any(count => count == 3))
        {
          containsTriple++;
        }
      }

      return containsDouble * containsTriple;
    }

    public string FindCommonLetters(IEnumerable<string> ids)
    {
      for (int i = 0; i < ids.First().Length; i++)
      {
        IEnumerable<string> matches = ids
          .Select(id => id.Remove(i, 1))
          .GroupBy(x => x)
          .Where(group => group.Count() > 1)
          .Select(group => group.Key);

        if (matches.Count() > 0)
        {
          return matches.First();
        }
      }

      return null;
    }
  }
}
