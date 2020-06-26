using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{

    
    public class Queue<T>
    {
        DoubleUnit<T> queue;
        DoubleUnit<T> end_pointer;
        int size = 0;

        public void Push(T value)
        {
            if (size == 0)
            {
                queue = new DoubleUnit<T>();
                queue.value = value;
                end_pointer = queue;
                size++;
                return;
            }
            end_pointer.next = new DoubleUnit<T>();
            DoubleUnit<T> p = end_pointer;
            end_pointer = end_pointer.next;
            end_pointer.value = value;
            end_pointer.previous = p;
            size++;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw (new Exception("Empty queue"));
            }
            
            if (queue.next != null)
            {
                T var = queue.value;
                queue = queue.next;
                queue.previous = null;
                size--;
                return var;

            }
            //Last node
            T value = end_pointer.value;
            queue = null;
            size--;
            return value;
        }

        public void Clear()
        {
            queue = null;
            size = 0;
        }

        public int Cout
        {
            get
            {
                return size;
            }
        }
    }
}
