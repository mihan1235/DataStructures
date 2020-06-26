using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Diagnostics;


namespace TestQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Queue<int> queue = new Queue<int>();

            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            Debug.Assert(queue.Cout == 3);

            Debug.Assert(queue.Pop() == 1);
            Debug.Assert(queue.Pop() == 2);
            Debug.Assert(queue.Pop() == 3);

            Debug.Assert(queue.Cout == 0);
        }
    }
}
