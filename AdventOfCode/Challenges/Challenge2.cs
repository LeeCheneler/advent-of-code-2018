using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
  public class Challenge2 : IChallenge
  {
    public string Name { get { return "Day 2: Inventory Management System"; } }

    public IEnumerable<string> ReadInput()
    {
      return File.ReadAllLines("./Inputs/2.txt");
    }

    public string PartOne(IEnumerable<string> input)
    {
      int containsDouble = 0;
      int containsTriple = 0;

      foreach (string id in input)
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

      return (containsDouble * containsTriple).ToString();
    }

    public string PartTwo(IEnumerable<string> input)
    {
      string match = null;

      for (int i = 0; i < input.First().Length; i++)
      {
        IEnumerable<string> matches = input
          .Select(id => id.Remove(i, 1))
          .GroupBy(x => x)
          .Where(group => group.Count() > 1)
          .Select(group => group.Key);

        if (matches.Count() > 0)
        {
          match = matches.First();
        }
      }

      return match;
    }
  }
}
