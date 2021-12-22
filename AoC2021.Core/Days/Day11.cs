using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day11 : DayBase
    {
        public override string Name => "Day 11";

        public List<int> Inputs { get; } = new List<int>();

        public Day11(List<string> inputs) : base(inputs)
        {
        }

        public override object Answer1()
        {
            var octos = string.Join("", InputData).Select(x => int.Parse(x.ToString())).ToList();
            int flashes = 0;
            for (int i = 0; i < 100; i++)
            {
                octos = octos.Select(x => x + 1).ToList();
                flashes += Flashes(octos, 0);
            }
            return flashes;
        }

        public override object Answer2()
        {
            var octos = string.Join("", InputData).Select(x => int.Parse(x.ToString())).ToList();
            int flashes = 0;
            int step = 0;
            while (flashes < 100 || flashes == 10000)
            {
                octos = octos.Select(x => x + 1).ToList();
                flashes = Flashes(octos, 0);
                step++;
            }
            return step;
        }

        private int Flashes(List<int> octos, int flashCount)
        {
            int f = flashCount;
            
            var nines = octos.Select((value, index) => new { value, index })
                .Where(pair => pair.value > 9)
                .Select(pair => pair.index)
                .ToList();

            f += nines.Count;
            foreach (var item in nines)
            {
                octos[item] = 0;
            }

            foreach (var item in nines)
            {
                var row = Math.DivRem(item, 10, out int col);

                if (col > 0)
                    octos[item - 1] = IncrementPower(octos[item - 1]);

                if (col < 9)
                    octos[item + 1] = IncrementPower(octos[item + 1]);

                if (row > 0)
                {
                    int above = int.Parse((row - 1).ToString() + col.ToString());
                    octos[above] = IncrementPower(octos[above]);

                    if (col > 0)
                    {
                        octos[above - 1] = IncrementPower(octos[above - 1]);
                    }
                    if (col < 9)
                    {
                        octos[above + 1] = IncrementPower(octos[above + 1]);
                    }

                }
                if (row < 9)
                {
                    int below = int.Parse((row + 1).ToString() + col.ToString());
                    octos[below] = IncrementPower(octos[below]);
                    if (col > 0)
                    {
                        octos[below - 1] = IncrementPower(octos[below - 1]);
                    }
                    if (col < 9)
                    {
                        octos[below + 1] = IncrementPower(octos[below + 1]);
                    }
                }
            }

            if (nines.Any())
            {
                f += Flashes(octos, 0);
            }
           
            return f;
        }

        private int IncrementPower(int value)
        {
            if (value == 0)
                return 0;

            return value + 1;
        }
    }
}
