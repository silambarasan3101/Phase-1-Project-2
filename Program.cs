using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace Phase1_Project__2
{
    public class Program
    {

        static void Main(string[] args)
        {
            int ss;

            Console.WriteLine("\n 1.sort \n 2.search");
            ss = Convert.ToInt32(Console.ReadLine());
            switch (ss)
            {
                case 1:
                    if (args is null)
                    {
                        throw new ArgumentNullException(nameof(args));
                    }

                    string textFile = "E:\\Project\\Project 2\\Studentdata.txt";

                    String[] lines = File.ReadAllLines(textFile);
                    Dictionary<String, Int32> Ages = new Dictionary<String, Int32>();

                    foreach (String Age in lines)
                    {
                        String[] split = Age.Split(' ');

                        if (Ages.ContainsKey(split[0]))
                        {
                            foreach (KeyValuePair<String, Int32> kvp in Ages)
                            {
                                if (kvp.Key == split[0])
                                {
                                    Ages[split[0]] += Convert.ToInt32(split[1]);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (split.Length > 1)
                                Ages.Add(split[0], Convert.ToInt32(split[1]));
                        }
                    }

                    // SORT ASCENDING AGE
                    var sorted2 = (from entry in Ages orderby entry.Value ascending select entry);
                    // Output
                    Console.WriteLine("\n\nSORT1: Ascending by Age");
                    Console.WriteLine("NAME,AGE");
                    foreach (KeyValuePair<String, Int32> kvp in sorted2)
                        Console.WriteLine("{0},{1}", kvp.Key, kvp.Value);

                    Console.WriteLine("\nPress any key to write SORT1 to file...\n");
                    Console.ReadKey();

                    // Write to file
                    File.WriteAllLines("E:\\Project\\Project 2\\SortByAge.txt", sorted2.Select(x => x.Key + "," + x.Value).ToArray());



                    // SORT ASCENDING NAME
                    var sorted4 = (from entry in Ages orderby entry.Key ascending select entry);
                    // Output
                    Console.WriteLine("\n\nSORT2: Ascending by Name");
                    Console.WriteLine("NAME,AGE");
                    foreach (KeyValuePair<String, Int32> kvp in sorted4)
                        Console.WriteLine("{0},{1}", kvp.Key, kvp.Value);

                    Console.WriteLine("\nPress any key to write SORT2 to file...\n");
                    Console.ReadKey();

                    // Write to file
                    File.WriteAllLines("E:\\Project\\Project 2\\SortByName.txt", sorted4.Select(x => x.Key + "," + x.Value).ToArray());



                    // Exit
                    Console.WriteLine("\nWritten to file!\n");

                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case 2:

                    string[] words = File.ReadAllText("E:\\Project\\Project 2\\Studentdata.txt").Split(' ');

                    string wordtobesearch;
                    Console.WriteLine("Enter the Name to search");
                    wordtobesearch = Console.ReadLine();
                    bool condition = false;
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Contains(wordtobesearch) == true)
                        {

                            condition = true;
                            break;

                        }
                        else
                        {
                            condition = false;
                        }


                    }
                    if (condition == true)
                    {
                        Console.WriteLine("Student data is present");
                    }
                    else
                    {
                        Console.WriteLine("Student data is not present");
                    }
                    break;

                    


            }
        }
    }
}
