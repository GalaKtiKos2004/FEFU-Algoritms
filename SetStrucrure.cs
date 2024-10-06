using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        const string AddCommand = "ADD";
        const string PresentCommand = "PRESENT";
        const string CountCommand = "COUNT";

        string[] command;

        SortedSet<int> set = new SortedSet<int>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            command = Console.ReadLine().Split();

            switch (command[0])
            {
                case AddCommand:
                    set.Add(int.Parse(command[1]));
                    break;

                case PresentCommand:
                    Console.WriteLine(set.Contains(int.Parse(command[1])) ? "YES" : "NO");
                    break;

                case CountCommand:
                    Console.WriteLine(set.Count);
                    break;
            }
        }
    }
}