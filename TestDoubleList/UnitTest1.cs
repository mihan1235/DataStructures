using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Diagnostics;

namespace TestDoubleList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DoubleList<int> list = new DoubleList<int>();
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            Debug.Assert(list.Count == 4);
            Debug.Assert(list[0] == 4);
            Debug.Assert(list[1] == 5);
            Debug.Assert(list[2] == 6);
            Debug.Assert(list[3] == 7);

            list[1] = 19;
            list[5] = 12;
            list.DeleteAt(1);

            Debug.Assert(list.Count == 5);
            Debug.Assert(list[0] == 4);
            Debug.Assert(list[1] == 6);
            Debug.Assert(list[2] == 7);
            Debug.Assert(list[4] == 12);

            list.DeleteAt(1);

            Debug.Assert(list.Count == 4);
            Debug.Assert(list[0] == 4);
            Debug.Assert(list[1] == 7);
            Debug.Assert(list[2] == 0);
            Debug.Assert(list[3] == 12);

            list.Delete(12);
            Debug.Assert(list.Count == 3);
            Debug.Assert(list[0] == 4);
            Debug.Assert(list[1] == 7);
            Debug.Assert(list[2] == 0);
        }
    }
}
