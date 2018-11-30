using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    public partial class Solution
    {
        public long giaithua(int N)
        {
            if (N <= 1)
                return 1;

            long s = 1;
            for (int i = 2; i <= N; i++)
            {
                s *= (long)i;
            }

            return s;
        }

        public int findLessCharsUnquie(string A)
        {
            var s = new List<char>();
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] < A[0] && !s.Contains(A[i]))
                    s.Add(A[i]);
            }

            return s.Count;
        }

        private long UCLN(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                if (a < b)
                    b = b - a;
            }

            return a;
        }

        private long BCNN(long a, long b)
        {
            var uCLN = UCLN(a, b);
            return ((long)a * b) / uCLN;
        }

        private long BCNN(List<int> A)
        {
            long max = 1;

            for (int i = 0; i < A.Count; i++)
            {
                max = BCNN(max, A[i]);
            }

            return max;
        }

        private int BCNN109Plus7(List<int> A)
        {
            long max = 1;

            for (int i = 0; i < A.Count; i++)
            {
                max = BCNN(max, (long)A[i]) % 1000000007;
            }

            return (int)max;
        }

        public int cpFact(int A, int B)
        {
            while (true)
            {
                int g = (int)UCLN(A, B);

                if (g == 1)
                {
                    return A;
                }

                A = A / g;
            }
        }



        public BigInteger C(int N, int m)
        {
            return (giaithua(N) / (giaithua(N - m))) / giaithua(m);
        }

        public int Cnm(int n, int m)
        {
            // m+n-2 C n-1 = (m+n-2)! / (n-1)! (m-1)! 
            long ans = 1;
            for (int i = n; i < (m + n - 1); i++)
            {
                ans *= i;
                ans /= (i - n + 1);
            }
            return (int)ans;
        }


        public int uniquePaths(int A, int B)
        {
            var result = C(A + B - 2, B - 1);
            return (int)result;
        }

        private int[] X = new int[] { 0, 0, -1, -1, -1, +1, +1, +1 };
        private int[] Y = new int[] { -1, +1, 0, -1, +1, -1, 0, +1 };

        private int coverPoints(int x1, int y1, int x2, int y2)
        {
            var xDisctance = Math.Abs(x1 - x2);
            var yDisctance = Math.Abs(y1 - y2);
            return xDisctance > yDisctance ? xDisctance : yDisctance;
        }

        public int coverPoints(List<int> A, List<int> B)
        {
            int distance = 0;

            for (int i = 0; i < A.Count - 1; i++)
            {
                distance += coverPoints(A[i], B[i], A[i + 1], B[i + 1]);
            }

            return distance;
        }

        private List<int> removeZero(List<int> A)
        {
            while (A.Count > 0 && A[0] == 0)
            {
                A.RemoveAt(0);
            }

            return A;
        }

        public List<int> plusOne(List<int> A)
        {
            A = removeZero(A);

            var result = new List<int>();
            var index = A.Count - 1;

            var mod = 1;

            while (index >= 0)
            {
                var newNum = A[index] + mod;

                if (newNum >= 10)
                {
                    mod = 1;
                    newNum = newNum % 10;
                }
                else
                {
                    mod = 0;
                }

                result.Add(newNum);
                index--;
            }

            if (mod > 0)
            {
                result.Add(mod);
            }

            result.Reverse();

            return result;
        }

        public int maxSubArray(List<int> A)
        {
            if (A.Count == 0)
            {
                return 0;
            }

            int lastSum = 0;
            int maxSum = A[0];
            foreach (int n in A)
            {
                if (lastSum <= 0)
                {
                    lastSum = n;
                }
                else
                {
                    lastSum += n;
                }
                maxSum = Math.Max(maxSum, lastSum);
            }
            return maxSum;
        }

        public List<int> maxset(List<int> A)
        {
            var maxList = new List<int>();
            long max = long.MinValue;

            var tmpList = new List<int>();
            long tmpMax = 0;

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] < 0)
                {
                    tmpList = new List<int> { };
                    tmpMax = 0;
                    continue;
                }

                if (i == 0)
                {
                    tmpList = new List<int> { A[i] };
                    tmpMax = A[i];
                }
                else
                {
                    tmpMax += (long)A[i];
                    tmpList.Add(A[i]);
                }

                if (tmpMax > max)
                {
                    max = tmpMax;
                    maxList = new List<int>(tmpList);
                }
                else if (tmpMax == max)
                {
                    if (tmpList.Count > maxList.Count)
                    {
                        maxList = new List<int>(tmpList);
                    }
                }
            }

            return maxList;
        }

        private List<int> GetNextRow(List<int> ls)
        {
            if (ls.Count == 0)
            {
                return new List<int> { 1 };
            }

            var nextRow = new List<int> { ls[0] };

            for (var i = 1; i < ls.Count; i++)
            {
                nextRow.Add(ls[i] + ls[i - 1]);
            }

            nextRow.Add(ls[ls.Count - 1]);

            return nextRow;
        }

        public List<int> getRow(int A)
        {
            var currentRow = new List<int>();
            for (int i = 0; i <= A; i++)
            {
                currentRow = GetNextRow(currentRow);
            }

            return currentRow;
        }

        public List<List<int>> solve(int A)
        {
            var result = new List<List<int>>();

            var currentRow = new List<int>();

            for (int i = 1; i <= A; i++)
            {
                currentRow = GetNextRow(currentRow);
                result.Add(currentRow);
            }

            return result;
        }

        public int calculateF(int i, int j, List<int> A)
        {
            return Math.Abs(i - j) + Math.Abs(A[i] - A[j]);
        }

        public int maxArr(List<int> A)
        {
            int ans = 0;
            int n = A.Count;

            int max1 = Int32.MinValue;
            int max2 = Int32.MinValue;

            int min1 = Int32.MaxValue;
            int min2 = Int32.MaxValue;

            for (int i = 0; i < n; i++)
            {
                max1 = Math.Max(max1, A[i] + i);
                max2 = Math.Max(max2, A[i] - i);
                min1 = Math.Min(min1, A[i] + i);
                min2 = Math.Min(min2, A[i] - i);
            }
            ans = Math.Max(ans, max2 - min2);
            ans = Math.Max(ans, max1 - min1);
            return ans;
        }

        public List<List<int>> diagonal(List<List<int>> A)
        {
            if (A.Count == 0 || A.Count != A[0].Count)
            {
                return new List<List<int>>();
            }

            var result = new List<List<int>>();
            var N = A.Count;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    var rowTh = i + j;
                    if (rowTh < result.Count)
                    {
                        result[rowTh].Add(A[i][j]);
                    }
                    else
                    {
                        result.Add(new List<int> { A[i][j] });
                    }
                }
            }

            return result;
        }

        private List<List<int>> init(int A)
        {
            var result = new List<List<int>>();
            for (int i = 0; i < A; i++)
            {
                var ls = new List<int>();
                for (int j = 0; j < A; j++)
                {
                    ls.Add(0);
                }

                result.Add(ls);
            }

            return result;
        }

        public List<List<int>> generateMatrix(int A)
        {
            var result = init(A);

            var num = 1;
            var total = A * A;
            int Rend = A - 1;
            int Cend = A - 1;
            int RStart = 0;
            int CStart = 0;

            while (num <= total)
            {
                for (int j = CStart; j <= Cend; j++)
                {
                    result[RStart][j] = num;
                    num++;
                }

                RStart++;

                for (int i = RStart; i <= Rend; i++)
                {
                    result[i][Cend] = num;
                    num++;
                }

                Cend--;

                for (int j = Cend; j >= CStart; j--)
                {
                    result[Rend][j] = num;
                    num++;
                }

                Rend--;

                for (int i = Rend; i >= RStart; i--)
                {
                    result[i][CStart] = num;
                    num++;
                }

                CStart++;

            }

            return result;
        }

        public int repeatedNumber(List<int> A)
        {
            A.Sort();

            for (int i = 0; i < A.Count - 1; i++)
            {
                if (A[i] == A[i + 1])
                {
                    return A[i];
                }
            }

            return -1;
        }

        public int maximumGap(List<int> A)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < A.Count; i++)
            {
                map.Add(i, A[i]);
            }
            int min = A.Count - 1;
            int ans = -1;

            foreach (var item in map.OrderBy(x => x.Value))
            {
                if (min > item.Key)
                    min = item.Key;

                if (ans < item.Key - min)
                    ans = item.Key - min;
            }

            return ans;
        }

        public List<int> subUnsort(List<int> A)
        {
            int i = 0;
            int j = A.Count - 1;
            bool isIncreasing = true;
            bool isDecreasing = true;
            var x = -1;
            var y = -1;

            while (i < j)
            {
                if (A[i] > A[j])
                    break;

                if (A[i] <= A[i + 1])
                {
                    i++;
                    if (A[i] > A[j])
                        break;
                }

                if (A[j] >= A[j - 1])
                {
                    j--;
                    if (A[i] > A[j])
                        break;
                }
            }

            if (i < j)
            {
                var unsorted = A.GetRange(i, j - i + 1);
                var min = unsorted.Min();
                var misorted = A.GetRange(0, i);
                //var max = unsorted.Max();

                var index = misorted.LastIndexOf(min);
                if (index >= 0 && index < i)
                {
                    i = index++;
                }

                return new List<int> { i, j };
            }



            return new List<int> { -1 };
        }

        public int firstMissingPositive(List<int> A)
        {
            A.Sort();
            int result = 1;
            for (var i = 0; i < A.Count; i++)
            {
                if (A[i] <= 0)
                    continue;

                if (A[i] > result)
                    return result;

                if (A[i] == result)
                    result++;
            }

            return result;
        }

        public List<int> repeatedNumber1(List<int> A)
        {
            A.Sort();
            var result = new List<int>();
            var miss = 1;
            for (int i = 0; i < A.Count - 1; i++)
            {
                if (result.Count == 2)
                {
                    return result;
                }

                if (A[i] == A[i + 1])
                {
                    result.Insert(0, A[i]);
                }

                if (A[i] == miss)
                {
                    miss++;
                }
                else if (A[i] > miss)
                {
                    result.Add(miss);
                    miss = A.Count + 1;
                }

            }

            if (result.Count != 2)
                result.Add(miss);
            return result;
        }


        public List<string> fizzBuzz(int A)
        {
            var result = new List<string>();

            for (int i = 1; i <= A; i++)
            {
                if (i % 15 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }

        private bool isPrime(int N)
        {
            var M = N / 2 + 1;
            for (int i = 2; i <= M; i++)
            {
                if (N % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public List<int> primesum(int A)
        {
            if (A == 4)
            {
                return new List<int> { 2, 2 };
            }

            var N = A / 2 + 1;

            for (int i = 3; i <= N; i = i + 2)
            {
                if (!isPrime(i))
                    continue;

                var tmp = A - i;
                if (!isPrime(tmp))
                    continue;

                return new List<int> { i, tmp };

            }

            return new List<int>();
        }

        public int trailingZeroes(int A)
        {
            if (A < 5)
                return 0;

            var rs = 1;
            for (int i = 5; i <= A; i = i + 5)
            {
                var tmp = i;

                while (tmp % 5 == 0)
                {
                    rs++;
                    tmp = tmp / 5;
                }
            }

            return rs;
        }

        public int isPower(int A)
        {
            if (A == 1)
                return 1;

            var i = 2;
            var tmp = 0;
            var pow = 0;

            while (i <= A && A > 1)
            {
                while (A % i == 0)
                {
                    tmp++;
                    A = A / i;
                }

                i++;

                if (tmp == 1)
                    return 0;

                if (tmp > 1)
                {
                    if (pow == 0)
                        pow = tmp;

                    if (pow == tmp)
                        continue;

                    if (UCLN(tmp, pow) > 1)
                        continue;

                    return 0;
                }

                tmp = 0;
            }

            return pow > 0 ? 1 : 0;
        }

        static int hamming_distance(int x, int y)
        {
            int dist = 0;
            int val = x ^ y;

            // Count the number of bits set
            while (val != 0)
            {
                // A bit is set, so increment the count and clear the bit
                dist++;
                val &= val - 1;
            }

            // Return the number of differing bits
            return dist;
        }

        int hamming_distance1(int x, int y)
        {
            int dist = 0;
            int val = x ^ y;

            // Count the number of bits set
            while (val != 0)
            {
                // A bit is set, so increment the count and clear the bit
                dist++;
                val &= val - 1;
            }

            // Return the number of differing bits
            return dist;
        }

        public int hammingDistance(List<int> A)
        {
            var N = A.Count;
            var total = 0;

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                    if (A[i] != A[j])
                        total += hamming_distance(A[i], A[j]);
            }

            return total * 2;
        }

        public int titleToNumber(string A)
        {
            var N = A.Length - 1;
            var index = 0;
            var i = 0;
            while (N >= 0)
            {
                index += (A[i] - 64) * (int)Math.Pow(26, N);
                N--;
                i++;
            }

            return index;
        }

        public string convertToTitle(int A)
        {
            var str = string.Empty;
            int i = 0;

            while (A > 0)
            {
                var num = A % 26;
                if (num == 0)
                {
                    num = 26;
                }

                A = (int)((A - num) / 26);
                var realNum = num + 64;
                i++;
                if (realNum < 65 || realNum > 90)
                {
                    continue;
                }

                str = (char)realNum + str;
            }

            return str;
        }

        public int isPalindrome(int A)
        {
            string AStr = A.ToString();
            var RASrt = string.Empty;

            for (int i = AStr.Length - 1; i >= 0; i--)
            {
                RASrt += AStr[i];
            }

            return AStr.Equals(RASrt) ? 1 : 0;
        }


        public int reverse(int A)
        {
            try
            {
                string AStr = A.ToString();
                var RASrt = string.Empty;

                for (int i = AStr.Length - 1; i >= 0; i--)
                {
                    if (AStr[i] == '-')
                    {
                        RASrt = '-' + RASrt;
                    }
                    else
                    {
                        RASrt += AStr[i];
                    }

                }

                return int.Parse(RASrt);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public List<int> subUnsort1(List<int> a)
        {
            //1. Edge case checks
            if (a == null || a.Count < 2) return new List<int> { -1 };

            //2. Find the minimum index till where elements are sorted.
            int minI = 0;
            for (; minI < a.Count - 1; minI++) if (a[minI] > a[minI + 1]) break;

            //If all elements are sorted, return -1
            if (minI == a.Count - 1) return new List<int> { -1 };

            //3. Find the maximum index after which all elements are sorted.
            int maxI = a.Count - 1;
            for (; maxI > 0; maxI--) if (a[maxI] < a[maxI - 1]) break;

            //4. Now shift the min to left and max to right, until the left num
            //is greater than the smallest element in the unsorted part and
            //right num is smaller than the greatest element in the unsorted part.
            int min = int.MaxValue, max = int.MinValue;

            //4a. Find the min and max in the unsorted part.
            for (int i = minI; i <= maxI; i++)
            {
                min = Math.Min(min, a[i]);
                max = Math.Max(max, a[i]);
            }

            //4b. Moving the min to left.
            int gMin = 0;
            for (; gMin <= minI; gMin++) if (a[gMin] > min) break;

            //4c. Moving the max to right.
            int gMax = a.Count - 1;
            for (; gMax >= maxI; gMax--) if (a[gMax] < max) break;

            //5. Return the min and max.
            return new List<int> { gMin, gMax };
        }
    }

}

