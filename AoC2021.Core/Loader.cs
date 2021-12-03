using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Core
{
    /// <summary>
    /// Load test data
    /// </summary>
    /// <remarks>
    /// Expects test data to be in the format {typename}Test.txt e.g. Day01Test.txt
    /// Expects real data to be in the format {typename}.txt e.g. Day01Test.txt
    /// </remarks>
    public static class Loader
    {
        public static List<string> LoadTestData(Type type)
        {
            try
            {
                var path = @"./Inputs";
                var file = Path.Combine(path, $"{type.Name}Test.txt");
                return System.IO.File.ReadLines(@file).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public static List<string> LoadData(Type type)
        {
            try
            {
                var path = @"./Inputs";
                var file = Path.Combine(path, $"{type.Name}.txt");
                return System.IO.File.ReadAllLines(file).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

    }
}
