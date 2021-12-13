namespace AoC2021.Core.Days
{
  public class Day10 : DayBase
    {
        public override string Name => "Day 10";

        public List<int> Inputs { get; } = new List<int>();

        public Day10(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {

            Dictionary<string, long> scores = new(){
                { ")", 3 },
                { "]", 57 },
                { "}", 1197 },
                { ">", 25137 }
            };
            long total = 0;
            Dictionary<string, long> illegals = new()
            {
                { ")", 0 },
                { "]", 0 },
                { "}", 0 },
                { ">", 0 }
            };
            int r = 0;
            foreach (var line in InputData)
            {
                string str = line;
                while (str.Contains("()") || str.Contains("[]") || str.Contains("{}") || str.Contains("<>")) {
                    str = str.Replace("()", "");
                    str = str.Replace("[]", "");
                    str = str.Replace("{}", "");
                    str = str.Replace("<>", "");
                }

                while (str.EndsWith("[") || str.EndsWith("(") || str.EndsWith("{") || str.EndsWith("<")){
                    str = str.Substring(0, str.Length - 1);
                }
                
                var strList = str.ToCharArray().Select(x => x.ToString()).ToList();
                for (int i = 0; i < strList.Count - 1; i++)
                {
                    string c1 = strList[i];
                    string c2 = strList[i + 1];
                    var isClosed = IsOpenClose(c1, c2, out bool matches, str, r);
                    if (isClosed && !matches)
                    {
                        if (illegals.ContainsKey(c2))
                        {
                            illegals[c2] = illegals[c2] += scores[c2];
                        }
                        else
                        {
                            illegals.Add(c2, scores[c2]);
                        }
                    }
                }

               r++;
            }
            total = illegals.Sum(x => x.Value);
            return total;
        }

        private bool IsOpenClose(string s1, string s2, out bool matches, string test, int row)
        {
            matches = false;

            var map = new Dictionary<string, string>(){
                { "(", ")" },
                { "[", "]" },
                { "{", "}" },
                { "<", ">" }
            };
            var opens = map.Keys;
            var closes = map.Values;
            if (!opens.Contains(s1) || !closes.Contains(s2))
            {
                return false;
            }
            if (s2 == map[s1])
            {
                matches = true;
            }
            return true;
        }
        public override object Answer2()
        {
            Dictionary<string, long> scores = new(){
                { "(", 1 },
                { "[", 2 },
                { "{", 3 },
                { "<", 4 }
            };
            int r = 0;
            List<string> incompletes = new();
            List<long> incompletScores = new();
            foreach (var line in InputData)
            {
                string str = line;
                while (str.Contains("()") || str.Contains("[]") || str.Contains("{}") || str.Contains("<>")) {
                    str = str.Replace("()", "");
                    str = str.Replace("[]", "");
                    str = str.Replace("{}", "");
                    str = str.Replace("<>", "");
                }
                var strList = str.ToCharArray().Select(x => x.ToString()).ToList();
                bool isIncomplete = true;
                for (int i = 0; i < strList.Count - 1; i++)
                {
                    string c1 = strList[i];
                    string c2 = strList[i + 1];
                    var isClosed = IsOpenClose(c1, c2, out bool matches, str, r);
                    if (isClosed && !matches)
                    {
                        isIncomplete = false;
                        break;
                    }
                }
                if (isIncomplete)
                    incompletes.Add(str);
               r++;
            }

            foreach (var item in incompletes)
            {
                long incTotal = 0;
                var chrs = item.ToCharArray().Select(x => x.ToString()).Reverse().ToList();
                foreach (var c in chrs)
                {
                    incTotal = incTotal * 5;
                    incTotal += scores[c];
                }
                incompletScores.Add(incTotal);
            }
            incompletScores.OrderBy(x => x).ToList();
            var middle = GetMiddleNumber(incompletScores.OrderBy(x => x).ToList());
            return middle;
        }
        private static long GetMiddleNumber(List<long> nums)
        {
            // if length is odd, return middle numer
            if (nums.Count % 2 == 1) return nums[nums.Count / 2];

            // if length is even return the first of the two middle numbers
            return nums[nums.Count / 2  - 1];
        }
    }
}
