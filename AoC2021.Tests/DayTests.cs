using AoC2021.Core;
using AoC2021.Core.Days;
using NUnit.Framework;

namespace AoC2021.Tests
{
    public class Tests
    {
        private Runner _Runner = new(true);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day01a()
        {
            var res = _Runner.Answer1(typeof(Day01));
            Assert.That(res, Is.EqualTo(7));
        }

        [Test]
        public void Day01b()
        {
            var res = _Runner.Answer2(typeof(Day01));
            Assert.That(res, Is.EqualTo(5));
        }

        [Test]
        public void Day02a()
        {
            var res = _Runner.Answer1(typeof(Day02));
            Assert.That(res, Is.EqualTo(150));
        }

        [Test]
        public void Day02b()
        {
            var res = _Runner.Answer2(typeof(Day02));
            Assert.That(res, Is.EqualTo(900));
        }

        [Test]
        public void Day03a()
        {
            var res = _Runner.Answer1(typeof(Day03));
            Assert.That(res, Is.EqualTo(198));
        }

        [Test]
        public void Day03b()
        {
            var res = _Runner.Answer2(typeof(Day03));
            Assert.That(res, Is.EqualTo(230));
        }

        [Test]
        public void Day04a()
        {
            var res = _Runner.Answer1(typeof(Day04));
            Assert.That(res, Is.EqualTo(4512));
        }

        [Test]
        public void Day04b()
        {
            var res = _Runner.Answer2(typeof(Day04));
            Assert.That(res, Is.EqualTo(1924));
        }

        [Test]
        public void Day05a()
        {
            var res = _Runner.Answer1(typeof(Day05));
            Assert.That(res, Is.EqualTo(5));
        }

        [Test]
        public void Day05b()
        {
            var res = _Runner.Answer2(typeof(Day05));
            Assert.That(res, Is.EqualTo(12));
        }

        [Test]
        public void Day06a()
        {
            var res = _Runner.Answer1(typeof(Day06));
            Assert.That(res, Is.EqualTo(5934));
        }

        [Test]
        public void Day06b()
        {
            var res = _Runner.Answer2(typeof(Day06));
            Assert.That(res, Is.EqualTo(26984457539));
        }


        [Test]
        public void Day07a()
        {
            var res = _Runner.Answer1(typeof(Day07));
            Assert.That(res, Is.EqualTo(37));
        }

        [Test]
        public void Day07b()
        {
            var res = _Runner.Answer2(typeof(Day07));
            Assert.That(res, Is.EqualTo(168));
        }


        [Test]
        public void Day08a()
        {
            var res = _Runner.Answer1(typeof(Day08));
            Assert.That(res, Is.EqualTo(26));
        }

        [Test]
        public void Day08b()
        {
            var res = _Runner.Answer1(typeof(Day08));
            Assert.That(res, Is.EqualTo(26));
        }

        [Test]
        public void Day09a()
        {
            var res = _Runner.Answer1(typeof(Day09));
            Assert.That(res, Is.EqualTo(15));
        }

        [Test]
        public void Day09b()
        {
            var res = _Runner.Answer2(typeof(Day09));
            Assert.That(res, Is.EqualTo(1134));
        }

        [Test]
        public void Day10a()
        {
            var res = _Runner.Answer1(typeof(Day10));
            Assert.That(res, Is.EqualTo(26397));
        }

        [Test]
        public void Day10b()
        {
            var res = _Runner.Answer2(typeof(Day10));
            Assert.That(res, Is.EqualTo(288957)); 
        }

        [Test]
        public void Day11a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day11b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day12a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day12b()
        {
            Assert.Fail();
        }


        [Test]
        public void Day13a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day13b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day14a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day14b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day15a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day15b()
        {
            Assert.Fail();
        }


        [Test]
        public void Day16a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day16b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day17a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day17b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day18a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day18b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day19a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day19b()
        {
            Assert.Fail();
        }


        [Test]
        public void Day20a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day20b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day21a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day21b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day22a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day22b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day23a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day23b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day24a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day24b()
        {
            Assert.Fail();
        }

        [Test]
        public void Day25a()
        {
            Assert.Fail();
        }

        [Test]
        public void Day25b()
        {
            Assert.Fail();
        }
    }
}