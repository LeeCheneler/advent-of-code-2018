using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
  class Program
  {
    static void Main(string[] args)
    {
      ChallengeRunner runner = new ChallengeRunner();
      runner.Run(new List<IChallenge>() {
        new Challenge1(),
        new Challenge2(),
        new Challenge3()
      });
    }
  }
}
