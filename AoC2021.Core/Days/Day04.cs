namespace AoC2021.Core.Days
{
  public class Day04 : DayBase
    {
        public override string Name => "Day 4";

        public List<List<string>> Boards { get; set; } = new List<List<string>>();
        public List<string> Numbers { get; set; } = new List<string>();

        public Day04(List<string> inputs) : base(inputs)
        {
            ParseInputs();
        }

        public override object Answer1()
        {
            var nums = Numbers.Take(5).ToList();
            for (int i = 5; i < Numbers.Count; i++)
            {
                var number = Numbers[i];
                nums.Add(number);
                foreach (var board in Boards)
                {
                    var mr = FullRow(board, nums, 5, out List<string>? row);
                    if (mr)
                    {
                        return CalcScore(board, nums, int.Parse(number));
                    }
                    var mc = FullColumn(board, nums, 5, out List<string>? col);
                    if (mc)
                    {
                        return CalcScore(board, nums, int.Parse(number));
                    }
                }
            }
            return -1;
        }

        public override object Answer2()
        {
            var nums = Numbers.Take(5).ToList();
            List<int> wins = new();
            List<int> winIndex = new();

            for (int i = 5; i < Numbers.Count; i++)
            {
                var number = Numbers[i];
                nums.Add(number);
                for (int j = 0; j < Boards.Count; j++)
                {
                    if (winIndex.Contains(j))
                        continue;

                    var board = Boards[j];
                    var mr = FullRow(board, nums, 5, out List<string>? row);
                    if (mr)
                    {
                        wins.Add(CalcScore(board, nums, int.Parse(number)));
                        winIndex.Add(j);
                    }
                    else
                    {
                        var mc = FullColumn(board, nums, 5, out List<string>? col);
                        if (mc)
                        {
                            wins.Add(CalcScore(board, nums, int.Parse(number)));
                            winIndex.Add(j);
                        }
                    }
                }
            }
            if (wins.Any())
                return wins.Where(x => x != 0).Last();

            return -1;
        }
        private void ParseInputs()
        {
            var stripped = InputData.Where(x => !string.IsNullOrEmpty(x)).ToList();

            Numbers = stripped.First().Split(',').ToList();
            for (int i = 5; i < stripped.Count; i+=5)
            {
                var xx = stripped[i-2].Split(' ').Where(x => !string.IsNullOrEmpty(x));
                var myStrings = stripped[i-2].Split().Where(x => x.All(char.IsDigit)).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var newBoard = new List<string>();
                newBoard.AddRange(stripped[i-4].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList());
                newBoard.AddRange(stripped[i-3].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList());
                newBoard.AddRange(stripped[i-2].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList());
                newBoard.AddRange(stripped[i-1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList());
                newBoard.AddRange(stripped[i].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList());
                Boards.Add(newBoard);
            }
        }

        private bool FullRow(List<string> board, List<string> numbers, int dimension, out List<string>? row)
        {
            var rows = board.Chunk(dimension);
            row = rows.FirstOrDefault(x => x.All(y => numbers.Contains(y)))?.ToList();
            return row != null;
        }

        private bool FullColumn(List<string> board, List<string> numbers, int dimension, out List<string>? column)
        {
            var rows = board.Chunk(5).ToList();
            var columns = new List<List<string>>();
            for (int i = 0; i < dimension; i++)
            {
                int index = i;
                var newCol = new List<string>();
                for (int j = 0; j < dimension; j++)
                {
                    newCol.Add(board[index]);
                    index += dimension;
                }
                columns.Add(newCol);
            }
            column = columns.FirstOrDefault(x => x.All(y => numbers.Contains(y)))?.ToList();
            return column != null;
        }

        private int CalcScore(List<string> board, List<string> matchingNumbers, int lastNum)
        {
            var unmatched = board.Where(x => !matchingNumbers.Contains(x)).Select(x => int.Parse(x)).ToList();
            var sum = unmatched.Sum();
            return unmatched.Sum() * lastNum;
        }
    }
}
