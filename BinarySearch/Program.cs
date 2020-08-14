using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructures;

namespace BinarySearch
{
    class Program
    {
        static FoundState BinarySearch(int value, Array<int> arr)
        {
            Sort(arr);
            int begin = 0;
            int end = arr.Length;
            int middle = arr.Length / 2;
            while (end-1 > begin)
            {
                if (value < arr[middle])
                {
                    end = middle;
                }
                if (value > arr[middle])
                {
                    begin = middle;
                }
                if (value == arr[middle])
                {
                    return FoundState.Found;
                }
                middle = (end - begin) / 2 + begin ;
            }
            return FoundState.NotFound;
        }

        static void Sort(Array<int> arr)
        {

        }

        static void Main(string[] args)
        {
            Array<int> arr = new Array<int>();
            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            arr[3] = 4;
            arr[4] = 5;
            FoundState foundState = BinarySearch(4, arr);
            Debug.Assert(foundState == FoundState.Found);
            foundState = BinarySearch(5, arr);
            Debug.Assert(foundState == FoundState.Found);
            foundState = BinarySearch(8, arr);
            Debug.Assert(foundState == FoundState.NotFound);
            Debug.Print(foundState.ToString());
        }
    }
}
