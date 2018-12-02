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
        public void testDay2A()
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
    }
    public class Day2
    {
        private int _foundTwice;
        private int _foundtripple;
        internal readonly IEnumerable<string> _lines = File.ReadLines("C:/Users/Svejk/Documents/AdventOfCode2018/AdventOfCode2018/day2Input.txt").ToList();

        public int Day2A(IEnumerable<string> input)
        {


            foreach (string s in _lines)
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
    }





    //public static class QueryObjects
    //{

    //    public static IQueryable<TSource> FindDouble <TSource>(this IQueryable<TSource> @this)
    //    {


    //        var result = @this.Where(x => x);

    //        return result;

    //    }


    //}

}
