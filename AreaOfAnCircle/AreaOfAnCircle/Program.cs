using System;

namespace AreaOfAnCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            int r;
            double A;
            Console.WriteLine("Skriv in radien av circlen:");
            r = Convert.ToInt32(Console.ReadLine());
            A = (3.14) * r * r;
            Console.WriteLine("Arean av cirkel är=" + A);
            Console.ReadLine();
        }
    }
}
