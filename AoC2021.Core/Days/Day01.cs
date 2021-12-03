// https://adventofcode.com/2021/day/1
namespace AoC2021.Core.Days
{
    public class Day01 : DayBase
    {
        public Day01(List<string> inputs) : base(inputs)
        {
        }

        public override string Name => "Day 1";

        public List<int> Measurements { get; } = new List<int>();

        //public Day01(List<int> measurements)
        //{
        //    Measurements = measurements;
        //}

        public override object Answer1()
        {
            List<int> inputs = InputData.Select(x => int.Parse(x)).ToList();
            return CheckLarger(inputs);
        }

        public override object Answer2()
        {
            List<int> values = new List<int>();
            for (int i = 2; i < InputData.Count; i++)
            {
                var a = int.Parse(InputData[i - 2]);
                var b = int.Parse(InputData[i - 1]);
                var c = int.Parse(InputData[i - 0]);
                var sum = a + b + c;
                values.Add(sum);
            }
            return CheckLarger(values);
        }

        private int CheckLarger(List<int> values)
        {
            int count = 0;
            for (int i = 1; i < values.Count; i++)
            {
                int prevMeasurement = values[i - 1];
                int currentMeasurement = values[i];
                if (currentMeasurement > prevMeasurement)
                    count++;
            }
            return count;
        }
    }
}
