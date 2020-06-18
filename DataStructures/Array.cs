using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Array<T> where T: IComparable<T>
    {
        T[] arr = null;
        int size = 0;
        int max_size = 10;
        bool need_resize = false;

        public T this[int index] {
            get
            {
                if ((size == 0) && (index >= size))
                {
                    throw (new Exception("Out of array"));
                }

                return arr[index];
            }

            set
            {
                while (index > max_size)
                {
                    max_size *= 2;
                    need_resize = true;
                }
                if (size == 0)
                {
                    arr = new T[max_size];
                    need_resize = false;
                }
                if (need_resize)
                {
                    ResizeArr();
                }
                arr[index] = value;
                size = index + 1;
            }
        }

        private void ResizeArr()
        {
            if (arr != null)
            {
                T[] new_arr = new T[max_size];
                for (int i = 0; i < arr.Length; i++)
                {
                    new_arr[i] = arr[i];
                }
                arr = new_arr;
                return;
            }
            arr = new T[max_size];
            need_resize = false;
        }

        public void DeleteAt(int index)
        {
            if ((arr == null) && (index > size))
            {
                throw (new Exception("No element with such index in array"));
            }
            T[] new_arr = new T[max_size];
            int i = 0;
            int j = 0;
            while (j < size)
            {
                if (j != index)
                {
                    new_arr[i] = arr[j];
                    i++;
                }            
                j++;
                
            }
            arr = new_arr;
            size--;
        }
        public int ReturnIndexIfFound(T value)
        {
            int i = 0;
            while (i < size)
            {
                if (arr[i].CompareTo(value) == 0)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public bool Find(T value)
        {
            int i = 0;
            while (i < size)
            {
                if (arr[i].CompareTo(value) == 0)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        public void Delete(T value)
        {
            int index = ReturnIndexIfFound(value);
            if (index != -1)
            {
                DeleteAt(index);
            }
        }

        public int Length
        {
            get
            {
                return size;
            }
        }
    }
}
