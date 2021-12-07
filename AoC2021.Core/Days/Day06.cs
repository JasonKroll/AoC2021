using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core.Days
{
    public class Day06 : DayBase
    {
        public override string Name => "Day 6";

        public Day06(List<string> inputs) : base(inputs)
        {
        }

        private List<int> GetFish()
        {
            return InputData.First().Split(",").Select(x => int.Parse(x)).ToList();
        }

        public override object Answer1()
        {
            List<int>? fish = GetFish();
            var initNumber = fish.Count;
            var fishCount = fish.Count();
            foreach (var item in fish)
            {
                var currentFish = new List<int>(){ item };
                currentFish = IncrementDays(currentFish);
                for (int d = 1; d < 80; d++)
                {
                    var numberZeros = currentFish.Where(x => x == 0).Count();
                    currentFish = IncrementDays(currentFish);
                    for (int i = 0; i < numberZeros; i++)
                    {
                        currentFish.Add(8);
                    }
                }
                fishCount += currentFish.Count() - 1;
            }
            return fishCount;
        }

        public override object Answer2()
        {
            var fish = GetFish();
            FishPopulation population = new FishPopulation(fish);
            for (int d = 0; d < 256; d++)
            {
                population.NewDay();
            }
            return population.TotalPopulation;
        }

        private List<int> IncrementDays(List<int> fish)
        {
            for (int i = 0; i < fish.Count; i++)
            {
                if (fish[i] == 0)
                {
                    fish[i] = 6;
                }
                else
                {
                    fish[i]--;
                }
            }
            return fish;
        }
    }

    public class FishPopulation
    {
        private Dictionary<int, long> birthCycle = new Dictionary<int, long>();
        public long TotalPopulation { get; set; }

        public FishPopulation(List<int> population)
        {
            for (int i = 0; i < 8; i++)
            {
                birthCycle[i] = 0;
            }

            var groupByDays = population.GroupBy(x => x);

            foreach (var group in groupByDays)
            {
                birthCycle[group.Key] = group.Count();
            }
            TotalPopulation = birthCycle.Sum(x => x.Value);
        }

        public void NewDay()
        {
            var newFish = birthCycle[0];
            for (int i = 1; i < birthCycle.Count; i++)
            {
                birthCycle[i - 1] = birthCycle[i];
            }
            birthCycle[6] += newFish;
            birthCycle[8] = newFish;

            TotalPopulation = birthCycle.Sum(x => x.Value);
        }
    }


}
