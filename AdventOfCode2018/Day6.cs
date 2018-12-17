using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2018
{
    public class TestDay6
    {
        [Fact]
        public void TestDay6A()
        {
            //ARRANGE
            IEnumerable<string> actual = File.ReadLines("day6Input.txt");
            List<(int, int)> a = new List<(int, int)>();
            a.Add((1, 1));
            a.Add((1, 6));
            a.Add((8, 3));
            a.Add((3, 4));
            a.Add((5, 5));
            a.Add((8, 9));
            var expectedRes = 17;
            IEnumerable<(int, int)> fakeInput = a;
            var sut = new Day6();
            //ACT

            var res = sut.Day6A(actual);
            //ASSERT
            Assert.Equal(expectedRes, res);
        }
    }
    public class Day6
    {
        private Regex _regex = new Regex(@"(\d+),\s(\d+)");


        public int Day6A(IEnumerable<string> input)
        {
            List<(int, int)> coordinates = new List<(int, int)>();

            foreach (string s in input.ToList())
            {
                Match match = _regex.Match(s);
                coordinates.Add((int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)));
               
            }

            int xMin = 0;
            int xMax = 0;
            int yMin = 0;
            int yMax = 0;
            var identifyier = 0;


            List<Coordinate> Scheme = new List<Coordinate>();
            List<Coordinate> finitiveScheme = new List<Coordinate>();

            Dictionary<int, (int, int)> idsAndCoordinates = new Dictionary<int, (int, int)>();
            HashSet<int> infiniteIDs = new HashSet<int>();
            foreach ((int, int) tuple in coordinates)
            {

                idsAndCoordinates.Add(identifyier++, tuple);
                if (xMax < tuple.Item1)
                {
                    xMax = tuple.Item1;
                }
                if (yMax < tuple.Item2)
                {
                    yMax = tuple.Item2;
                }
            }

            for (int Y = yMin; Y <= yMax; Y++)
            {

                for (int X = xMin; X <= xMax; X++)
                {
                    var shortestDistance = int.MaxValue;
                    var closestID = 0;

                    foreach (var (id, (x, y)) in idsAndCoordinates)
                    {
                        var tempDistance = Math.Abs(x - X) + Math.Abs(y - Y);
                        if (tempDistance < shortestDistance)
                        {
                            shortestDistance = tempDistance;
                            closestID = id;

                        }
                        else if (tempDistance == shortestDistance && closestID != id)
                        {
                            closestID = -1;
                        }
                    }
                    Scheme.Add(new Coordinate { id = closestID, Coordinates = new Point { X = X, Y = Y } });
                    if (closestID != -1 && (X == xMin || X == xMax || Y == yMin || Y == yMax)) infiniteIDs.Add(closestID);

                }

            }

            foreach (int id in infiniteIDs)
            {
                Scheme.RemoveAll(x=>x.id ==id);
            }
            Scheme.RemoveAll(x => x.id == -1);

            var large = Scheme.GroupBy(g => g.id).Select(group => group.Count()).Max();





            return large;
        }
    }

    public class Coordinate
    {
        public int id { get; set; }
        public Point Coordinates { get; set; }

    }
}
