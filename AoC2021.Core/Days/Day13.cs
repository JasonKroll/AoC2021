using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day13 : DayBase
    {
        public override string Name => "Day 13";

        public List<int> Inputs { get; } = new List<int>();

        public Day13(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {
            IEnumerable<KeyValuePair<string, int>>? folds = GetFolds();
            IEnumerable<List<int>>? coords = GetCoords();
            List<List<bool>>? grid = GetGrid(coords);
            var folded = FoldGrid(folds.First(), grid);
            return folded.SelectMany(x => x).Where(x => x).Count();
        }

        public override object Answer2()
        {
            IEnumerable<KeyValuePair<string, int>>? folds = GetFolds();
            IEnumerable<List<int>>? coords = GetCoords();
            List<List<bool>>? grid = GetGrid(coords);
            foreach (var fold in folds)
            {
                grid = FoldGrid(fold, grid);
            }
            for (int r = 0; r < grid.Count; r++)
            {
                for (int c = 0; c < grid.First().Count; c++)
                {
                    if (grid[r][c] == true)
                        Console.Write("#");
                    else Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int c = 0; c < grid.First().Count; c++)
            {
                for (int r = 0; r < grid.Count; r++)
                {
                    if (grid[r][c] == true)
                        Console.Write("#");
                    else Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            return -1;
        }

        private List<List<bool>> FoldGrid(KeyValuePair<string, int> fold, List<List<bool>> grid)
        {
            if (fold.Key == "y")
            {
                var length = grid.Count - fold.Value - 1;
                var xx = grid.GetRange(fold.Value + 1, length);
                xx.Reverse();
                for (int r = 0; r < xx.Count; r++)
                {
                    var row = xx[r];
                    for (int c = 0; c < row.Count; c++)
                    {
                        var col = row[c];
                        if (col)
                            grid[r][c] = true;
                    }
                }
                grid = grid.GetRange(0, fold.Value);
            }
            else
            {
                var folded = grid
                    .Select(x => x.GetRange(fold.Value + 1, x.Count - fold.Value - 1))
                    .ToList();

                for (int r = 0; r < grid.Count; r++)
                {
                    var row = folded[r];
                    row.Reverse();
                    for (int c = 0; c < row.Count; c++)
                    {
                        var col = row[c];
                        if (col)
                            grid[r][c] = true;
                    }
                }
                grid = grid
                    .Select(x => x.GetRange(0, fold.Value))
                    .ToList();
            }

            return grid;
        }

        private List<List<bool>> GetGrid(IEnumerable<List<int>> coords)
        {
            var maxX = coords.Select(x => x[0]).Max();
            var maxY = coords.Select(x => x[1]).Max();
            var grid = new List<List<bool>>();
            for (int r = 0; r < maxY + 1; r++)
            {
                var row = new List<bool>();
                for (int c = 0; c < maxX + 1; c++)
                {
                    row.Add(false);
                }
                grid.Add(row);
            }
            foreach (var coord in coords)
            {
                grid[coord[1]][coord[0]] = true;
            }
            return grid;
        }

        private IEnumerable<List<int>> GetCoords()
        {
            return InputData
                .Where(x => !x.StartsWith("fold along"))
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Split(','))
                .Select(x => new List<int> { Convert.ToInt32(x[0]), Convert.ToInt32(x[1]) });
        }

        private IEnumerable<KeyValuePair<string,int>> GetFolds()
        {
            return InputData
                .Where(x => x.StartsWith("fold along"))
                .Select(x => x.Substring(11).Split('='))
                .Select(x => new KeyValuePair<string, int>(x[0], Convert.ToInt32(x[1])));
        }
    }
}
