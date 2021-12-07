using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day07 : DayBase
    {
        public override string Name => "Day 7";

        public Day07(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {
            var positions = GetPositions();
            int min = positions.Min();
            int max = positions.Max();
            long minUsed = long.MaxValue;
            var distinctPos = positions.Distinct();
            for (int i = min; i < max+1; i++)
            {
                long used = positions.Select(x => Math.Abs(x - i)).Sum();
                if (used < minUsed)
                {
                    minUsed = used;
                }
            }
            return minUsed;
        }

        public override object Answer2()
        {
            var positions = GetPositions();
            var crabs = positions.Select(x => new Crab() { Position = x});

            int min = positions.Min();
            int max = positions.Max();
            long minUsed = long.MaxValue;
            for (int i = min; i < max + 1; i++)
            {
                var fuelUsed = crabs.Select(x => x.Move(i)).Sum();
                if (fuelUsed < minUsed)
                {
                    minUsed = fuelUsed;
                }
            }
            return minUsed;
        }

        private List<int> GetPositions() =>
            InputData.First().Split(",").Select(x => int.Parse(x)).ToList();
    }

    public class Crab
    {
        public int Position { get; set; }

        public long Move(int newPos)
        {
            var stepsNeeded = Math.Abs(Position - newPos);
            var fuelUsed = (stepsNeeded * (stepsNeeded + 1)) / 2;
            return fuelUsed;
        }
    }
}
