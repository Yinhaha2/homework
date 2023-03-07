using System;
using System.Data;
namespace ConsoleApp1
{
   class Project1
    {
        static void Main(string[] args)
        {
            DataTable dt=new DataTable();
            string a,b,c;   
            Console.WriteLine( "输入一个数字" );
            a=Console.ReadLine();
            Console.WriteLine("输入运算符");
            b=Console.ReadLine();
            Console.WriteLine("输入第二个数字");
            c=Console.ReadLine();
            string d = a+b+c;
            int e =(int) dt.Compute(d,"");
            Console.WriteLine(  "结果为",e );
            Console.ReadLine();
        }
    }
}
