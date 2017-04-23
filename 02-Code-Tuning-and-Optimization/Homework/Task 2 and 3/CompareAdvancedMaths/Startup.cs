using System;

namespace CompareAdvancedMaths
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("=== Square root ===");
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Sqrt());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Sqrt());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Sqrt());

            Console.WriteLine();

            Console.WriteLine("=== Natural logarithm ===");
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Log());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Log());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Log());

            Console.WriteLine();

            Console.WriteLine("=== Sinus ===");
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Sinus());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Sinus());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Sinus());
        }
    }
}
