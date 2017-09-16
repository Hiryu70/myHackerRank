// https://www.hackerrank.com/challenges/flipping-the-matrix

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution 
{
    static void Main(String[] args) 
    {
        // Переменная Integer для хранения количества матриц
        int matrixMax = Convert.ToInt32(Console.ReadLine());
        // Массив Integer для хранения результатов по каждой матрице
        int[] result = new int[matrixMax];
        // Цикл по матрицам
        for (int matrixCnt = 0; matrixCnt < matrixMax; matrixCnt++)
        {
            // Переменная для хранения размерности квадранта текущей матрицы
            int n = Convert.ToInt32(Console.ReadLine());
            // Массив массивов для хранения значения текущей матрицы
            int[][] arr = new int[2*n][];
            // Цикл считывания текущей матрицы
            for (int nCnt = 0; nCnt < 2*n; nCnt++)
            {
                // Считываем значения из консоли, тип String, записываем в массив разделитель - пробел
                string[] arrTemp = Console.ReadLine().Split(' ');
                // Преобразуем String в Integer
                arr[nCnt] = Array.ConvertAll(arrTemp,Int32.Parse);
            }
            // Двумя вложенными циклами обходим верхний левый квадрант текущей матрицы
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    // Для текущчего верхнего левого хначения находим соответствующее зеркальное значение в каждом квадранте
                    int leftTopValue =      arr[i]              [j];
                    int leftBottomValue =   arr[2 * n - i - 1]  [j];
                    int rightTopValue =     arr[i]              [2 * n - j - 1];
                    int rightBottomValue =  arr[2 * n - i - 1]  [2 * n - j - 1];
                    // Находим максимальное и аккумулируем значение 
                    result[matrixCnt] = result[matrixCnt] + Max(leftTopValue,leftBottomValue,rightTopValue,rightBottomValue);
                }
            }
            // Выводим результат в консоль
            Console.WriteLine(result[matrixCnt]);
        }
    }

    // Метод для нахождения максимального значения из четырех
    public static int Max(int w, int x, int y, int z)
    {
        return Math.Max(w, Math.Max(x, Math.Max(y, z)));
    }
}
