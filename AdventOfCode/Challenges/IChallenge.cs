using System.Collections.Generic;

namespace AdventOfCode
{
  public interface IChallenge
  {
    string Name { get; }
    string PartOne(IEnumerable<string> input);
    string PartTwo(IEnumerable<string> input);
    IEnumerable<string> ReadInput();
  }
}
