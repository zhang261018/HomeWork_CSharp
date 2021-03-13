using System;
using System.Collections.Generic;
using System.Text;

namespace ListArray
{
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public GenericList(T[] list)
        {
            Node<T> tmp = this.Head;
            int length = list.Length;

            foreach(T obj in list)
            {
                Node<T> n = new Node<T>(obj);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        //ForEach函数
        public void ForEach(Action<T> act)
        {
            Node<T> ptr = this.Head.Next;

            //遍历链表
            while (ptr != tail)
            {
                act(ptr.Data);
                ptr = ptr.Next;
            }
            act(tail.Data);
        }
        
    }
}
