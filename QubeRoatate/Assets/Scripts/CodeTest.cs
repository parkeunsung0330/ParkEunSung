using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Cube
{
    public class CodeTest : MonoBehaviour
    {

        //char ch = 'a';
        //bool isFlag = false;
        //int a = 10;
        //int b = 20;
        //byte bt = 12;            

        //object obj = 123;
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //int width = 30;
            //int height = 30;

            //int area = (width * height) * 2;

            //Debug.Log($"가로 : {width}, 세로 : {height} 의 사각형 넓이는 {area} 입니다."); // 따옴표 안에 변수 포멧팅 하는법 : $"{변수}" <- 따옴표 앞(밖)에 달라($)표시 후 변수에 괄호{} 넣기.

            //홀짝

            //int input = 12423;

            //if(input % 2 == 0)
            //{
            //    Debug.Log($"{input}은 홀수");
            //}
            //else
            //{
            //    Debug.Log($"{input}은 짝수");
            //}

            //세금 계산 10000원 이하 = 8%, 100000원이하 10%, 1000000원 이하 15%, 나머지 20%
            //int input = 1200000;
            //float tax = 0;
            //switch(input)
            //{
            //    case <= 10000:
            //        tax = input * 0.08f;
            //        break;
            //    case <= 100000:
            //        tax = input * 0.1f;
            //        break;
            //    case < 1000000:
            //        tax = input * 0.15f;
            //        break;
            //    default:
            //        tax = input * 0.2f;
            //        break;
            //}

            //    Debug.Log($"{input} 의 세금은 {tax} 입니다.");


            // for문
            //int i;

            //for(int i=0;i<10;i++)
            //{
            //    Debug.Log(i);
            //}
            //Debug.Log(i);

            //while문

            //int i = 0;

            //while(i < 10)
            //{
            //    Debug.LogWarning(i);
            //    i++;

            //}


            //string str = "apple";

            //foreach(char c in str )
            //{

            //    Debug.Log( c ); 


            //}


            //int[] ints = { 12 , 1423 , 3452 , 21 , 5 , 7 };
            //int len = 5;
            //int sum = 0;
            //int[] ints = new int[len];

            //ints[0] = 12;
            //ints[1] = 13;
            //ints[2] = 14;
            //ints[3] = 15;
            //ints[4] = 16;

            //for (int i = 0; i < len; i++)
            //{
            //    sum += ints[i];

            //}

            //Debug.Log(sum/len);

            //string[,] strs = { { "c#","C++","C"} ,{ "JAVA", "PYTHON","PHP" },{"JS","TS","GO" } };

            //Debug.Log(strs[2,2]);

            //int col = 3; //열
            //int row = 3; //행

            //string[,] strs = new string[row, col];


            //strs[0, 0] = "C#";
            //strs[0, 1] = "C++";
            //strs[0, 2] = "C";
            //strs[1, 0] = "JAVA";
            //strs[1, 1] = "PYTHON";
            //strs[1, 2] = "PHP";
            //strs[2, 0] = "JS";
            //strs[2, 1] = "TS";
            //strs[2, 2] = "GO";

            //for (int i = 0; i < strs.GetLength(0); i++)
            //{
            //    for (int j = 0; j < strs.GetLength(1); j++)
            //    {
            //        Debug.Log(strs[i, j]);
            //    }
            //}


            //int[] ints = { 12, 1423, 3452, 21, 5, 7 };

            //Array.Sort(ints);
            //Array.Reverse(ints);

            //Debug.Log(ints.Max());

            //foreach(int i in ints)
            //{
            //    Debug.Log(i);
            //}


































        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
