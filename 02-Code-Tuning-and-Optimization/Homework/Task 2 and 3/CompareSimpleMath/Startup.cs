using System;

namespace CompareSimpleMath
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("=== Adding ===");
            Console.WriteLine("{0,-10} - {1}", "int", IntComparer.Add());
            Console.WriteLine("{0,-10} - {1}", "long", LongComparer.Add());
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Add());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Add());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Add());

            Console.WriteLine();

            Console.WriteLine("=== Subtracting ===");
            Console.WriteLine("{0,-10} - {1}", "int", IntComparer.Subtract());
            Console.WriteLine("{0,-10} - {1}", "long", LongComparer.Subtract());
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Subtract());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Subtract());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Subtract());

            Console.WriteLine();

            Console.WriteLine("=== Incrementing ===");
            Console.WriteLine("{0,-10} - {1}", "int", IntComparer.Increment());
            Console.WriteLine("{0,-10} - {1}", "long", LongComparer.Increment());
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Increment());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Increment());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Increment());

            Console.WriteLine();

            Console.WriteLine("=== Multiplying ===");
            Console.WriteLine("{0,-10} - {1}", "int", IntComparer.Multiply());
            Console.WriteLine("{0,-10} - {1}", "long", LongComparer.Multiply());
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Multiply());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Multiply());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Multiply());

            Console.WriteLine();

            Console.WriteLine("=== Dividing ===");
            Console.WriteLine("{0,-10} - {1}", "int", IntComparer.Divide());
            Console.WriteLine("{0,-10} - {1}", "long", LongComparer.Divide());
            Console.WriteLine("{0,-10} - {1}", "float", FloatComparer.Divide());
            Console.WriteLine("{0,-10} - {1}", "double", DoubleComparer.Divide());
            Console.WriteLine("{0,-10} - {1}", "decimal", DecimalComparer.Divide());
        }
    }
}
