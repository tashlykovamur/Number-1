using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//формула для нахождения расстояния между точками на сфере
//http://gis-lab.info/qa/great-circles.html
namespace Задание_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r, x1, y1, x2, y2;

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                r = double.Parse(sr.ReadLine());

                var arr = sr.ReadLine().Split();
                x1 = double.Parse(arr[0]);
                y1 = double.Parse(arr[1]);

                arr = sr.ReadLine().Split();
                x2 = double.Parse(arr[0]);
                y2 = double.Parse(arr[1]);
            }

            if (r < 100 || r > 10000 ||
                x1 > 90 || x1 < -90 ||
                x2 > 90 || x2 < -90 ||
                y1 > 180 || y1 < -180 ||
                y2 > 180 || y2 < -180)
            {
                Console.WriteLine("Неверный входные данные");

                Console.ReadLine();
                return;
            }

            convert(ref x1);
            convert(ref y1);
            convert(ref x2);
            convert(ref y2);

            double res = r * Math.Acos(Math.Sin(x1) * Math.Sin(x2) + Math.Cos(x1) * Math.Cos(x2) * Math.Cos(y1 - y2));

            File.WriteAllText("output.txt", Math.Round(res, 2).ToString());
        }

        static void convert(ref double coord)
        {
            //Чтобы получить радиальную меру угла необходимо градусную меру умножить на коорд.
            double grad = Math.PI / 180;

            coord *= grad;
        }
    }
}

