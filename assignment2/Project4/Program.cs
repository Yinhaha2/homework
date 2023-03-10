using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal class Program
    {
        static bool Judge(int N,int M, int[][]a) 
        {
            bool judge = false;
            for (int x = 0; x<=N-1; x++)
            {
                 int tmp = a[0][x];  
                 for(int y = 0; y<=M-1; y++) 
                {
                    for (int x1 = x; x1<=N - 1; x1++)
                    { 
                        if (a[y][x1]!=tmp) 
                        { 
                            judge=false;
                            break;
                        }
                        break;
                    }
                    break;
                }
                break;
             }
            for (int x = 0; x<=M - 1; x++)
            {
                int tmp = a[x][0];
                for (int y = 0; y<=N - 1; y++)
                {
                    for (int x1 = x; x1<=M - 1; x1++)
                    {
                        if (a[x1][y]!=tmp)
                        { 
                            judge=false; 
                            break;
                        }
                        break;
                    }
                    break;
                }
                break;
            }
            return judge;   
        }
        static void Main(string[] args)
        {
            int[][] a =new int[][]{ new int[]{ 1, 2, 3, 4 }, new int[]{ 5, 1, 2, 3 }, new int[]{ 9, 5, 1, 2 } };
            int N = 4;
            int M = 3;
            bool result=Judge(N, M, a);
            Console.WriteLine(  result);
            Console.ReadLine();
        }
    }
}
