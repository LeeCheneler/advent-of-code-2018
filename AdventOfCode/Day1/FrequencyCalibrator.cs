using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
  public class FrequencyCalibrator
  {
    public static IEnumerable<int> GetReadFrequencies()
    {
      return File.ReadAllLines("./Day1/frequencies.txt").Select((string f) => Int32.Parse(f));
    }

    public int Sum(IEnumerable<int> frequencies)
    {
      return frequencies.Sum();
    }

    public int FindFirstDuplicate(IEnumerable<int> frequencies)
    {
      return RecursiveFindFirstDuplicate(
        frequencies,
        new HashSet<int>() { 0 });
    }

    private int RecursiveFindFirstDuplicate(
      IEnumerable<int> frequencies,
      HashSet<int> previousFrequencies = null,
      int totalFrequency = 0)
    {
      foreach (int frequency in frequencies)
      {
        totalFrequency += frequency;

        if (previousFrequencies.Contains(totalFrequency))
        {
          return totalFrequency;
        }

        previousFrequencies.Add(totalFrequency);
      }

      return RecursiveFindFirstDuplicate(frequencies, previousFrequencies, totalFrequency);
    }
  }
}
