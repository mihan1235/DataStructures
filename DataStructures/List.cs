using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataStructures
{
    class Unit<T>
    {
        public T value;
        public Unit<T> next = null;
    }

    public interface IList<T> where T: IComparable<T>
    {
        //bool Add(T value);
        //bool Delete(T value);
        bool Find(T value);
    }

    public class List<T> : IList<T> where T : IComparable<T>
    {
        Unit<T> list = null;
        int size = 0;

        void InitList(T value)
        {
            list = new Unit<T>();
            pointer = list;
            pointer.value = value;
            pointer.next = null;
            size++;
            p_end = pointer;
        }
        public void Add(T value)
        {
            if (size == 0)
            {
                InitList(value);
                return;
            }
            p_end.next = new Unit<T>();
            p_end = p_end.next;
            p_end.next = null;
            p_end.value = value;
            p_end_position++;
            size++;
        }
        public void Delete(T value) {
            int index = GetIndexIfFound(value);
            if (index != -1)
            {
                DeleteAt(index);
            }
        }
        public void DeleteAt(int index)
        {
            if ((size == 0) || (index > p_end_position) || (index < 0 ))
            {
                throw (new Exception("Out of list"));
            }
            if (index == 0)
            {
                //delete the begining of the list
                if (list.next != null)
                {
                    Unit<T> p = list.next;
                    list = null;
                    list = p;
                }
                else
                {
                    list = null;
                }
                size--;
                p_end_position--;
                if (pointer_position != 0) pointer_position--;
                return;
            }
            if (index == p_end_position)
            {
                //delete the end of the list

                Goto(index-1);
                pointer.next = null;
                p_end = pointer;
                size--;
                p_end_position--;
                return;
            }

            //delete the unit in the list
            Goto(index - 1);
            Unit<T> del_p2 = pointer.next.next;
            pointer.next = null;
            pointer.next = del_p2;

            size--;
            p_end_position--;
        }

        Unit<T> search_pointer = null;
        public bool Find(T value) {
            if (size != 0)
            {
                search_pointer = list;
                while (search_pointer.next != null)
                {
                    if (search_pointer.value.CompareTo(value) == 0) return true;
                    search_pointer = search_pointer.next;
                }
            }
            return false;
        }

        public int GetIndexIfFound(T value)
        {
            if (size != 0)
            {
                search_pointer = list;
                int index = 0;
                while (search_pointer.next != null)
                {
                    if (search_pointer.value.CompareTo(value) == 0) return index;
                    search_pointer = search_pointer.next;
                    index++;
                }
            }
            return -1;
        }
        Unit<T> pointer = null;
        int pointer_position = 0;
        Unit<T> p_end = null;
        int p_end_position = 0;

        void Goto(int index)
        {
            if (pointer_position > index)
            {
                pointer = list;
                pointer_position = 0;
            }
            while (pointer_position < index)
            {
                pointer = pointer.next;
                pointer_position++;
            }
        }
        public T this[int index]
        {
            get
            {
                if ((size == 0) || (index > p_end_position) || (index < 0))
                {
                    throw (new Exception("Out of list"));
                }

                if (index < p_end_position)
                {

                    Goto(index);
                    return pointer.value;


                }
                if (index == p_end_position) { return p_end.value; }
                if (index == pointer_position) { return pointer.value; }
                return pointer.value;
            }

            set
            {
                if (size == 0)
                {
                    InitList(value);
                    return;
                }
                while (index > p_end_position)
                {
                    p_end.next = new Unit<T>(); 
                    p_end = p_end.next;
                    p_end.next = null;
                    p_end_position++;
                    size++;
                }
                if (index == p_end_position)
                {
                    p_end.value = value;
                    return;
                }

                if (index < p_end_position)
                {
                    Goto(index);
                    pointer.value = value;
                }
            }
        }


        public void PrintList()
        {
            if (size == 0)  Console.WriteLine("empty list"); 
            Unit<T> p = list;
            int i = 0;
            
            do{
                Console.WriteLine($"{i}: {p.value}");
                p = p.next;
                i++;
            }while(p.next != null) ;
            Console.WriteLine($"{i}: {p.value}");
        }

        public void PrintDebug()
        {
            Console.WriteLine($"Size: {size}");
            Console.WriteLine($"Pointer's index: {pointer_position}");
            Console.WriteLine($"End Pointer's position: {p_end_position}");
        }

        public int Count
        {
            get
            {
                return size;
            }
        }
    }
}
