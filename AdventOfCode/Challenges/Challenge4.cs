using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
  enum GuardEvent {
    FallsAsleep,
    WakesUp
  }

  class InputLine {
    public DateTime TimeStamp { get; private set; }
    public string Event { get; private set; }

    public InputLine (string eventLine) {
      string[] parts = eventLine.Split (']');
      TimeStamp = DateTime.Parse (parts[0].Substring (1));
      Event = parts[1].Substring (1);
    }
  }

  class GuardLogEntry {
    public DateTime TimeStamp { get; private set; }
    public GuardEvent Event { get; private set; }

    public GuardLogEntry (DateTime timestamp, GuardEvent @event) {
      Event = @event;
      TimeStamp = timestamp;
    }
  }

  class GuardLog {
    public int Id { get; private set; }
    public List<GuardLogEntry> Entries { get; private set; }
    private int? _mostCommonMinuteAsleep = null;
    private int? _mostCommonMinuteAsleepCount = null;

    public GuardLog (int id) {
      Id = id;
      Entries = new List<GuardLogEntry> ();
    }

    public int GetTotalMinutesAsleep () {
      int minutesAsleep = 0;
      for (int i = 0; i < Entries.Count; i += 2) {
        minutesAsleep += Entries[i + 1].TimeStamp.Minute - Entries[i].TimeStamp.Minute;
      }

      return minutesAsleep;
    }

    public int GetMostCommonMinuteAsleep () {
      if (_mostCommonMinuteAsleep.HasValue) { // memoize
        return _mostCommonMinuteAsleep.Value;
      }

      int[] minutes = new int[60];

      for (int i = 0; i < Entries.Count; i += 2) {
        for (int j = Entries[i].TimeStamp.Minute; j < Entries[i + 1].TimeStamp.Minute; j++) {
          minutes[j]++;
        }
      }

      _mostCommonMinuteAsleepCount = minutes.OrderByDescending (m => m).First ();
      for (int i = 0; i < 60; i++) {
        if (minutes[i] == _mostCommonMinuteAsleepCount) {
          _mostCommonMinuteAsleep = i;
          return i;
        }
      }

      return -1;
    }

    public int GetMostCommonMinuteAsleepCount () {
      return _mostCommonMinuteAsleepCount.Value;
    }
  }

  public class Challenge4 : IChallenge {
    public string Name { get { return "Day 4: Repose Record"; } }

    public IEnumerable<string> ReadInput () {
      return File.ReadAllLines ("./Inputs/4.txt");
    }

    public string PartOne (IEnumerable<string> input) {
      IEnumerable<InputLine> lines = input
        .Select (i => new InputLine (i))
        .OrderBy (e => e.TimeStamp);

      Dictionary<int, GuardLog> guardLogs = new Dictionary<int, GuardLog> ();
      int lastGuardId = 0;

      foreach (InputLine line in lines) {
        if (line.Event[0] == 'G') {
          lastGuardId = Int32.Parse (line.Event.Split ('#') [1].Split (' ') [0]);
          if (!guardLogs.ContainsKey (lastGuardId)) {
            guardLogs.Add (lastGuardId, new GuardLog (lastGuardId));
          }
        } else if (line.Event == "falls asleep") {
          guardLogs[lastGuardId].Entries.Add (new GuardLogEntry (line.TimeStamp, GuardEvent.FallsAsleep));
        } else if (line.Event == "wakes up") {
          guardLogs[lastGuardId].Entries.Add (new GuardLogEntry (line.TimeStamp, GuardEvent.WakesUp));
        }
      }

      GuardLog result = guardLogs.Values.OrderByDescending (l => l.GetTotalMinutesAsleep ()).First ();

      return (result.Id * result.GetMostCommonMinuteAsleep ()).ToString ();
    }

    public string PartTwo (IEnumerable<string> input) {
      IEnumerable<InputLine> lines = input
        .Select (i => new InputLine (i))
        .OrderBy (e => e.TimeStamp);

      Dictionary<int, GuardLog> guardLogs = new Dictionary<int, GuardLog> ();
      int lastGuardId = 0;

      foreach (InputLine line in lines) {
        if (line.Event[0] == 'G') {
          lastGuardId = Int32.Parse (line.Event.Split ('#') [1].Split (' ') [0]);
          if (!guardLogs.ContainsKey (lastGuardId)) {
            guardLogs.Add (lastGuardId, new GuardLog (lastGuardId));
          }
        } else if (line.Event == "falls asleep") {
          guardLogs[lastGuardId].Entries.Add (new GuardLogEntry (line.TimeStamp, GuardEvent.FallsAsleep));
        } else if (line.Event == "wakes up") {
          guardLogs[lastGuardId].Entries.Add (new GuardLogEntry (line.TimeStamp, GuardEvent.WakesUp));
        }
      }

      foreach (GuardLog log in guardLogs.Values) {
        log.GetMostCommonMinuteAsleep ();
      }

      GuardLog result = guardLogs.Values.OrderByDescending (l => l.GetMostCommonMinuteAsleepCount ()).First ();

      return (result.Id * result.GetMostCommonMinuteAsleep ()).ToString ();
    }
  }
}
