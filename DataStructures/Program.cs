using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace DataStructures
{

    public class TestFunctions
    {
        public static void TestList()
        {
            try
            {
                List<int> list = new List<int>();
                list.Add(4);
                list.Add(5);
                list.Add(6);
                list.Add(7);

                list.PrintList();
                list.PrintDebug();

                list[1] = 19;
                list[5] = 12;
                list.DeleteAt(1);
                list.PrintList();
                list.PrintDebug();

                list.DeleteAt(1);
                list.PrintList();
                list.PrintDebug();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestFunctions.TestList();
        }
    }
}
