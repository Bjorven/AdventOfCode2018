using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2018
{
    public class testDay1
    {

    }
    public class Day1
    {



        public void CalcSequenze()
        {
            LinkedList<int> StoredFreq = new LinkedList<int>();
            int result = 0;
            int count = 0;
            string line = "";
            bool foundTwice = false;
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                while (foundTwice == false)
                {
                    using (StreamReader sr = new StreamReader("C:/Users/Svejk/Documents/Visual Studio 2017/Projects/AdventOfCode2018/AdventOfCode2018/day1Input.txt"))
                    {


                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            int a = Convert.ToInt32(line);
                            count++;

                            
                                result = result + a;


                                if (StoredFreq.Find(result) == null)
                                {
                                    StoredFreq.AddLast(result);
                                }
                                else
                                {
                                    Console.WriteLine("==========================");
                                    Console.WriteLine("==========================");

                                    Console.WriteLine(result);
                                    Console.WriteLine("==========================");
                                    Console.WriteLine("==========================");
                                    foundTwice = true;
                                    break;
                                }
                            
                            
                            
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }
            finally
            {

                Console.WriteLine("============================================");
                Console.WriteLine("============================================");
                Console.WriteLine("============================================");

                Console.WriteLine(result.ToString());
                Console.WriteLine(count.ToString());
                Console.WriteLine("============================================");
                Console.WriteLine("============================================");
                Console.WriteLine("============================================");

            }

        }



    }
}

