using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core
{
    public abstract class DayBase
    {
        public virtual string Name { get; } = "Day01";
        
        public Type CallingType => this.GetType();

        public List<string> InputData { get; set; } = new List<string>();

        public DayBase(List<string> inputs)
        {
            InputData = inputs;
        }

        public abstract object Answer1();
        public abstract object Answer2();

        public override string ToString()
        {
            return $"{Name}-1: {Answer1()}   --   {Name}-2: {Answer2()}";
        }
    }
}
