using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    

    public class Rectangle
    {
        public int length;
        public int width;
        public double area;
        
        public Rectangle(int length, int width)
        {
            if (length <= 0||width<=0)
            {
                Console.WriteLine("该长方形不合法，将构造长2宽1的长方形");
                length=2;
                width=1;
                area=width*length;
            }
            else
            {
                
                this.length = length;
                this.width = width;
                area=width*length;
            }
        }
        public void getLength() { Console.WriteLine("长"+length); }
        public void getWidth() { Console.WriteLine("宽"+width); }
        public void getArea() { Console.WriteLine("面积"+area); }
        public double Area() { return area; }
    }

    public class Square
    {
        public int length;
        public double area;
        public Square(int length)
        {
            if (length<=0)
            {
                Console.WriteLine("正方形不合法,将构造边长为1的正方形");
                length=1;
                area=1;
            }
            else
            {
                this.length=length;
                area=length*length;
            }
        }
        public void getLength() { Console.WriteLine("长"+length); }
        public void getArea() { Console.WriteLine(  "面积"+area); }
        public double Area() { return area; }
    }

    public class Triangle
    {
        public int a;
        public int b;
        public int c;
        public double area;
        public Triangle(int a, int b, int c)
        {
            if (a<=0||b<=0||c<=0||a+b<=c||b+c<=a||a+c<=b)
            {
                Console.WriteLine("三角形不合法，将构造111的等边三角形");
                this.a=1;
                this.b=1;
                this.c=1;
            }
            else
            {
                this.a=a;
                this.b=b;
                this.c=c;
            }
        }

        public void getA() { Console.WriteLine("a"+a); }
        public void getB() { Console.WriteLine("b"+b); }
        public void getC() { Console.WriteLine("c"+c); }
        public void getArea()
        {
            float p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("面积"+s);
        }
        public double Area() 
        {
            float p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
       }
    }

    public class Circle
    {
        public int r;
        public Circle(int r)
        {
            if(r>0)
                this.r=r;
            else
            {
                Console.WriteLine("圆不合法，将构造半径为一的圆");
                r=1;
            }
        }
        public void getR() { Console.WriteLine("半径"+r); }
        public void getArea() 
        {
            double s = 3.14*r*r;
            Console.WriteLine(); 
        }
        public double Area()
        {
            double s = 3.14*r*r;
            return s;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            double AllArea=0;
            double s = 0;
            for(int x = 1; x<=10; x++)
            {
                int A = r.Next(1, 4);
                switch (A)
                {
                    case 1:
                        int length = r.Next();
                        int width = r.Next();
                        Rectangle t1 = new Rectangle(length, width);
                        t1.getLength();
                        t1.getWidth();
                        t1.getArea();
                        s=t1.Area();
                        AllArea+=s;
                        return;
                    case 2:
                        int bian = r.Next();
                        Square s1 = new Square(bian);
                        s1.getLength();
                        s1.getArea();
                        s=s1.Area();
                        AllArea+=s;
                        return;
                    case 3:
                        int a = r.Next();
                        int b = r.Next();
                        int c = r.Next();
                        Triangle t2 = new Triangle(a, b, c);
                        t2.getA();
                        t2.getB();
                        t2.getC();
                        t2.getArea();
                        s=t2.Area();
                        AllArea+=s;
                        return;
                    case 4:
                        int r1 = r.Next();
                        Circle c1 = new Circle(r1);
                        c1.getR();
                        c1.getArea();
                        s=c1.Area();
                        AllArea +=s;
                        return;
                }
            }
            Console.WriteLine("总面积"+AllArea);
            System.Console.ReadKey();
        }
    }
}
