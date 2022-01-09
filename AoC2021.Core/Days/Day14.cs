using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day14 : DayBase
    {
        public override string Name => "Day 14";

        public List<int> Inputs { get; } = new List<int>();

        public Day14(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {
            var template = InputData.First();
            var pairs = GetPairs(template);
            Dictionary<string, string> rules =
                InputData
                .Where(x => x.Contains("->"))
                .Select(item => item.Split("->"))
                .ToDictionary(s => s[0].Trim(), s => s[1].Trim());

            string polymer = GetPolymer(template, 10, rules);
            var l = polymer.Length;
            var elements = polymer.GroupBy(x => x).OrderBy(x => x.Count());
            
            return elements.Last().Count() - elements.First().Count();
        }

        public override object Answer2()
        {
            var template = InputData.First();
            var pairs = GetPairs(template);
            Dictionary<string, string> rules =
                InputData
                .Where(x => x.Contains("->"))
                .Select(item => item.Split("->"))
                .ToDictionary(s => s[0].Trim(), s => s[1].Trim());


            return -1;
            // Maybe some sort of parallel processing????

            //string polymer = GetPolymer(template, 40, rules);
            //var l = polymer.Length;
            //var elements = polymer.GroupBy(x => x).OrderBy(x => x.Count());

            //return elements.Last().Count() - elements.First().Count();
        }

        private string GetPolymer(string template, int noSteps, Dictionary<string, string> rules)
        {
            for (int i = 0; i < noSteps; i++)
            {
                int templateLength = template.Length;
                var sb = new StringBuilder();
                var elements = template.ToList();
                List<char[]>? pairs =
                    elements
                    .Skip(1)
                    .Zip(elements, (second, first) => new[] { first, second })
                    .ToList();
                foreach (var pairSet in pairs)
                {
                    var pair = $"{pairSet[0]}{pairSet[1]}";
                    string element = rules[pair];
                    sb.Append(pairSet[0]);
                    sb.Append(element);
                }
                sb.Append(elements.Last().ToString());
                template = sb.ToString();
            }
            return template;
        }

        private static IList<string> GetPairsParallel(IList<char[]> template, Dictionary<string, string> rules)
        {
            var pairs = new ConcurrentBag<string>();
            var j = 0;
            Parallel.ForEach(template, p =>
            {
                var pair = $"{template[j]}{template[j + 1]}";
                string element = rules[pair];
                pairs.Add($"{template[j]}{element}");
                j++;
            });

            return pairs.ToList();
        }

        private IEnumerable<IGrouping<int, char>>  GetPairs(string template)
        {
            var chars = template.Select((value, index) => new { value, index }).ToList();
            var pairs = template.Select((value, index) => new { value, index })
                    .GroupBy(x => x.index, x => x.value);

            
            for (int i = 0; i < chars.Count; i++)
            {

            }

            return pairs;
        }
    }
}
