using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace AdventOfCode2018
{
    public class TestDay4
    {
        [Fact]
        public void TestDay4A()
        {
            //Arrange
            string[] exampleInputs = new string[] { "[1518-11-01 00:00] Guard #10 begins shift", "[1518-11-01 00:05] falls asleep", "[1518-11-01 00:25] wakes up", "[1518-11-01 00:30] falls asleep", "[1518-11-01 00:55] wakes up", "[1518-11-01 23:58] Guard #99 begins shift", "[1518-11-02 00:40] falls asleep", "[1518-11-02 00:50] wakes up", "[1518-11-03 00:05] Guard #10 begins shift", "[1518-11-03 00:24] falls asleep", "[1518-11-03 00:29] wakes up", "[1518-11-04 00:02] Guard #99 begins shift", "[1518-11-04 00:36] falls asleep", "[1518-11-04 00:46] wakes up", "[1518-11-05 00:03] Guard #99 begins shift", "[1518-11-05 00:45] falls asleep", "[1518-11-05 00:55] wakes up"};
          //  IEnumerable<string> ActualInput = File.ReadLines("C:/Users/Svejk/Documents/AdventOfCode2018/AdventOfCode2018/day4Input.txt");
            IEnumerable<string> fakeInputs = exampleInputs;

            var expectedResult = 10;
            var sut = new Day4();
            //Act
            var result = sut.Day4A(fakeInputs);
            //Assert
            Assert.Equal(expectedResult, result);
        }
    }

    public class Day4
    {
        private Regex _regex = new Regex(@"\[(\d{4}[-]\d{2}[-]\d{2}\s\d{2}[:]\d{2})\] (Guard #(\d*) begins shift)?(falls asleep)?(wakes up)?");

        
        public int Day4A(IEnumerable<string> input) {
            int res = 0;
            Dictionary<DateTime, int> dateTimeAndOwner = new Dictionary<DateTime, int>();

            foreach(string s in input.ToList())
            {
                Match match = _regex.Match(s);

                var dateAndTime = Convert.ToDateTime(match.Groups[1]);
                bool wakeUp = match.Groups[5].ToString() == "wakes up" ? true : false;
                bool fallAsleep = match.Groups[4].ToString() == "falls asleep" ? true : false;
                string beginShift = match.Groups[2].Value;
                var guardId = int.Parse(match.Groups[3].ToString());

                if(string.IsNullOrWhiteSpace(beginShift))
                {

                }
            }


            return res;
        }
    }
}
