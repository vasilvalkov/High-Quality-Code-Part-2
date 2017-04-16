using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("The collection should contain elements!");
        }

        if (startIndex < 0 || arr.Length <= startIndex)
        {
            throw new ArgumentException("The start index of the subsequence is outside of the boundaries of the collection!");
        }

        if (count < 0 || arr.Length < count)
        {
            throw new ArgumentException("The subsequence elements count cannot be negative nor greater than the count of the elements in the collection!");
        }

        int subsequenceElementsCount = count;
        if (startIndex + count >= arr.Length)
        {
            subsequenceElementsCount = arr.Length - startIndex;
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + subsequenceElementsCount; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentException("The provided string is null or whitespace!");
        }

        int endingLength = 0;
        if (0 <= count && count <= str.Length)
        {
            endingLength = count;
        }
        else if (count > str.Length)
        {
            endingLength = str.Length;
        }
        else
        {
            endingLength = 0;
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - endingLength; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number < 2)
        {
            throw new ArgumentException("Numbers less than 2 are not prime");
        }

        double sqrt = Math.Sqrt(number);
        for (int divisor = 2; divisor <= sqrt; divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        bool isPrime = CheckPrime(23);
        Console.WriteLine("{0} {1} prime.", 23, (isPrime ? "is" : "is not"));

        isPrime = CheckPrime(33);
        Console.WriteLine("{0} {1} prime.", 33, (isPrime ? "is" : "is not"));
        
        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
