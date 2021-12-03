using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day03 : DayBase
    {
        public override string Name => "Day 3";

        public Day03(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {
            var bitCount = InputData.First().Length;
            var sbGamma = new StringBuilder();
            var sbEpsilon = new StringBuilder();

            for (int i = 0; i < bitCount; i++)
            {
                List<string> col = InputData.Select(x => x[i].ToString()).ToList();
                var numOnes = col.Where(x => x == "1").Count();
                var numZeros = col.Where(x => x == "0").Count();
                var most = numOnes > numZeros ? "1" : "0";
                var least = numOnes > numZeros ? "0" : "1";

                sbGamma.Append(most);
                sbEpsilon.Append(least);
            }
            int gammaRate = Convert.ToInt32(sbGamma.ToString(), 2);
            int epsilonRate = Convert.ToInt32(sbEpsilon.ToString(), 2);

            return gammaRate * epsilonRate;
        }

        public override object Answer2()
        {
            var bitCount = InputData.First().Length;
            string oxygenBin = Filter(InputData, bitCount, 0, "1", true);
            string c02Bin = Filter(InputData, bitCount, 0, "0", false);
            int oxygen = Convert.ToInt32(oxygenBin.ToString(), 2);
            int c02 = Convert.ToInt32(c02Bin.ToString(), 2);

            return oxygen * c02;
        }

        private string Filter(List<string> data, int bitCount, int bitPos, string defaultValue, bool mostOccurrences = true)
        {
            if (bitPos > bitCount)
                return data.FirstOrDefault() ?? "";

            List<string> col = data.Select(x => x[bitPos].ToString()).ToList();
            var numOnes = col.Where(x => x == "1").Count();
            var numZeros = col.Where(x => x == "0").Count();
            var checkVal = "0";
            if (numZeros == numOnes)
            {
                checkVal = defaultValue;
            }
            else
            {
                var most = numOnes > numZeros ? "1" : "0";
                var least = numOnes > numZeros ? "0" : "1";
                checkVal = mostOccurrences ? most : least;
            }

            var matches = data.Where(x => x[bitPos].ToString() == checkVal).ToList();
            if (matches.Count() == 1)
                return matches[0];

            return Filter(matches, bitCount, bitPos + 1, defaultValue, mostOccurrences);
        }
    }
}
