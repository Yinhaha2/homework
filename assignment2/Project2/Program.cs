using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            Console.WriteLine("输入数组长度");
            int length = int.Parse(Console.ReadLine());
            for (int a = 0; a<length; a++)
            {
                Console.WriteLine("输入array["+a+"]");
                int b = int.Parse(Console.ReadLine());
                array.Add(b);
            }
            int min= (int)array[0];
            int mine=0;
            int max=(int)array[0];
            int maxe=0;
            int sum=0;
            double average;
            for(int a = 0; a<length; a++)
            {
                int value=(int)array[a];
                if (value< min) 
                {
                    min=value;
                    mine=a;
                }
                if (value> max)
                {
                    max=value;  
                    maxe=a;
                }
                sum=sum+value;
            }
            average=sum/length; 
            Console.WriteLine( "最小值array["+mine+"]=" +min);
            Console.WriteLine("最大值array["+maxe+"]=" +max);
            Console.WriteLine( "和="+sum );
            Console.WriteLine(  "平均值="+average);
            Console.ReadLine();
        }
    }
}
