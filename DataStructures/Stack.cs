using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public interface IStack<T> {
        void Push(T Value);
        T Pop();

        void Clear();
    }

    class StackNode<T>
    {
        public T value;
        public StackNode<T> next;
        public StackNode<T> previous;
    }
    public class Stack<T>: IStack<T>
    {
        StackNode<T> stack = null;
        StackNode<T> end_pointer = null;
        public void Push(T value)
        {
            if (size == 0)
            {
                stack = new StackNode<T>();
                stack.value = value;
                end_pointer = stack;
                size++;
                return;
            }
            end_pointer.next = new StackNode<T>();
            StackNode<T> p = end_pointer;
            end_pointer = end_pointer.next;
            end_pointer.value = value;
            end_pointer.previous = p;
            size++;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw(new Exception("Empty stack"));
            }
            if (end_pointer.previous != null)
            {
                T var = end_pointer.value;
                end_pointer = end_pointer.previous;
                end_pointer.next = null;
                size--;
                return var;

            }
            //First node
            T value = end_pointer.value;
            stack = null;
            size--;
            return value;
        }

        public void Clear()
        {
            stack = null;
            size = 0;
        }

        int size = 0;

        public int Cout
        {
            get
            {
                return size;
            }
        }
    }
}
