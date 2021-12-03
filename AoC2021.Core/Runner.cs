using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core
{
    public class Runner
    {
        public List<DayBase> Days { get; } = new List<DayBase>();

        public Runner(bool isTest = false)
        {
            GetDays(isTest);
        }

        public object? Answer1(Type type)
        {
            var day = Days.FirstOrDefault(x => x.GetType() == type);
            return day?.Answer1();
        }
        
        public object? Answer2(Type type)
        {
            var day = Days.FirstOrDefault(x => x.GetType() == type);
            return day?.Answer2();
        }

        private void GetDays(bool isTest = false)
        {
            var dayTypes = 
                Assembly.GetAssembly(typeof(DayBase))?
                .GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(DayBase)));
            if (dayTypes != null)
            {
                foreach (Type type in dayTypes)
                {
                    var inputs = isTest ? Loader.LoadTestData(type) : Loader.LoadData(type);
                    var day = Activator.CreateInstance(type, inputs) as DayBase;
                    if (day != null)
                        Days.Add(day);
                }
            }
        }
    }
}
