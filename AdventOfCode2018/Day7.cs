using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace AdventOfCode2018
{
    public class TestDay7
    {
        [Fact]
        public void TestDay7A()
        {
            //Arrange

            /*  --> A--->B--
               /    \       \
              C-- > D----->  E
               \            /
                ----> F---- */
            string[] exampleInputs = new string[] { "Step C must be finished before step A can begin.", "Step C must be finished before step F can begin.", "Step A must be finished before step B can begin.", "Step A must be finished before step D can begin.", "Step B must be finished before step E can begin.", "Step D must be finished before step E can begin.", "Step F must be finished before step E can begin." };
            IEnumerable<string> fakeInputs = exampleInputs;
            IEnumerable<string> ActualInput = File.ReadLines("C:/Users/Svejk/Documents/AdventOfCode2018/AdventOfCode2018/day7Input.txt");
            var expectedResult = "CABDFE";
            var sut = new Day7();
            //Act
            var result = sut.Day7A(fakeInputs);
            //Assert
            Assert.Equal(expectedResult, result);
        }


    }

    public class Day7
    {
        private Regex _regex = new Regex(@"\w+\s(\w)\s\w+\s\w+\s\w+\s\w+\s\w+\s(\w)\s\w+\s\w+.");


        public string Day7A(IEnumerable<string> input)
        {
            string res ="";
            List<(string, string)> OrderList = new List<(string, string)>();

            foreach (string s in input.ToList())
            {
                Match match = _regex.Match(s);

                OrderList.Add((match.Groups[1].Value, match.Groups[2].Value));
            }


                return res;
        }
    }
}
