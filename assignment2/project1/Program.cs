using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            ArrayList   array = new ArrayList();
            Console.WriteLine("输入数组长度");
            int length=int.Parse (Console.ReadLine());
            for (int a = 0; a<length; a++)
            {
                Console.WriteLine("输入array["+a+"]");
                int b = int.Parse (Console.ReadLine());
                array.Add(b);
            }
            int e = 0;
            int c = 0;//因子个数不含1与本身
            for (e=0; e<length; e++)
            {
                int value = (int)array[e];
                
                for (int d = 1; d<value; d++)
                {
                    if (value%d==0&&d!=1&&d!=value)
                    {
                       c++;
                    }
                }
                if (c==0)
                {
                    Console.WriteLine("素数为array["+e+"]:"+array[e]);
                }
                c=0;

            }
            Console.ReadLine();
        }
    }
}
