using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode {
  public interface IChallengeRunner {
    void Run (IEnumerable<IChallenge> challenges);
  }

  public class ChallengeRunner : IChallengeRunner {
    public void Run (IEnumerable<IChallenge> challenges) {
      Stopwatch stopWatch = null;
      foreach (IChallenge challenge in challenges) {
        Console.WriteLine ($"{Environment.NewLine}--- {challenge.Name} ---{Environment.NewLine}");

        stopWatch = Stopwatch.StartNew ();
        string partOneResult = challenge.PartOne (challenge.ReadInput ());
        stopWatch.Stop ();

        Console.WriteLine ($"Part One: {partOneResult} ({stopWatch.ElapsedMilliseconds}ms)");

        stopWatch = Stopwatch.StartNew ();
        string partTwoResult = challenge.PartTwo (challenge.ReadInput ());
        stopWatch.Stop ();

        Console.WriteLine ($"Part Two: {partTwoResult} ({stopWatch.ElapsedMilliseconds}ms)");
      }
    }
  }
}
