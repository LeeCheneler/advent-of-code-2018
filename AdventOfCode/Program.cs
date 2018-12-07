using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
  class Program
  {
    private static Stopwatch stopWatch;

    static void RunWeek1()
    {
      FrequencyCalibrator calibrator = new FrequencyCalibrator();
      IEnumerable<int> frequencies = FrequencyCalibrator.ReadFrequencies();

      stopWatch = Stopwatch.StartNew();
      int sum = calibrator.Sum(frequencies);
      stopWatch.Stop();
      Console.WriteLine($"Sum: {sum} ({stopWatch.ElapsedMilliseconds}ms)");

      stopWatch = Stopwatch.StartNew();
      int firstDuplicate = calibrator.FindFirstDuplicate(frequencies);
      stopWatch.Stop();
      Console.WriteLine($"First duplicate: {firstDuplicate} ({stopWatch.ElapsedMilliseconds}ms)");
    }


    static void Main(string[] args)
    {
      RunWeek1();
    }
  }
}
