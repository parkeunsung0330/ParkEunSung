using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Basic
{
    internal class Program
    {
        //static int a = 10;
        //const float Pi = 3.141592f;
        static void Main(string[] args)
        {




            //int[] ints = { 12345, 124, 5125261, 4, 905, 5270, 1235 };
            //Array.Sort(ints);
            //Array.Reverse(ints);
            //foreach (int i in ints)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine($"총합은 : {ints.Sum()}");
            //Console.WriteLine($"평균은 : {ints.Average()}");
            //Console.WriteLine($"최댓값은 : {ints.Max()}");
            //Console.WriteLine($"1235의 인덱스는 : {Array.IndexOf(ints, 1235)}");




            //Console.WriteLine(Array.Sort(ints));
            //    string[,] strs = new string[3, 3];

            //    strs[0, 0] = "C#";
            //    strs[0, 1] = "JAVA";
            //    strs[0, 2] = "C++";
            //    strs[1, 0] = "C";
            //    strs[1, 1] = "VB.NET";
            //    strs[1, 2] = "C#.NET";
            //    strs[2, 0] = "XML";
            //    strs[2, 1] = "HTML";
            //    strs[2, 2] = "SQL";

            //    for(int i = 0; i < 3; i++)
            //    {
            //        for(int j=0; j < 3; j++)
            //        {
            //            Console.Write($"{strs[i,j]} ");
            //        }
            //        Console.WriteLine();
            //    }

            //foreach (string str in strs)
            //{
            //    Console.Write($"{str} ");
            //} 


            //string[] books = { "C#", "JAVA", "VB.NET", "C++", "C" };

            //Console.WriteLine(books.Length);
            //foreach (string s in books)
            //{
            //    Console.Write($"{s}. ");
            //}

            //int[] ints = new int[5];
            //ints[0] = 1;
            //ints[1] = 2;
            //ints[2] = 3;
            //ints[3] = 4;
            //ints[4] = 5;

            //int[] ints = { 1, 2, 3, 4, 5 };
            //ints[2] = 100;
            //Console.WriteLine(ints[2]);

            //foreach (int i in ints)
            //{
            //    Console.WriteLine(i);
            //}

            //int i = int.Parse(Console.ReadLine());
            //int rows = 5; // 행
            //int cols = 9; // 열
            //int mid = cols / 2;

            //for (int i = 0; i < rows; i++)
            //{
            //    for(int j = 0; j <  cols; j++)
            //    {
            //        if (Math.Abs(j - mid) <= i)
            //        {
            //            Console.Write(i+1-Math.Abs(j-mid));
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = rows-2; i>=0; i--)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        if (Math.Abs(j - mid) <= i)
            //        {
            //            Console.Write(i + 1 - Math.Abs(j - mid));
            //            //Console.Write("*");
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //switch (i)
            //{
            //    case 10:
            //        Console.WriteLine("같아요");
            //        break;
            //    default:
            //        Console.WriteLine("다르다");
            //        break;
            //}





            //int i = int.Parse(Console.ReadLine());

            //if (i % 2 == 0)
            //{
            //    Console.WriteLine("짝수");
            //}
            //else
            //{
            //    Console.WriteLine("홀수");
            //}



            //sbyte sb = -128;
            //byte by = 255;
            //short sht = 32767;
            //ushort usht = 65535;

            //char ch = 'a';
            //string str = "apple";

            //Console.WriteLine(str);

            //Console.Write(str);

            //object obj = new object();


            //Console.WriteLine(a);
            //a = 100;
            //Console.WriteLine(a);
            //Console.WriteLine(Pi);

            Console.WriteLine(Sub(10,5));
            Console.WriteLine(Div(5,0));
            Phyramid(7, 4);
            Phyramid(9, 5);
            Phyramid(11, 6);


            Console.ReadKey();
        }

        private static int Sub(int x, int y)
        {
            return x - y;
        }

        private static float Div(float x, float y)
        {
            return x / y;
        }

        private static void Phyramid(int cols, int rows)
        {
            int mid = cols / 2;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(j - mid) <= i)
                    {
                        Console.Write(i + 1 - Math.Abs(j - mid));
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            for (int i = rows - 2; i >= 0; i--)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(j - mid) <= i)
                    {
                        Console.Write(i + 1 - Math.Abs(j - mid));
                        //Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
