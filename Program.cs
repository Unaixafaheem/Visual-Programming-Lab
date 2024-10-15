using System;
using System.Linq;

public class Program
{
    public static void Print2DArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static string Merger(string[] s)
    {
        return string.Concat(s);
    }

    public static string[] ExtractWords(string input)
    {
        string[] words = input.Split(' ');
        return words.Where(w => w.Length >= 4 && w.Length <= 8 && w.Any(c => "aeiouAEIOU".Contains(c))).ToArray();
    }

    public static int[] SummarizeRatings(int[] ratings)
    {
        int[] summary = new int[5];
        foreach (var rating in ratings)
        {
            summary[rating - 1]++;
        }
        return summary;
    }

    public static string DecimalToBinary(int decimalNumber)
    {
        return Convert.ToString(decimalNumber, 2);
    }

    public static int BinaryToDecimal(string binaryNumber)
    {
        return Convert.ToInt32(binaryNumber, 2);
    }

    public static void PrintRectangularArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int colsB = matrixB.GetLength(1);

        int[,] result = new int[rowsA, colsA];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < colsA; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return result;
    }

    public static void Main()
    {
        // Print 2D Array
        int[,] myArray = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        Print2DArray(myArray);
        Console.WriteLine();

        // Merger method
        string[] s = { "hello ", "and ", "welcome ", "to ", "this ", "demo " };
        Console.WriteLine(Merger(s));
        Console.WriteLine();

        // Extract words method
        string text = "hello and welcome to this demo where we will extract words";
        string[] extractedWords = ExtractWords(text);
        Console.WriteLine(string.Join(", ", extractedWords));
        Console.WriteLine();

        // Summarize ratings
        int[] ratings = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5 };
        int[] summarizedRatings = SummarizeRatings(ratings);
        for (int i = 0; i < summarizedRatings.Length; i++)
        {
            Console.WriteLine($"Response {i + 1} given by: {summarizedRatings[i]} people");
        }
        Console.WriteLine();

        // Decimal to binary and vice versa
        int decimalNumber = 42;
        string binary = DecimalToBinary(decimalNumber);
        Console.WriteLine($"Decimal: {decimalNumber} to Binary: {binary}");
        int decimalConverted = BinaryToDecimal(binary);
        Console.WriteLine($"Binary: {binary} to Decimal: {decimalConverted}");
        Console.WriteLine();

        // Rectangular array
        int[,] testMarks = {
            {92, 73, 86, 71, 97, 93, 75, 93, 99, 97},
            {90, 86, 86, 81, 78, 78, 90, 88, 72, 88},
            {99, 97, 89, 100, 99, 100, 79, 78, 77, 91},
            {79, 95, 79, 78, 78, 88, 88, 90, 88, 97},
            {72, 82, 86, 97, 100, 88, 86, 88, 89, 97}
        };
        PrintRectangularArray(testMarks);
        Console.WriteLine();

        // Matrix multiplication
        int[,] matrixA = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        int[,] matrixB = {
            {1, 2, 1},
            {0, 1, 0},
            {2, 3, 4}
        };
        int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);
        Print2DArray(resultMatrix);
    }
}

