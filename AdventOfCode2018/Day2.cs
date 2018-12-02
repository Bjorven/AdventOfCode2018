using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FakeItEasy;
using System.IO;

namespace AdventOfCode2018
{
    public class TestDay2
    {
        [Fact]
        public void TestDay2A()
        {
            //Arrange

            string[] exampleInputs = new string[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };

            

            IEnumerable<string> fakeInputs = exampleInputs;


            int expectedResult = 12;


            var sut = new Day2();

            //Act

            var result = sut.Day2A(fakeInputs);

            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void TestDay2B()
        {
            //ARRANGE
            string[] exampleInputs = new string[] { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" };

            IEnumerable<string> fakeInputs = exampleInputs;
            var expectedResult = 2;

            var sut = new Day2();

            //ACT
            var result = sut.Day2B(fakeInputs);

            //ASSERT
            Assert.Equal(expectedResult, result.Count());
        }
    }
    public class Day2
    {
        private int _foundTwice;
        private int _foundtripple;
        internal readonly IEnumerable<string> _lines = File.ReadLines("C:/Users/Svejk/Documents/AdventOfCode2018/AdventOfCode2018/day2Input.txt").ToList();

        public int Day2A(IEnumerable<string> input)
        {


            foreach (string s in input)
            {
                int count = 0;
                bool hasFoundTwice = false;
                bool hasFoundTripple = false;

                foreach (char c in s)
                {
                    count = s.Count(x => x == c);

                    switch (count)
                    {
                        case 2:

                            if (!hasFoundTwice)
                            {
                                _foundTwice++;
                                hasFoundTwice = true;
                            }
                            continue;
                        case 3:
                            if (!hasFoundTripple)
                            {
                                _foundtripple++;
                                hasFoundTripple = true;
                            }
                            continue;
                        default:
                            continue;

                    }
                }

            }
            return _foundTwice * _foundtripple;
        }


        public IEnumerable<string> Day2B(IEnumerable<string> inputs)
        {
            

            if (inputs.Count() == 2)
                return inputs;

            foreach(string s in inputs)
            {
                var result = inputs.TakeWhile(x=> s.Single( )

                //foreach (char c in s)
                //{

                //    var result = inputs.
                //    if (result.Count() < 0)
                //    {
                //        Day2B(result);
                //        break;
                //    }
                //}

            }

            return null;
        }



    }

}
