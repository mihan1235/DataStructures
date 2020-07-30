using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace TestBinaryTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataStructures.BinaryTree<string, uint> tree = new DataStructures.BinaryTree<string, uint>();
            tree.Add("sdf", 5);
            tree.Add("sd", 4);
            tree.Add("dfhl", 18);
            tree.Add("öää", 29);
            tree.Add("zui", 9);

            {
                List<uint> res = new List<uint>();
                List<uint> prefix_order_list = new List<uint>{ 5, 18, 29, 9, 4 };
                tree.PrefixTraverse((a) =>
                {
                    Debug.WriteLine(a.key);
                    res.Add(a.key);
                });
                for (int i = 0; i < res.Count; i++)
                {
                    Debug.Assert(res[i] == prefix_order_list[i]);
                }               
            }

            {
                var (value, state) = tree.Find(9);
                Debug.Assert(state == DataStructures.FoundState.Found);
                (value, state) = tree.Find(7);
                Debug.Assert(state == DataStructures.FoundState.NotFound);
            }

            {
                List<uint> res = new List<uint>();
                tree.Delete(18);
                tree.PrefixTraverse((a) =>
                {
                    Debug.WriteLine(a.key);
                    res.Add(a.key);
                });
                List<uint> prefix_order_list = new List<uint> { 5, 9, 29, 4 };
                for (int i = 0; i < res.Count; i++)
                {
                    Debug.Assert(res[i] == prefix_order_list[i]);
                }

                tree.Delete(4);
                res.Clear();
                tree.PrefixTraverse((a) =>
                {
                    Debug.WriteLine(a.key);
                    res.Add(a.key);
                });
                prefix_order_list = new List<uint> { 5, 9, 29};
                for (int i = 0; i < res.Count; i++)
                {
                    Debug.Assert(res[i] == prefix_order_list[i]);
                }

                tree.Add("sdfghj", 9);
                tree.Add("efwefwe", 10);
                tree.Add("üooüo", 11);
                res.Clear();
                tree.Delete(9);
                tree.PrefixTraverse((a) =>
                {
                    Debug.WriteLine(a.key);
                    res.Add(a.key);
                });
                prefix_order_list = new List<uint> { 5, 11, 29, 10 };
                for (int i = 0; i < res.Count; i++)
                {
                    Debug.Assert(res[i] == prefix_order_list[i]);
                }
            }



        }
    }
}
