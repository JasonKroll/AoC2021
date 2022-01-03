using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day12 : DayBase
    {
        public override string Name => "Day 12";

        public List<int> Inputs { get; } = new List<int>();

        public Day12(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {
            var caves = GetCaves();

            var currentPaths = ImmutableList<Cave>.Empty.Add(caves["start"]);
            var paths = GetPaths(caves, "start", currentPaths, 1);

            return paths.Count();
        }

        public override object Answer2()
        {
            var caves = GetCaves();

            var currentPaths = ImmutableList<Cave>.Empty.Add(caves["start"]);
            var paths = GetPaths(caves, "start", currentPaths, 2);

            return paths.Count();
        }

        private Dictionary<string, Cave> GetCaves()
        {
            Dictionary<string, Cave> caves = new();
            foreach (var item in InputData)
            {
                string[]? caveNames = item.Split("-");
                if (!caves.ContainsKey(caveNames[0]))
                {
                    caves.Add(caveNames[0], new Cave(caveNames[0]));
                }

                if (!caves.ContainsKey(caveNames[1]))
                {
                    caves.Add(caveNames[1], new Cave(caveNames[1]));
                }

                Cave? cave1 = caves[caveNames[0]];
                Cave? cave2 = caves[caveNames[1]];
                if (!cave1.Connections.Contains(cave2))
                    cave1.Connections.Add(cave2);

                if (!cave2.Connections.Contains(cave1))
                    cave2.Connections.Add(cave1);

            }
            return caves;
        }

        private ImmutableList<ImmutableList<Cave>> GetPaths(Dictionary<string, Cave> caves, string currentCaveName, ImmutableList<Cave> currentPath, int maxVisits = 1)
        {
            var cave = caves[currentCaveName];
            if (cave.IsEnd)
            {
                return ImmutableList<ImmutableList<Cave>>.Empty.Add(currentPath);
            }

            var paths = ImmutableList<ImmutableList<Cave>>.Empty;

            foreach (Cave connectingCave in cave.Connections)
            {
                if (!ValidCave(currentPath, connectingCave, maxVisits))
                    continue;
                
                var newPaths = GetPaths(caves, connectingCave.Name, currentPath.Add(connectingCave), maxVisits);
                paths = paths.AddRange(newPaths);
            }

            return paths;
        }

        private static bool ValidCave(ImmutableList<Cave> currentPaths, Cave cave, int maxVisits)
        {
            if (!cave.IsMinor && !cave.IsStart)
                return true;

            if (cave.IsStart)
                return false;

            var minors = currentPaths
                .Where(x => x.IsMinor)
                .Where(x => !x.IsStart);

            var hasMaxCountAlready = minors.Any() && minors
                .GroupBy(x => x.Name)
                .Select(x => x.Count())
                .Max() == maxVisits && maxVisits > 1;

            int currentMaxVisits = hasMaxCountAlready ? 1 : maxVisits;

            var currentCount = currentPaths.Where(x => x == cave).Count();

            return currentCount < currentMaxVisits;
        }
    }


    public class Cave
    {
        public string Name { get; set; }
        public List<Cave> Connections { get; } = new List<Cave>();
        public bool IsMinor => Name.ToCharArray().Any(x => Char.IsLower(x));
        public bool IsStart => Name == "start";
        public bool IsEnd => Name == "end";

        public Cave(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {(Connections.Count)}";
        }
    }
}


