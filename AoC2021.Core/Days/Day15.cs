using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day15 : DayBase
    {
        public override string Name => "Day 15";

        public List<int> Inputs { get; } = new List<int>();

        public Day15(List<string> inputs) : base(inputs)
        {
        }

        public Dictionary<Location, Node> GetNodes()
        {
            List<List<int>>? grid = InputData
                .Select(x => x.ToCharArray().Select(c => c.ToString()).Select(int.Parse).ToList())
                .ToList();
            Dictionary<Location, Node> nodes = new();
            for (int r = 0; r < grid.Count; r++)
            {
                var row = grid[r];
                for (int c = 0; c < row.Count; c++)
                {
                    var loc = new Location(r, c);
                    var node = new Node()
                    {
                        Location = loc,
                        LowestRiskPath = int.MaxValue,
                        Risk = grid[r][c]
                    };
                    nodes.Add(loc, node);
                }
            }
            return nodes;
        }

        private List<Node> GetNeighbours(Location location, Dictionary<Location, Node> nodes)
        {
            var neighbours = new List<Node>();
            var locations = new List<Location>
            {
                new Location(location.Row - 1, location.Col),
                new Location(location.Row + 1, location.Col),
                new Location(location.Row, location.Col - 1),
                new Location(location.Row, location.Col + 1),
            };
            foreach (var item in locations)
            {
                if (nodes.TryGetValue(item, out var n))
                    neighbours.Add(n);
            }
            return neighbours;
        }

        private void SetValues(Location location, Dictionary<Location, Node> nodes)
        {
            Node node = nodes[location];
            List<Node> neighbours = GetNeighbours(location, nodes);
            var riskValues = neighbours.Select(x => x.LowestRiskPath).ToList();
            riskValues.Add(node.LowestRiskPath);

            var lowest = riskValues.Min() + node.Risk;
            
            if (lowest < node.LowestRiskPath)
                node.LowestRiskPath = lowest;
            //node.LowestRiskPath = lowest;
        }

        private Dictionary<Location, Node> ScaleInput(Dictionary<Location, Node> nodes, int factor)
        {
            var newNodes = new Dictionary<Location, Node>();
            
            for (int c = 0; c < factor; i++)
            {
                for (int r = 0; r < factor; r++)
                {
                    foreach (var node in nodes)
                    {
                        newNodes.Add()
                    }
                }

            }
        }

        public override object Answer1()
        {
            List<List<int>>? grid = InputData
                .Select(x => x.ToCharArray().Select(c => c.ToString()).Select(int.Parse).ToList())
                .ToList();

            //var numCols = grid.First().Count();
            //var numRows = grid.Count();

            var nodes = GetNodes();
            var startLoc = new Location(0, 0);
            nodes[startLoc].LowestRiskPath = 0;

            var maxCol = nodes.Keys.Select(x => x.Col).Max();
            var maxRows = nodes.Keys.Select(x => x.Row).Max();
            var finish = nodes[new Location(maxRows, maxCol)];
            var max = Math.Max(maxCol, maxRows);

            for (int i = 0; i <= max; i++)
            {
                foreach (var node in nodes.Values)
                {
                    if (node.Location == startLoc)
                        continue;

                    Location location = node.Location;
                    List<Node> neighbours = GetNeighbours(location, nodes);
                    var riskValues = neighbours.Select(x => x.LowestRiskPath).ToList();
                    var lowest = riskValues.Min() + node.Risk;
                    if (lowest < node.LowestRiskPath)
                        node.LowestRiskPath = lowest;

                }
            }

            return finish.LowestRiskPath;
        }

        public override object Answer2()
        {
            return -1;
        }
    }

    public class Node
    {
        public Location Location { get; set; }
        public int Risk { get; set; }
        public int LowestRiskPath { get; set; }
        public override string ToString()
        {
            return $"({Location}), {LowestRiskPath}";
        }
    }

    public struct Location
    {
        public int Row { get; }
        public int Col { get; }

        public Location(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override string ToString()
        {
            return $"{Row},{Col}";
        }

        public static bool operator ==(Location a, Location b) => a.Row == b.Row && a.Col == b.Col;
        public static bool operator !=(Location a, Location b) => a.Row != b.Row || a.Col != b.Col;
    }
}
