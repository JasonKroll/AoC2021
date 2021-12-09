using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day08 : DayBase
    {
        public override string Name => "Day 8";


        public Day08(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {
            var data = InputData.Select(x => new Data(x)).ToList();
            var outputs = data.SelectMany(x => x.Output).ToList();
            Dictionary<int, long> outputMembers = new Dictionary<int, long>();
            for (int i = 0; i < 8; i++)
            {
                outputMembers[i] = 0;
            }
            var grouped = outputs.GroupBy(x => x.Length);
            var sum = grouped.Where(x => x.Key == 2).Sum(x => x.Count());
            sum += grouped.Where(x => x.Key == 3).Sum(x => x.Count());
            sum += grouped.Where(x => x.Key == 4).Sum(x => x.Count());
            sum += grouped.Where(x => x.Key == 7).Sum(x => x.Count());

            return sum;
        }

        public override object Answer2()
        {
            var data = InputData.Select(x => new Data(x)).ToList();
             
            return data.Sum(x => x.OutputValue);
        }
    }

    public class Data
    {
        public List<string> Input { get; } = new List<string>();
        public List<string> Output { get; } = new List<string>();
        public List<int> OutputValues { get; } = new List<int>();
        public int OutputValue { get; }
        public Data(string input)
        {
            List<string> data = input.Split("|").Select(x => x.Trim()).ToList();
            Input.AddRange(data.First()?.Split(" ")?.ToList());
            Output.AddRange(data?.Last()?.Split(" ")?.ToList());
            foreach (var item in Output)
            {
                OutputValues.Add(Decode(item));
            }
            OutputValue = int.Parse(string.Join("", OutputValues.Select(x => x.ToString())));
         }

        public int Decode(string input)
        {
            Dictionary<int, string>? mappings = new();

            for (int i = 0; i < 10; i++)
            {
                mappings[i] = "";
            }
            var grouped = Input.GroupBy(x => x.Length).Select(x => x);
            var one = grouped.Where(x => x.Key == 2).Select(y => y);
            var four = grouped.Where(x => x.Key == 4).Select(y => y);
            var seven = grouped.Where(x => x.Key == 3).Select(y => y);
            var eight = grouped.Where(x => x.Key == 7).Select(y => y);

            mappings[1] = one.First().First();
            mappings[4] = four.First().First();
            mappings[7] = seven.First().First();
            mappings[8] = eight.First().First();

            var a = Remove(mappings[7], mappings[1]);
            var bd = Remove(mappings[4], mappings[1]);

            var sixes = grouped.Where(x => x.Key == 6).FirstOrDefault();
            var fives = grouped.Where(x => x.Key == 5).FirstOrDefault();

            foreach (var item in sixes)
            {
                if (!IncludesAll(item, mappings[1]))
                {
                    mappings[6] = item;
                }
                else if(IncludesAll(item, mappings[1]) && IncludesAll(item, bd))
                {
                    mappings[9] = item;
                }
                else
                {
                    mappings[0] = item;
                }
            }

            foreach (var item in fives)
            {
                if (IncludesAll(item, mappings[1]) && IncludesAll(item, a))
                {
                    mappings[3] = item;
                }
                else if (IncludesAll(item, bd))
                {
                    mappings[5] = item;
                }
                else
                {
                    mappings[2] = item;
                }
            }
            return mappings.Where(x => Matches(x.Value, input)).Select(x => x.Key).First();
        }

        private bool IncludesAll(string string1, string string2)
        {
            string1 = String.Concat(string1.OrderBy(c => c));
            string2 = String.Concat(string2.OrderBy(c => c));
            var chars1 = string1.OrderBy(c => c);
            var chars2 = string2.OrderBy(c => c);
            var all = chars2.All(x => chars1.Contains(x));
            return all;
        }

        private bool Matches(string string1, string string2)
        {
            string1 = String.Concat(string1.OrderBy(c => c));
            string2 = String.Concat(string2.OrderBy(c => c));
            return string1.Equals(string2, StringComparison.OrdinalIgnoreCase);
        }

        private string Remove(string string1, string string2)
        {
            string1 = String.Concat(string1.OrderBy(c => c));
            var chars = string2.OrderBy(c => c);
            foreach (var c in chars)
            {
                string1 = string1.Remove(string1.IndexOf(c), 1);
            }
           return string1;
        }
    }
}
