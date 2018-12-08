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

    static void RunDay1()
    {
      Console.WriteLine("--- Day 1: Chronal Calibration ---");

      FrequencyCalibrator calibrator = new FrequencyCalibrator();
      IEnumerable<int> frequencies = FrequencyCalibrator.GetReadFrequencies();

      stopWatch = Stopwatch.StartNew();
      int sum = calibrator.Sum(frequencies);
      stopWatch.Stop();
      Console.WriteLine($"Sum: {sum} ({stopWatch.ElapsedMilliseconds}ms)");

      stopWatch = Stopwatch.StartNew();
      int firstDuplicate = calibrator.FindFirstDuplicate(frequencies);
      stopWatch.Stop();
      Console.WriteLine($"First duplicate: {firstDuplicate} ({stopWatch.ElapsedMilliseconds}ms)");
    }

    static void RunDay2()
    {
      Console.WriteLine("--- Day 2: Inventory Management System ---");

      BoxScanner scanner = new BoxScanner();
      IEnumerable<string> ids = BoxScanner.ReadBoxIds();

      stopWatch = Stopwatch.StartNew();
      int checksum = scanner.CalculateChecksum(ids);
      stopWatch.Stop();
      Console.WriteLine($"Checksum: {checksum} ({stopWatch.ElapsedMilliseconds}ms)");

      stopWatch = Stopwatch.StartNew();
      string commonLetters = scanner.FindCommonLetters(ids);
      stopWatch.Stop();
      Console.WriteLine($"Common letters: {commonLetters} ({stopWatch.ElapsedMilliseconds}ms)");
    }

    static void Main(string[] args)
    {
      RunDay1();
      RunDay2();
    }
  }
}
