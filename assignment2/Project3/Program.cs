using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int []array=new int[101];
            for (int a = 1; a<=100; a++) { array[a]=a; }
            for(int a = 2; a<=100; a++)
            {
                for(int b = 1; b<=100; b++)
                {
                    if (array[b]%a==0&&b!=a) {  array[b]=-1; }
                }
            }
            Console.WriteLine(  "埃氏筛法100内素数为");
            for (int a=1;a<=100;a++)
            {
                if (array[a]!=-1) { Console.WriteLine(  a); }
            }
            Console.ReadLine();
        }
    }
}
