using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Diagnostics;

namespace TestStack
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Debug.Assert(stack.Cout == 3);

            Debug.Assert(stack.Pop() == 3);
            Debug.Assert(stack.Pop() == 2);
            Debug.Assert(stack.Pop() == 1);

            Debug.Assert(stack.Cout == 0);

        }
    }
}
