using System;

namespace sudoku_solver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] numberGrid = new int[,]
            {
                { 0, 0, 6, 5, 0, 8, 4, 0, 0 },
                { 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
                { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                { 0, 0, 0, 0, 9, 0, 6, 0, 0 },
                { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            int N = numberGrid.GetLength(0);
            Console.WriteLine($"N = {N}");

            Components components = new Components();

            if (components.SolveSudoku(numberGrid, N))
            {
                Console.WriteLine("Solved!");
            }
            else
            {
                Console.WriteLine("No Solution");
            }

        }
    }
}
