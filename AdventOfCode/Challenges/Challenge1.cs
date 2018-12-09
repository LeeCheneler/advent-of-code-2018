using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
  public class Challenge1 : IChallenge {
    public string Name { get { return "Day 1: Chronal Calibration"; } }

    public IEnumerable<string> ReadInput () {
      return File.ReadAllLines ("./Inputs/1.txt");
    }

    public string PartOne (IEnumerable<string> input) {
      return input.Select ((string f) => Int32.Parse (f)).Sum ().ToString ();
    }

    public string PartTwo (IEnumerable<string> input) {
      return FindFirstDuplicate (
        input.Select ((string f) => Int32.Parse (f)),
        new HashSet<int> () { 0 }).ToString ();
    }

    private int FindFirstDuplicate (
      IEnumerable<int> frequencies,
      HashSet<int> previousFrequencies = null,
      int totalFrequency = 0) {
      foreach (int frequency in frequencies) {
        totalFrequency += frequency;

        if (previousFrequencies.Contains (totalFrequency)) {
          return totalFrequency;
        }

        previousFrequencies.Add (totalFrequency);
      }

      return FindFirstDuplicate (frequencies, previousFrequencies, totalFrequency);
    }
  }
}
