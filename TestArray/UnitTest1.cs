using Microsoft.VisualStudio.TestTools.UnitTesting;

using DataStructures;
using System.Diagnostics;

namespace TestArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Array<int> arr = new Array<int>();
            arr[0]= 4;
            arr[1] = 5;
            arr[2] = 6;
            arr[3] = 7;
            Debug.Assert(arr.Length == 4);
            Debug.Assert(arr[0] == 4);
            Debug.Assert(arr[1] == 5);
            Debug.Assert(arr[2] == 6);
            Debug.Assert(arr[3] == 7);

            arr[1] = 19;
            arr[5] = 12;
            arr.DeleteAt(1);

            Debug.Assert(arr.Length == 5);
            Debug.Assert(arr[0] == 4);
            Debug.Assert(arr[1] == 6);
            Debug.Assert(arr[2] == 7);
            Debug.Assert(arr[4] == 12);

            arr.DeleteAt(1);


            Debug.Assert(arr.Length == 4);
            Debug.Assert(arr[0] == 4);
            Debug.Assert(arr[1] == 7);
            Debug.Assert(arr[2] == 0);
            Debug.Assert(arr[3] == 12);

            arr.Delete(12);
            Debug.Assert(arr.Length == 3);
            Debug.Assert(arr[0] == 4);
            Debug.Assert(arr[1] == 7);
            Debug.Assert(arr[2] == 0);
            arr[12] = 56;
            arr[13] = 57;

            Debug.Assert(arr.Length == 14);
            Debug.Assert(arr[0] == 4);
            Debug.Assert(arr[1] == 7);
            Debug.Assert(arr[2] == 0);

            Debug.Assert(arr[12] == 56);
            Debug.Assert(arr[13] == 57);
        }
    }
}
