using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public enum FoundState
    {
        Found,
        NotFound
    }
    public interface ITree<T, K>
    {
        void PrintBinaryTree();
        void Add(T value, K key);

        void Delete(K key);

        (T value, FoundState key) Find(K key);

        void Clear();
    }

    public class TreeNode<T, K>
    {
        public T value;
        public K key;
        public TreeNode<T,K> right;
        public TreeNode<T,K> left;
    }

    public delegate void f<T, K>(TreeNode<T, K> node);

    public class BinaryTree<T,K> : ITree<T,K> where K: IComparable<K>
    {
        TreeNode<T,K> tree;

        
        void _InfixTraverse(TreeNode<T, K> node, f<T, K> f)
        {
            TreeNode<T, K> ptr = node;
            if (ptr != null)
            {
                _InfixTraverse(ptr.left, f);
                f(ptr);
                _InfixTraverse(ptr.right, f);
            }
        }

        // Элементы по возрастанию
        public void InfixTraverse(f<T, K> f)
        {
            _InfixTraverse(tree, f);
        }

        // Элементы в порядке, как в дереве
        void _PrefixTraverse(TreeNode<T, K> node, f<T, K> f)
        {
            TreeNode<T, K> ptr = node;
            if (ptr != null)
            {
                f(ptr);
                _PrefixTraverse(ptr.left, f);
                _PrefixTraverse(ptr.right, f);
            }
        }

        // Элементы в обратном порядке, как в дереве
        public void PrefixTraverse(f<T, K> f)
        {
            _PrefixTraverse(tree, f);
        }

        void _PostfixTraverse(TreeNode<T, K> node, f<T, K> f)
        {
            TreeNode<T, K> ptr = node;
            if (ptr != null)
            {
                _PostfixTraverse(ptr.left, f);
                _PostfixTraverse(ptr.right, f);
                f(ptr);
            }
        }
        public void PostfixTraverse(f<T, K> f)
        {

            _PostfixTraverse(tree, f);
        }

        public void PrintBinaryTree() { }
        public void Add(T value,  K key) {
            if (tree == null)
            {
                tree = new TreeNode<T, K>
                {
                    value = value,
                    key = key
                };
                return;
            }
            TreeNode<T,K> ptr = tree;
            
            while ((ptr.right != null)&&(ptr.left != null))
            {
                switch (key.CompareTo(ptr.key))
                {
                    case int result when result > 0:
                        ptr = ptr.left;
                        break;
                    case int result when result < 0:
                        ptr = ptr.right;
                        break;
                    case 0:
                        return;
                }   
            }

            switch (key.CompareTo(ptr.key))
            {
                case int tmp when tmp > 0:
                    ptr.left = new TreeNode<T,K>();
                    ptr = ptr.left;
                    break;
                case int tmp when tmp < 0:
                    ptr.right = new TreeNode<T,K>();
                    ptr = ptr.right;
                    break;
            }
            ptr.value = value;
            ptr.key = key;
        }

        void _Delete(ref TreeNode<T,K> tree, K key)
        {
            TreeNode<T, K> ptr = tree;
            if (tree != null)
            {
                switch (key.CompareTo(ptr.key))
                {
                    case int res when res < 0:
                        _Delete(ref ptr.right, key);
                        break;
                    case int res when res > 0:
                        _Delete(ref ptr.left, key);
                        break;
                    case int res when res == 0:
                        if ((ptr.right == null) && (ptr.left == null))
                        {
                            tree = null;
                            break;
                        }

                        if ((ptr.right == null) && (ptr.left != null))
                        {
                            TreeNode<T, K> child = ptr.left;
                            ptr.value = child.value;
                            ptr.key = child.key;
                            ptr.left = child.left;
                            ptr.right = child.right;
                            break;
                        }

                        if ((ptr.right != null) && (ptr.left == null))
                        {
                            TreeNode<T, K> child = ptr.right;
                            ptr.value = child.value;
                            ptr.key = child.key;
                            ptr.left = child.left;
                            ptr.right = child.right;
                            break;
                        }

                        //node has two childreen

                        if (ptr.right.left != null)
                        {
                            TreeNode<T, K> child = ptr.right.left;
                            ptr.value = child.value;
                            ptr.key = child.key;
                            _Delete(ref ptr.right.left, child.key);
                            break;
                        }

                        TreeNode<T, K> tmp = ptr.right;
                        ptr.value = tmp.value;
                        ptr.key = tmp.key;
                        ptr.right = ptr.right.right;
                        break;
                }
            }
        }

        public void Delete(K key) {
            _Delete(ref tree, key);
        }

        (T value, FoundState key) __Find(TreeNode<T,K> tree, K key)
        {
            TreeNode<T,K> ptr = tree;
            if (ptr != null)
            {
                int res = key.CompareTo(ptr.key);
                if (res == 0) return (ptr.value, FoundState.Found);
                if (res > 0) return __Find(ptr.left,key);
                if (res < 0) return __Find(ptr.right, key);
            }
            return (default(T), FoundState.NotFound);
        }

        public (T value, FoundState key) Find(K key) {
            return __Find(tree, key);
        }

        public void Clear()
        {
            if (tree != null) tree = null;
        }
    }
}
