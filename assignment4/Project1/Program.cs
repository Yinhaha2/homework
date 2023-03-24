using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution4
{

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public Node(T t)
        {
            Next = null;
            Value=t;
        }
    }
    public class List<T>
    {
        public Node<T> head;
        public Node<T> tail;
        public List()
        {
            head=null;
            tail=null;
        }
        public Node<T> Head
        {
            get { return head; }
        }
        public void Add(T t)
        {
            Node<T> n=new Node<T>(t);
            if(tail==null) {
                head=tail=n;
            }
            else { tail.Next=n;tail=n; }
        }

    }
    internal class Program
    {
        public static void ForEach(List<int> L)
        {
            Node<int> p = L.head;
            int max = p.Value;
            int min = p.Value;
            int all = 0;
            while (p!=null)
            {
                if (p.Value>max) { max= p.Value; }
                if (p.Value<min) { min= p.Value; }
                Console.WriteLine(p.Value);
                all+=p.Value;
                p= p.Next;
            }
            Console.WriteLine("max"+max);
            Console.WriteLine("min"+min);
            Console.WriteLine("all"+all);
        }
        static void Main(string[] args)
        {
            List<int> L = new List<int>();
            for (int a = 0; a<=12; a++)
            {
                L.Add(a);
            }
            ForEach (L) ;
            Console.ReadLine();
        }
    }
}
