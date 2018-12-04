using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class TestDag3
    {
        [Fact]
        public void TestDay3A()
        {
            //Arrange
            string[] exampleInputs = new string []{ "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
            IEnumerable<string> ActualInput = File.ReadLines("C:/Users/Svejk/Documents/AdventOfCode2018/AdventOfCode2018/day3Input.txt");
            IEnumerable<string> fakeInputs = exampleInputs;

            var expectedResult = 4;
            

            var sut = new Day3();
            //Act
            var result = sut.Day3A(fakeInputs);
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void TestDay3B()
        {
            //Arrange
            string[] exampleInputs = new string[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
            IEnumerable<string> fakeInputs = exampleInputs;
            //IEnumerable<string> ActualInput = File.ReadLines("C:/Users/Svejk/Documents/AdventOfCode2018/AdventOfCode2018/day3Input.txt");

            var expectedResult = 3;
            var sut = new Day3();

            //Act
            var result = sut.Day3B(fakeInputs);

            //Assert
            Assert.Equal(expectedResult, result);

        }
    }
    public class Day3
    {

        

        public int Day3A(IEnumerable<string> input)
        {
            int numberOfDuplicatedSquares = 0;
            var regex = new Regex(@"[#](\d+)\s[@]\s(\d+)[,](\d+)[:]\s(\d+)[x](\d+)");
            HashSet<(int, int)> coordinates = new HashSet<(int, int)>();
            HashSet<(int, int)> duplicates = new HashSet<(int, int)>();




            foreach (var line in input.ToList())
            {
                Match match = regex.Match(line);

                
                var x = int.Parse(match.Groups[2].Value);
                var y = int.Parse(match.Groups[3].Value);
                var w = int.Parse(match.Groups[4].Value);
                var h = int.Parse(match.Groups[5].Value);

                for(int i = x; i < x+w; i++)
                {
                    for (int j = y; j < y+h; j++)
                    {
                        if (!coordinates.Add((i, j)))
                        {
                            
                            if (duplicates.Add((i, j)))
                            {
                                numberOfDuplicatedSquares++;
                            }
                        }
                        

                    }
                }
            }

            return numberOfDuplicatedSquares;
        }

        public int Day3B(IEnumerable<string> input)
        {
            

            var regex = new Regex(@"[#](\d+)\s[@]\s(\d+)[,](\d+)[:]\s(\d+)[x](\d+)");
            
            HashSet<int> unique = new HashSet<int>();
            Dictionary<(int, int), int> junktionTable = new Dictionary<(int, int), int>();

            foreach (var line in input)
            {
                Match match = regex.Match(line);

                var id = int.Parse(match.Groups[1].Value);
                var x = int.Parse(match.Groups[2].Value);
                var y = int.Parse(match.Groups[3].Value);
                var w = int.Parse(match.Groups[4].Value);
                var h = int.Parse(match.Groups[5].Value);
                unique.Add(id);


                for (int i = x; i < (x + w); i++)
                {
                    for (int j = y; j < (y + h); j++)
                    {
                        var currentPoint = (i, j);

                        if (junktionTable.ContainsKey(currentPoint))
                        {
                            unique.Remove(junktionTable[currentPoint]);

                            unique.Remove(id);
                            //remove from oldUnique, the one that conflicts with the current rectangle.

                        }

                        else
                        {
                            junktionTable.Add(currentPoint, id);
                        }

                    }
                }

            }

            return unique.First();

        }
    }
    
}



                        
                        