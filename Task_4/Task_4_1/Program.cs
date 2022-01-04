using System;

namespace Task_4_1
{
    class Program
    {
        static void Main()
        {
            try
            {
                string[] stringDiagonal1 = { "a", "ab", "abc", "abcd", "abcde" };
                DiagonalMatrix<string> stringMatrix1 = new(5, stringDiagonal1);
                Console.WriteLine($"matrix1:\n {stringMatrix1}");

                MatrixTracker<string> tracker = new(stringMatrix1);

                Console.WriteLine($"\nmatrix1 [2, 2]: {stringMatrix1[2, 2]}");
                Console.WriteLine($"matrix1 [3, 2]: {stringMatrix1[3, 2]}");

                stringMatrix1[2, 2] = "meow";
                Console.WriteLine($"matrix1 changed:\n {stringMatrix1}");

                tracker.Undo();
                Console.WriteLine($"undo:\n{stringMatrix1}");

                string[] stringDiagonal2 = { "edcba", "edcb", "edc", "ed", "e" };
                DiagonalMatrix<string> stringMatrix2 = new(5, stringDiagonal2);
                Console.WriteLine($"\nmatrix2:\n {stringMatrix2}");

                DiagonalMatrix<string> stringMatrixSum = stringMatrix1.Add<string>(stringMatrix2, StringSum);
                Console.WriteLine($"their sum:\n {stringMatrixSum}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string StringSum(string a, string b)
        {
            return a + b;
        }
    }
}
