using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Project1
{
    public class Rectangle 
    {
        public int length;
        public int width;
        public Rectangle(int length, int width)
        {
            if (length <= 0||width<=0)
            {
                Console.WriteLine("该长方形不合法，将构造长2宽1的长方形");
                length=2;
                width=1;
            }
            else
            {
                this.length = length;
                this.width = width;
            }
        }
        public int getLength() { return length; }
        public int getWidth() { return width; }
        public int getArea() { return length * width; }
        ~Rectangle() { }
    }

    public class Square
    {
        public int length;
        public Square(int length) 
        {
            if(length<=0)
                Console.WriteLine(  "正方形不合法");
            else 
                this.length = length; 
        }
        public int getLength() { return length; }
        public int getArea() { return length*length; }
    }

    public class Triangle
    {
        public int a;
        public int b;
        public int c;
        public Triangle(int a, int b, int c)
        {
            if(a<=0||b<=0||c<=0||a+b<=c||b+c<=a||a+c<=b) 
            {
                Console.WriteLine("三角形不合法");
            }
            else 
            {
                this.a=a;
                this.b=b;
                this.c=c;
            }            
        }

        public int getA() { return a; }
        public int getB() { return b; }
        public int getC() { return c; }
        public double getArea() 
        {
            float p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle R1=new Rectangle(2,3);
            int a=R1.getArea();
            Console.WriteLine(  a);
            Rectangle R2=new Rectangle(0,3);
            Square S1 = new Square(3);
            a=S1.getArea();
            Console.WriteLine(a);
            Square S2 = new Square(0);
            Triangle T1 = new Triangle(3, 4, 5);
            double b=T1.getArea();
            Console.WriteLine(b);
            Triangle T2 = new Triangle(3, 4, 8);
            Triangle T3 = new Triangle(3, 0, 2);
            Console.ReadLine();
        }
    }
}
