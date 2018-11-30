using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Solution
    {
        private bool checkRowOrColumn(ref Dictionary<string, int> dict, int index, int value)
        {

            var key = index.ToString() + value;

            if (dict.ContainsKey(key))
            {
                return false;
            }

            dict.Add(key, 1);
            return true;
        }

        private bool checkSquare(ref Dictionary<string, int> dict, int row, int column, int value)
        {
            var rowIndex = row / 3;
            var columnIndex = column / 3;

            var key = rowIndex.ToString() + columnIndex + value;

            if (dict.ContainsKey(key))
            {
                return false;
            }

            dict.Add(key, 1);
            return true;
        }

        public int isValidSudoku(List<string> A)
        {
            if (A.Count % 3 != 0)
                return -1;

            var dictRow = new Dictionary<string, int>();
            var dictColumn = new Dictionary<string, int>();
            var dictSquare = new Dictionary<string, int>();
            var N = A.Count;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (A[i][j] == '.')
                    {
                        continue;
                    }

                    if (!checkRowOrColumn(ref dictRow, i, A[i][j]))
                    {
                        return 0;
                    }

                    if (!checkRowOrColumn(ref dictColumn, j, A[i][j]))
                    {
                        return 0;
                    }

                    if (!checkSquare(ref dictSquare, i, j, A[i][j]))
                    {
                        return 0;
                    }
                }
            }

            return 1;
        }
    }
}





