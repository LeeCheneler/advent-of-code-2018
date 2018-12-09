using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
  class CutoutClaim {
    public string Id { get; private set; }
    public int Left { get; private set; }
    public int Top { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public CutoutClaim (string claim) {
      string[] parts = claim.Split (' ');

      Id = parts[0].Substring (1);

      string[] positionParts = parts[2].Split (',');
      Left = Int32.Parse (positionParts[0]);
      Top = Int32.Parse (positionParts[1].Split (':') [0]);

      string[] sizeParts = parts[3].Split ('x');
      Width = Int32.Parse (sizeParts[0]);
      Height = Int32.Parse (sizeParts[1]);
    }
  }

  public class Challenge3 : IChallenge {
    public string Name { get { return "Day 3: No Matter How You Slice It"; } }

    public IEnumerable<string> ReadInput () {
      return File.ReadAllLines ("./Inputs/3.txt");
    }

    public string PartOne (IEnumerable<string> input) {
      IEnumerable<CutoutClaim> claims = input.Select (claim => new CutoutClaim (claim));

      int[][] sheet = new int[1000][];
      for (int i = 0; i < 1000; i++) {
        sheet[i] = new int[1000];
      }

      foreach (CutoutClaim claim in claims) {
        for (int i = claim.Left; i < claim.Left + claim.Width; i++) {
          for (int j = claim.Top; j < claim.Top + claim.Height; j++) {
            sheet[i][j]++;
          }
        }
      }

      int overlaps = 0;
      for (int i = 0; i < 1000; i++) {
        for (int j = 0; j < 1000; j++) {
          if (sheet[i][j] > 1) {
            overlaps++;
          }
        }
      }

      return overlaps.ToString ();
    }

    public string PartTwo (IEnumerable<string> input) {
      IEnumerable<CutoutClaim> claims = input.Select (claim => new CutoutClaim (claim));

      int[][] sheet = new int[1000][];
      for (int i = 0; i < 1000; i++) {
        sheet[i] = new int[1000];
      }

      foreach (CutoutClaim claim in claims) {
        for (int i = claim.Left; i < claim.Left + claim.Width; i++) {
          for (int j = claim.Top; j < claim.Top + claim.Height; j++) {
            sheet[i][j]++;
          }
        }
      }

      foreach (CutoutClaim claim in claims) {
        int totalChecks = claim.Width * claim.Height;
        int checks = 0;
        bool shouldBreak = false;

        for (int i = claim.Left; i < claim.Left + claim.Width; i++) {
          for (int j = claim.Top; j < claim.Top + claim.Height; j++) {
            if (sheet[i][j] > 1) {
              shouldBreak = true;
            }

            checks++;
          }

          if (shouldBreak) {
            break;
          } else if (checks == totalChecks) {
            return claim.Id;
          }
        }
      }

      return "Not found :(";
    }
  }
}
