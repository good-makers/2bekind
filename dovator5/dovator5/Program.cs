using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dovator5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число элементов массива -> ");
            int n = int.Parse(Console.ReadLine());
            double[] mass = new double[n];
            Random rand = new Random();
            double max = double.MinValue;
            int k = -1;
            int maxn = 0;
            double s = 0;

            for (int i = 0; i < mass.Length; i++) {
                mass[i] = Convert.ToDouble(rand.Next(-9999,9999)) / 100;
                if (mass[i] > max) {
                    max = mass[i];
                    maxn = i;
                }
                if (mass[i] > 0) k = i;
            }

            for (int i = 0; i < k; i++) s += mass[i];

            Console.Write("\nИсходный массив -> ");
            for (int i = 0; i < mass.Length; i++) {
                Console.Write(" {0:f2} ", mass[i]);
            }
            Console.Write("\nМаксимальный элемент = {0:f2} на позиции {1:d}\n"+
                "Сумма до последнего положительного, не включая его самого = {2:f2}\n\nВведите 'a' из [a,b] -> ", max, maxn+1,s);
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите 'b' из [a,b] -> ");
            double b = double.Parse(Console.ReadLine());

            double[] buf = new double[n];
            int j = 0;
            for (int i = 0; i < mass.Length; i++) {
                if (!((Math.Abs(mass[i]) >= a) && (Math.Abs(mass[i]) <= b))) {
                    buf[j] = mass[i];
                    j++;
                }
            }
            for (; j < buf.Length; j++) buf[j] = 0;

            Console.Write("Массив после сжатия -> ");
            for (int i = 0; i < buf.Length; i++)
            {
                Console.Write(" {0:f2} ", buf[i]);
            }
            Console.ReadKey();
        }
    }
}
