using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dovator6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер матрицы -> ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int[] buf = new int[n];
            Random rand = new Random();
            int flag = 0;
            int s = 0;

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++)
                {
                    matrix[j, i] = rand.Next(-30, 99);
                    if (matrix[j, i] > 0) flag++;
                    s += matrix[j, i];
                    if ((j == n - 1) && (flag == n)) buf[i] = s;
                }
                flag = 0;
                s = 0;
            }

            int min = int.MaxValue;
            int sum = 0;
            int k = 0;
            int[] buf2 = new int[2*n];
            for (int z = n - 1; z >= - n; z--) {
                sum = 0;
                for (int j = 0; j < n; j++)
                    if ((j - z > 0) && (j - z <= n)) sum = sum + Math.Abs(matrix[j - z - 1, n - j - 1]);
                buf2[k] = sum;
                k++;
            }
            for (k = 0; k < 2 * n - 1; k++) buf2[k] = buf2[k + 1];
            Array.Resize(ref buf2, 2 * n - 1);
            for (k = 0; k < 2 * n - 1; k++) if (buf2[k] < min) min = buf2[k];


            //вывод матрицы
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    Console.Write("{0,5:d}", matrix[i, j]);
                }
                if (i == n - 1) Console.Write("\n"); else Console.Write("\n\n");
            }

            //вывод стрелочек
            for (int i = 0; i < n; i++) {
                Console.Write("{0,5}", "↓");
            }

            //вывод сумм или 0, если в столбце есть отр. элементы
            Console.Write("\n");
            for (int i = 0; i < n; i++) {
                Console.Write("{0,5:d}", buf[i]);
            }

            //вывод минимума
            Console.Write("\n\n");
            Console.Write("Минимум среди сумм модулей элементов диагоналей параллельных побочной = ");
            Console.Write("{0:d}", min);
            Console.ReadKey();
        }
    }
}
