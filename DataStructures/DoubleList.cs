using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class DoubleUnit<T>
    {
        public T value;
        public DoubleUnit<T> next = null;
        public DoubleUnit<T> previous = null;
    }

    public class DoubleList<T>  where T: IComparable<T>
    {
        DoubleUnit<T> list = null;
        int size = 0;
        DoubleUnit<T> search_pointer = null;
        DoubleUnit<T> pointer = null;
        int pointer_position = 0;
        DoubleUnit<T> p_end = null;
        int p_end_position = 0;

        void InitList(T value)
        {
            list = new DoubleUnit<T>();
            pointer = list;
            pointer.value = value;
            pointer.next = null;
            pointer.previous = null;
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
            p_end.next = new DoubleUnit<T>();
            DoubleUnit<T> p = p_end;
            p_end = p_end.next;
            p_end.next = null;
            p_end.value = value;
            p_end.previous = p;
            p_end_position++;
            size++;
        }
        public void Delete(T value)
        {
            int index = GetIndexIfFound(value);
            if (index != -1)
            {
                DeleteAt(index);
            }
        }
        public void DeleteAt(int index)
        {
            if ((size == 0) || (index > p_end_position) || (index < 0))
            {
                throw (new Exception("Out of list"));
            }
            if (index == 0)
            {
                //delete the begining of the list
                if (list.next != null)
                {
                    DoubleUnit<T> p = list.next;
                    list = null;
                    list = p;
                    list.previous = null;
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

                Goto(index - 1);
                pointer.next = null;
                p_end = pointer;
                size--;
                p_end_position--;
                return;
            }

            //delete the unit in the list
            Goto(index);
            DoubleUnit<T> p1 = pointer.next;
            pointer = pointer.previous;
            
            pointer.next = null;
            pointer.next = p1;
            p1.previous = pointer;

            size--;
            p_end_position--;
            pointer_position--;
        }


        public bool Find(T value)
        {
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
                while (index < size)
                {
                    if (search_pointer.value.CompareTo(value) == 0) return index;
                    search_pointer = search_pointer.next;
                    index++;
                }
            }
            return -1;
        }


        void Goto(int index)
        {
            int bias = index - pointer_position;
            switch (bias) {
                case 0: 
                    break;
                //Pointer's position is greater then index
                case int _ when bias < 0:
                    for (int i =0; i < Math.Abs(bias); i++)
                    {
                        pointer = pointer.previous;
                        pointer_position--;
                    }
                    break;
                //Pointer_position is less then index
                case int _ when bias > 0:
                    for (int i = 0; i < bias; i++)
                    {
                        pointer = pointer.next;
                        pointer_position++;
                    }
                    break;
                default:
                    break;
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
                    p_end.next = new DoubleUnit<T>();
                    DoubleUnit<T> p = p_end;
                    p_end = p_end.next;
                    p_end.previous = p;
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

        public int Count
        {
            get
            {
                return size;
            }
        }
    }
}
