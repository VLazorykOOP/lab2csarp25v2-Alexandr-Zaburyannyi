using System;
using System.Linq; // Add System.Linq for Sum() if needed, though manual loop is used

namespace Lab2CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 2 CSharp");

            Console.WriteLine("\n--- Task 1.11: Sum of squares of even elements ---");
            Console.WriteLine("Task: Calculate the sum of squares of even elements.");
            // Task 1.11: One-dimensional array
            SolveTask1_11();
            Console.WriteLine("\n------------------------------------\n");
            // Task 1.11: Two-dimensional array


            Console.WriteLine("\n--- Task 2.11: Sum between first max and first min ---");
            SolveTask2_11(); 

            Console.WriteLine("\n--- Task 3.11: Calculate matrix norm ---");
            SolveTask3_11();
            Console.WriteLine("\n------------------------------------\n");

            Console.WriteLine("\n--- Task 4.11: Product of column elements in range [k1, k2] ---");
            SolveTask4_11();
            Console.WriteLine("\n------------------------------------\n");
        }

        static void SolveTask1_11()
        {
            Console.WriteLine("Solving using a one-dimensional array:");

           
            Console.Write("Enter the size of the one-dimensional array: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the size.");
                Console.Write("Enter the size of the one-dimensional array: ");
            }

            
            int[] array = new int[size];
            Console.WriteLine($"Enter {size} integer elements for the array:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    Console.Write($"Element {i + 1}: ");
                }
            }

            
            long sumOfSquares = 0; 
            foreach (int element in array)
            {
                if (element % 2 == 0) 
                {
                    sumOfSquares += (long)element * element; 
                }
            }

            
            Console.WriteLine($"\nArray elements: [{string.Join(", ", array)}]");
            Console.WriteLine($"Sum of squares of even elements: {sumOfSquares}");
        }


        static void SolveTask2_11()
        {
            Console.WriteLine("Task 2.11: Sum elements between first max and first min.");
            Console.WriteLine("Condition: If first max appears after first min, print a message.");

            
            Console.Write("Enter the size of the one-dimensional array: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the size.");
                Console.Write("Enter the size of the one-dimensional array: ");
            }

           
            int[] array = new int[size];
            Console.WriteLine($"Enter {size} integer elements for the array:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    Console.Write($"Element {i + 1}: ");
                }
            }
            Console.WriteLine($"\nArray elements: [{string.Join(", ", array)}]");

            
            if (size <= 1) 
            {
                 Console.WriteLine("Array must have at least two elements to find distinct min and max positions.");
                 return;
            }


           
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < size; i++)
            {
                if (array[i] < minVal) minVal = array[i];
                if (array[i] > maxVal) maxVal = array[i];
            }

            
            if (minVal == maxVal)
            {
                Console.WriteLine("All elements are the same. Cannot determine order or sum between distinct min and max.");
                return;
            }

           
            int firstMinIndex = -1;
            int firstMaxIndex = -1;
            for (int i = 0; i < size; i++)
            {
                if (array[i] == minVal && firstMinIndex == -1)
                {
                    firstMinIndex = i;
                }
                if (array[i] == maxVal && firstMaxIndex == -1)
                {
                    firstMaxIndex = i;
                }
                
                if (firstMinIndex != -1 && firstMaxIndex != -1)
                {
                    break;
                }
            }

            
             if (firstMinIndex == -1 || firstMaxIndex == -1) {
                 Console.WriteLine("Internal Error: Could not find min or max index. This should not happen.");
                 return;
             }


            Console.WriteLine($"First minimum element ({minVal}) found at index: {firstMinIndex}");
            Console.WriteLine($"First maximum element ({maxVal}) found at index: {firstMaxIndex}");


           
            if (firstMaxIndex > firstMinIndex)
            {
                Console.WriteLine("Condition met: The first maximum element appears after the first minimum element.");
            }
            else 
            {
                
                long sum = 0;
                int startIndex = firstMaxIndex + 1;
                int endIndex = firstMinIndex; 

                Console.Write("Elements between first max and first min: [");
                bool isFirstElement = true; 
                for (int k = startIndex; k < endIndex; k++) 
                {
                     if (!isFirstElement)
                     {
                         Console.Write(", "); 
                     }
                     Console.Write(array[k]);
                     sum += array[k];
                     isFirstElement = false; 
                }
                 Console.WriteLine("]");


                Console.WriteLine($"Sum of elements between first max ({maxVal} at index {firstMaxIndex}) and first min ({minVal} at index {firstMinIndex}): {sum}");
            }
        }

        static void SolveTask3_11()
        {
            Console.WriteLine("\n--- Task 3.11: Calculate matrix norm based on Σᵢ maxⱼ aᵢ,ⱼ ---");

            Console.Write("Enter the number of rows: ");
            int rows;
            while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for rows.");
                Console.Write("Enter the number of rows: ");
            }

            Console.Write("Enter the number of columns: ");
            int cols;
            while (!int.TryParse(Console.ReadLine(), out cols) || cols <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for columns.");
                Console.Write("Enter the number of columns: ");
            }

            int[,] matrix = new int[rows, cols];
            Console.WriteLine("Enter the matrix elements:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Element [{i},{j}]: ");
                    while (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                        Console.Write($"Element [{i},{j}]: ");
                    }
                }
            }

            Console.WriteLine("\nEntered Matrix:");
             for (int i = 0; i < rows; i++)
             {
                 Console.Write("[");
                 for (int j = 0; j < cols; j++)
                 {
                     Console.Write($"{matrix[i, j]}");
                     if (j < cols - 1)
                     {
                         Console.Write(", ");
                     }
                 }
                 Console.WriteLine("]");
             }


            long normSum = 0;
            for (int i = 0; i < rows; i++)
            {
                if (cols > 0) 
                {
                    int maxInRow = matrix[i, 0];
                    for (int j = 1; j < cols; j++)
                    {
                        if (matrix[i, j] > maxInRow)
                        {
                            maxInRow = matrix[i, j];
                        }
                    }
                    normSum += maxInRow;
                }
            }

            Console.WriteLine($"\nThe calculated norm (Σᵢ maxⱼ aᵢ,ⱼ) is: {normSum}");
        }

        static void SolveTask4_11()
        {
            Console.WriteLine("\n--- Task 4.11: Product of column elements in range [k1, k2] ---");

            int rows;
            Console.Write("Enter the number of rows: ");
            while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for rows.");
                Console.Write("Enter the number of rows: ");
            }

            int cols;
            Console.Write("Enter the number of columns: ");
            while (!int.TryParse(Console.ReadLine(), out cols) || cols <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for columns.");
                Console.Write("Enter the number of columns: ");
            }

            int[,] matrix = new int[rows, cols];
            Console.WriteLine("Enter the matrix elements:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Element [{i},{j}]: ");
                    while (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                        Console.Write($"Element [{i},{j}]: ");
                    }
                }
            }

            Console.WriteLine("\nEntered Matrix:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("[");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                    if (j < cols - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("]");
            }

            int k1;
            Console.Write($"Enter the start row index k1 (0 to {rows - 1}): ");
            while (!int.TryParse(Console.ReadLine(), out k1) || k1 < 0 || k1 >= rows)
            {
                Console.WriteLine($"Invalid input. Please enter an integer between 0 and {rows - 1}.");
                Console.Write($"Enter the start row index k1 (0 to {rows - 1}): ");
            }

            int k2;
            Console.Write($"Enter the end row index k2 ({k1} to {rows - 1}): ");
            while (!int.TryParse(Console.ReadLine(), out k2) || k2 < k1 || k2 >= rows)
            {
                Console.WriteLine($"Invalid input. Please enter an integer between {k1} and {rows - 1}.");
                Console.Write($"Enter the end row index k2 ({k1} to {rows - 1}): ");
            }

            long[] productArray = new long[cols];
            for (int j = 0; j < cols; j++)
            {
                long product = 1;
                for (int i = k1; i <= k2; i++)
                {
                    product *= matrix[i, j];
                }
                productArray[j] = product;
            }

            Console.WriteLine($"\nProduct of elements in each column from row {k1} to {k2}:");
            Console.WriteLine($"[{string.Join(", ", productArray)}]");
        }
    }
}
