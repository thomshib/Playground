using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Sudoku
{
    //https://medium.com/@george.seif94/solving-sudoku-using-a-simple-search-algorithm-3ac44857fee8
    public class Sudoku
    {

        int[,] board;

        public Sudoku()
        {
            board = new int[9, 9]
            {
                { 3, 0, 6, 5, 0, 8, 4, 0, 0},
                { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
               };

        }

        public void PrintBoard()
        {
            int N = board.GetLength(0);
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Console.Write(board[row, col] + " ");

                }
                Console.WriteLine();
            }
        }

        public bool Is_Safe(int row, int col, int value)
        {
            int N = board.GetLength(0);


            //Rule 1. row has unique values

            //Rule 2. col has unique values

            //Rule 3. Every 3x3 square should have unique values

            return !used_in_row(row, N, value) &&
                !used_in_col(col, N, value) &&
                !used_in_box(row, col, N, value);
        }

        private bool used_in_box(int row, int col, int n, int value)
        {
            int maxBoxDim = (int)Math.Sqrt(n);

            int rowStartDim = row - row % maxBoxDim;
            int rowEndDim = rowStartDim + maxBoxDim;

            int colStartDim = col - col % maxBoxDim;
            int colEndDim = colStartDim + maxBoxDim;

            for (int r = rowStartDim; r < rowEndDim; r++)
            {
                for (int c = colStartDim; c < colEndDim; c++)
                {
                    if (board[r, c] == value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool used_in_col(int col, int n, int value)
        {
            for (int index = 0; index < n; index++)
            {
                if (board[index, col] == value)
                {
                    return true;
                }
            }

            return false;
        }

        private bool used_in_row(int row, int n, int value)
        {
            for (int index = 0; index < n; index++)
            {
                if (board[row, index] == value)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Tuple<int, int>> GetUnassignedLocations()
        {
            List<Tuple<int, int>> locations = new List<Tuple<int, int>>();
            int N = board.GetLength(0);
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    if (board[row, col] == 0)
                    {
                        Tuple<int, int> pair = new Tuple<int, int>(row, col);
                        locations.Add(pair);
                    }

                }

            }

            return locations;

        }
        public bool SolveSudoku()
        {
            List<Tuple<int, int>> locations = GetUnassignedLocations();
            if (locations.Count == 0)
            {
                return true;
            }

            // Get an unassigned location

            int row = locations[0].Item1;
            int col = locations[0].Item2;

            //consider digits from 1 to 9
            for (int num = 1; num <= 9; num++)
            {
                if (Is_Safe(row, col, num))
                {
                    board[row, col] = num;


                    //recursively see if we solved recursively
                    if (SolveSudoku())
                    {
                        return true;
                    }

                    //if we reach here, then we did not solve it 
                    //reset the value
                    board[row, col] = 0;
                }
            }

            return false;
        }
    }
}

