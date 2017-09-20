using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Задание2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int[] m = new int[100];
            int[] k = new int[100];
            int[,] a = new int[100, 100];

            bool success = true;

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());

                if (n >= 1 && n <= 100)
                {
                    for (int i = 0; i < n; i++)
                    {
                        var arr = sr.ReadLine().Split();
                        m[i] = int.Parse(arr[0]);
                        k[i] = int.Parse(arr[1]);

                        if (m[i] < 0 || m[i] > 100 ||
                            k[i] < 0 || k[i] > 100)
                        {
                            success = false;
                            break;
                        }
                    }
                }
                else
                {
                    success = false;
                }
            }

            if (!success)
            {
                Console.WriteLine("Неверные входные данные");

                Console.ReadLine();
                return;
            }

            int j, min, mi;

            for (int l = 1; l <= n - 1; l++)
            {
                for (int i = 1; i <= n - l; i++)
                {
                    j = i + l;
                    min = a[i, j - 1];

                    for (int l1 = i + 1; l1 <= j - 1; l1++)
                    {
                        mi = a[i - 1, l1 - 1] + a[l1, j - 1];
                        if (mi < min)
                            min = mi;
                    }

                    a[i - 1, j - 1] = min + m[i - 1] * k[j - 1];
                }
            }

            File.WriteAllText("output.txt", a[0, n - 1].ToString());
        }
    }
}
