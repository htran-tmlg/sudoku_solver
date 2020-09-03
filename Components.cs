using System;
using System.Collections.Generic;
using System.Text;

namespace sudoku_solver
{
    class Components
    {
        private readonly int unassigned = 0;


        private bool CheckSafeRow(int[,] board, int num, int col)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                if (num == board[x, col])
                {
                    return false;
                };
            }
            return true;
        }


        private bool CheckSafeCol(int[,] board, int num, int row)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (num == board[row, y])
                {
                    return false;
                };
            }
            return true;
        }
        

        private bool CheckSafeSubgrid(int[,] board, int num, int row, int col)
        {
            // Locate the fixed region that corresponds with the number
            int sqrt = (int)Math.Sqrt(board.GetLength(0));
            int regionRowStart = row - row % sqrt;
            int regionRowEnd = regionRowStart + sqrt;
            int regionColStart = col - col % sqrt;
            int regionColEnd = regionColStart + sqrt;

            for (int r = regionRowStart; r < regionRowEnd; r++)
            {
                for (int c = regionColStart; c < regionColEnd; c++)
                {
                    if (num == board[r, c])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private bool IsSafe(int[,] board, int num, int row, int col)
        {
            bool isSafeRow = CheckSafeRow(board, num, col);
            bool isSafeCol = CheckSafeCol(board, num, row);
            bool isSafeBox = CheckSafeSubgrid(board, num, row, col);

            if (isSafeRow == false || isSafeCol == false || isSafeBox == false)
            {
                return false;
            }
            else
            {
                return true;
            };
        }


        public bool SolveSudoku(int[,] board, int n)
        {
            // Locate the earliest unassigned cell. If found none, exit. Else, start at that cell.
            int row = 0;
            int col = 0;
            bool isUnassigned = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i, j] == unassigned)
                    {
                        isUnassigned = true;
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (isUnassigned)
                {
                    break;
                }
            }
            
            // If no more unassigned cell, exit
            if (!isUnassigned)
            {
                return true;
            }

            // row-wise backtrack
            for (int num = 1; num <= n; num++)
            {
                if (IsSafe(board, num, row, col))
                {
                    board[row, col] = num;
                    PrintBoard(board, n);
                    Console.WriteLine(" ");

                    if (SolveSudoku(board, n))
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = unassigned;
                    }
                }
            }
            return false;
        }



        public void PrintBoard(int[,] board, int N)
        {
            for (int d = 0; d < N; d++)
            {
                Console.Write("----");
            }
            Console.Write("\n");

            for (int r = 0; r < N; r++)
            {
                for (int d = 0; d < N; d++)
                {
                    Console.Write(board[r, d]);
                    Console.Write(" | ");
                }
                Console.Write("\n");

                for (int d = 0; d < N; d++)
                {
                    Console.Write("----");
                }
                Console.Write("\n");
            }
        }
    }
}
