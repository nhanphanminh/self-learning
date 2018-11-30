using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public partial class Solution
    {
        //Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

        //    Note: You can only move either down or right at any point in time.
        //    Example :

        //Input : 

        //[  1 3 2
        //   4 3 1
        //   5 6 1
        //]

        //Output : 8
        //1 -> 3 -> 2 -> 1 -> 1

        private int[] x = { 0, 1 };
        private int[] y = { 1, 0 };

        private void TralvelSum(int[][] A, int i, int j, int M, int N, int total, ICollection<int> result, ref int min)
        {
            if (i == M - 1 && j == N - 1)
            {
                if (min > total)
                {
                    min = total;
                }

                result.Add(min);

                return;
            }

            for (var index = 0; index <= 1; index++)
            {
                var I = i + x[index];
                var J = j + y[index];

                if (I >= M || J >= N)
                {
                    continue;
                }

                var tmp = total + A[I][J];

                if (tmp >= min)
                {
                    continue;
                }

                TralvelSum(A, I, J, M, N, tmp, result, ref min);
            }

        }

        public int minPathSum(List<List<int>> A)
        {
            if (!A.Any() || !A[0].Any())
            {
                return 0;
            }

            var M = A.Count;
            var N = A[0].Count;
            var min = int.MaxValue;
            var result = new List<int>();
            int[][] array = A.Select(list => list.ToArray()).ToArray();
            TralvelSum(array, 0, 0, M, N, array[0][0], result, ref min);
            return min;
        }

        // Largest area of rectangle with permutations

        public int solve(List<List<int>> A)
        {
            return 0;
        }

        //Given A, how many structurally unique BST’s(binary search trees) that store values 1...A?

        //    Example :

        //Given A = 3, there are a total of 5 unique BST’s.
        public int numTrees(int A)
        {
            if (A <= 1)
            {
                return 1;
            }

            if (A == 2)
            {
                return 2;
            }

            var rs = 0;
            for (int i = 1; i <= A; i++)
            {
                var left = i - 1;
                var right = A - i;
                rs += (numTrees(left) * numTrees(right));
            }

            return rs;
        }

        //Say you have an array for which the ith element is the price of a given stock on day i.

        //    If you were only permitted to complete at most one transaction(ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.

        //    Example :

        //Input : [1 2]
        //Return :  1 
        public int ComparisonMethod(int x, int y, int i, int j)
        {
            if (i >= j)
                return 1;

            return y.CompareTo(x);
        }

        public int maxProfit(List<int> A)
        {
            int[] prices = A.ToArray();
            int maxProfit = 0;
            int minsoFar = int.MaxValue;

            foreach (int i in prices)
            {
                maxProfit = Math.Max(maxProfit, i - minsoFar);
                minsoFar = Math.Min(i, minsoFar);
            }

            return maxProfit;
        }


        //Given a number N, return number of ways you can draw N chords in a circle with 2*N points such that no 2 chords intersect.
        //    Two ways are different if there exists a chord which is present in one way and not in other.

        //    For example,

        //    N= 2
        //If points are numbered 1 to 4 in clockwise direction, then different ways to draw chords are:
        //{ (1 - 2), (3 - 4)}
        //and {(1-4), (2-3)}

        //So, we return 2.
        //Notes:

        //1 ≤ N ≤ 1000
        //Return answer modulo 109+7.
        public int chordCnt(int A)
        {
            var mod = 1000000007;
            if (A <= 1) return A;
            var cache = new long[A + 1];
            cache[0] = 1;
            cache[1] = 1;
            for (var i = 2; i <= A; i++)
            {
                var sum = 0L;

                for (var j = 0; j < i; j++)
                {
                    sum = (sum + (cache[j] * cache[i - j - 1]) % mod) % mod;
                }

                cache[i] = sum;
            }
            return (int)cache[A];
        }

        //Given a binary grid i.e.a 2D grid only consisting of 0’s and 1’s, find the area of the largest rectangle inside the grid such that all the cells inside the chosen rectangle should have 1 in them.You are allowed to permutate the columns matrix i.e.you can arrange each of the column in any order in the final grid.Please follow the below example for more clarity.

        //    Lets say we are given a binary grid of 3 * 3 size.

        //1 0 1

        //0 1 0

        //1 0 0


        //At present we can see that max rectangle satisfying the criteria mentioned in the problem is of 1 * 1 = 1 area i.e either of the 4 cells which contain 1 in it.Now since we are allowed to permutate the columns of the given matrix, we can take column 1 and column 3 and make them neighbours. One of the possible configuration of the grid can be:

        //1 1 0

        //0 0 1

        //1 0 0


        //Now In this grid, first column is column 1, second column is column 3 and third column is column 2 from the original given grid.Now, we can see that if we calculate the max area rectangle, we get max area as 1 * 2 = 2 which is bigger than the earlier case. Hence 2 will be the answer in this case.
        public int solve_MaxRectangle(List<List<int>> A)
        {

            int row = A.Count;
            int col = A[0].Count;

            int[,] arr = new int[row, col];

            for (int i = 1; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (A[i][j] == 1)
                        A[i][j] = A[i - 1][j] + 1;
                }
            }
            int globalMax = 0;

            for (int i = 0; i < row; i++)
            {

                A[i].Sort();
                int max = A[i][0];
                int min = A[i][0];
                for (int j = col - 1; j >= 0; j--)
                {
                    if (A[i][j] == 0)
                        break;
                    if (A[i][j] > max)
                    {
                        max = A[i][j];
                    }
                    if (max < A[i][j] * (col - j))
                        max = A[i][j] * (col - j);
                }
                if (max > globalMax)
                    globalMax = max;
            }
            return globalMax;
        }
    }
}





