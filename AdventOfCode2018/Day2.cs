using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2018
{
    public class TestDay2
    {
        [Fact]
        public void testDay2A()
        {
            //Arrange
            string fakeinput1 = "abcdef"; //contains no letters that appear exactly two or three times.
            string fakeinput2 = "bababc"; //contains two a and three b, so it counts for both.
            string fakeinput3 = "abbcde"; //contains two b, but no letter appears exactly three times.
            string fakeinput4 = "abcccd"; //contains three c, but no letter appears exactly two times.
            string fakeinput5 = "aabcdd"; //contains two a and two d, but it only counts once.
            string fakeinput6 = "abcdee"; //contains two e.
            string fakeinput7 = "ababab"; //contains three a and three b, but it only counts once.
            List<string> fakeInputs = new List<string> { fakeinput1, fakeinput2, fakeinput3, fakeinput4, fakeinput5, fakeinput6, fakeinput7 };
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
        int checksum;
        public int Day2A(List<string> input)
        {
            return checksum;
        }
    }
}
