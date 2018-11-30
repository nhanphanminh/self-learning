using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public partial class Solution
    {
        private List<int> RemoveDuplicatedInSortedArray(List<int> A)
        {
            var index = 0;

            while (index < A.Count - 1)
            {
                if (A[index] == A[index + 1])
                    A.RemoveAt(index);
                else
                {
                    index++;
                }
            }

            return A;
        }

        public int solve(List<int> A, int B, string CStr, bool isFirstDigits)
        {

            var numOfDigitsInC = CStr.Length;

            if (numOfDigitsInC < B)
                return 0;

            if (numOfDigitsInC > B)
                if (B > 1)
                    return (int)((int)A.Count(x => x != 0) * Math.Pow(A.Count, B - 1));
                else
                {
                    return A.Count;
                }

            var C0 = (int)Char.GetNumericValue(CStr[0]);
            var numLessThanFirstC = isFirstDigits && B > 1 ? A.Count(x => x < C0 && x != 0) : A.Count(x => x < C0);

            int count1 = (int)numLessThanFirstC * (int)Math.Pow(A.Count, B - 1);

            if (A.Contains(C0) && CStr.Length > 1)
                return count1 + A.Count(x => x == C0) * solve(A, B - 1, CStr.Remove(0, 1), false);
            else
            {
                return count1;
            }
        }

        public int solve(List<int> A, int B, int C)
        {
            if (B < 1)
                return 0;
            if (C <= 0)
                return 0;
            var CStr = C.ToString();
            return solve(A, B, CStr, true);
            //A = RemoveDuplicatedInSortedArray(A);


        }

        public int sumBetween1and2(List<string> A)
        {
            if (A.Count < 3)
                return 0;

            A.RemoveAll(x => x[0] >= '2');
            A.Sort();

            var start = 0;
            var end = A.Count - 1;

            var startNUm = float.Parse(A[start]);
            var nextStartNUm = float.Parse(A[start + 1]);
            var rs = 2 - startNUm - nextStartNUm;
            var endNUm = float.Parse(A[end]);

            while (end > start && rs < endNUm)
            {
                end--;
                endNUm = float.Parse(A[end]);
            }


            rs = 1 - endNUm;
            while (start < end - 1 && startNUm + nextStartNUm <= rs)
            {
                start++;
                startNUm = nextStartNUm;
                nextStartNUm = float.Parse(A[start + 1]);
            }

            if (start < end - 1)
            {
                return 1;
            }


            return 0;
        }


        //S = 010
        //Pair of[L, R] | Final string
        //    _______________|_____________
        //    [1 1]          | 110
        //[1 2]          | 100
        //[1 3]          | 101
        //[2 2]          | 000
        //[2 3]          | 001

        //Your Input: 101110000 
        //Expected output is 6 9
        public List<int> flip(string A)
        {
            if (string.IsNullOrEmpty(A) || A.All(x => x == '1'))
                return new List<int>();

            var start = 0;
            var end = A.Length;
            var max = 0;
            var RStart = -1;
            var REnd = 1;
            var tmpStart = start + 1;
            var tmpMax = 0;
            while (start < end)
            {
                if (A[start] == '0')
                {
                    tmpMax++;
                }
                else
                {
                    tmpMax--;
                }

                if (tmpMax < 0)
                {
                    tmpStart = start + 2;
                    tmpMax = 0;
                }

                if (tmpMax > max)
                {
                    max = tmpMax;
                    RStart = tmpStart;
                    REnd = start + 1;
                }

                start++;
            }

            if (RStart <= REnd && RStart > 0)
                return new List<int> { RStart, REnd };
            return new List<int>();
        }
    }
}

