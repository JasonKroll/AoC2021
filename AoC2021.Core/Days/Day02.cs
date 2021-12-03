// https://adventofcode.com/2021/day/1
namespace AoC2021.Core.Days
{
    public class Day02 : DayBase
    {
        public override string Name => "Day 2";

        public List<KeyValuePair<string, int>> KVPInputs { get; } = new List<KeyValuePair<string, int>>();

        public Day02(List<string> inputs) : base(inputs)
        {
            foreach (var item in inputs)
            {
                var split = item.Split(' ');
                KVPInputs.Add(new KeyValuePair<string, int>(split[0], int.Parse(split[1])));
            }
        }

        public override object Answer1()
        {
            int depth = 0;
            int horiz = 0;

            foreach (var item in KVPInputs)
            {
                var direction = item.Key;
                var value = item.Value;
                switch (direction)
                {
                    case "down":
                        depth += value;
                        break;
                    case "up":
                        depth -= value;
                        break;
                    case "forward":
                        horiz += value;
                        break;
                    default:
                        break;
                }
            }
            return depth * horiz;
        }

        public override object Answer2()
        {
            int depth = 0;
            int horiz = 0;
            int aim = 0;

            foreach (var item in KVPInputs)
            {
                var direction = item.Key;
                var value = item.Value;
                switch (direction)
                {
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "forward":
                        horiz += value;
                        depth += aim * value;
                        break;
                    default:
                        break;
                }
            }
            return depth * horiz;
        }
    }
}
