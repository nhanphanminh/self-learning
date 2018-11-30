using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class TreeMultiNode
    {
        public int val;
        public List<TreeMultiNode> children;
        public TreeMultiNode(int x)
        {
            this.val = x;
            children = new List<TreeMultiNode>();
        }
    }

    public partial class Solution
    {
        private int insertNode(TreeMultiNode root, int value)
        {
            var node = new TreeMultiNode(value);

            if (!root.children.Any())
            {
                root.children.Add(node);
                return 1;
            }

            var isAdded = false;
            var max = 0;

            foreach (var child in root.children)
            {
                if (child.val > value)
                {
                    continue;
                }

                isAdded = true;

                var tmp = insertNode(child, value) + 1;

                if (tmp > max)
                {
                    max = tmp;
                }
            }

            if (!isAdded)
            {
                root.children.Add(node);

                if (max < 2)
                {
                    max = 2;
                }
            }

            return max;
        }

        public int lis(List<int> A)
        {
            var index = 0;
            var max = 1;
            var checkedList = new bool[A.Count];

            while (index < A.Count)
            {
                if (checkedList[index])
                {
                    index++;
                    continue;
                }

                TreeMultiNode root = new TreeMultiNode(A[index]);
                checkedList[index] = true;

                for (int i = index + 1; i < A.Count; i++)
                {
                    if (A[i] < root.val)
                    {
                        continue;
                    }

                    checkedList[i] = true;
                    var tmp = insertNode(root, A[i]);
                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }

                index++;
            }

            if (max == 1)
            {
                return 1;
            }

            return max + 1;
        }

        private bool IsHaveSubString(string A, string subString, List<int> indexInA)
        {
            var index = 0;
            var start = 0;

            while (index < subString.Length)
            {
                var checkChar = subString[index];
                var tmp = Math.Max(start, indexInA[index]) + 1;

                if (tmp < 0 || tmp >= A.Length)
                {
                    return false;
                }

                tmp = A.IndexOf(checkChar, tmp);

                if (tmp < 0)
                {
                    return false;
                }

                start = tmp;
                index++;
            }

            return true;
        }

        private bool GetSubString(string A, int startIndex, Dictionary<string, bool> checkedString, int subLength, string subString, List<int> indexInA)
        {
            if (subLength == 0)
            {
                if (string.IsNullOrEmpty(subString))
                {
                    return false;
                }

                return IsHaveSubString(A, subString, indexInA);
            }

            for (int i = startIndex; i < A.Length - subLength; i++)
            {
                var tmp = subString + A[i];

                if (checkedString.ContainsKey(tmp))
                {
                    continue;
                }

                indexInA.Add(i);
                checkedString.Add(tmp, true);

                if (GetSubString(A, i + 1, checkedString, subLength - 1, tmp, indexInA))
                {
                    return true;
                }

                indexInA.Remove(i);
            }

            return false;
        }

        //Repeating Sub-Sequence
        public int anytwo(string A)
        {
            var Length = A.Length;
            var subLength = 2;

            while (subLength < Length)
            {
                if (GetSubString(A, 0, new Dictionary<string, bool>(), subLength, string.Empty, new List<int>()))
                {
                    return 1;
                }

                subLength++;
            }

            return 0;
        }

        //Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        //    Example :

        //Input : 3
        //Return : 3

        //Steps : [1 1 1], [1 2], [2 1]
        public int climbStairs(int A)
        {
            if (A < 0)
            {
                return 0;
            }
            else if (A < 2)
            {
                return 1;
            }

            int[] memo = new int[A + 1];
            memo[0] = memo[1] = 1;

            for (int i = 2; i <= A; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }

            return memo[A];
        }

        private int GetSubString(string Str, int startIndex, int startSub, string subString)
        {
            if (string.IsNullOrEmpty(Str) || string.IsNullOrEmpty(subString))
            {
                return 0;
            }

            if (Str.Length - startIndex < subString.Length - startSub)
            {
                return 0;
            }

            var subLengthRemain = subString.Length - startSub;
            var tmp = 0;
            var tmpChar = subString[startSub];

            for (var i = startIndex; i <= Str.Length - subLengthRemain; i++)
            {
                if (Str[i] != tmpChar)
                {
                    continue;
                }

                if (startSub == subString.Length - 1)
                {
                    tmp++;
                }
                else
                {
                    tmp += GetSubString(Str, i + 1, startSub + 1, subString);
                }

            }

            return tmp;
        }

        //Given two sequences S, T, count number of unique ways in sequence S, to form a subsequence that is identical to the sequence T.
        //Example :

        //S = "rabbbit" 
        //T = "rabbit"
        //Return 3. And the formations as follows:

        //S1= "ra_bbit" 
        //S2= "rab_bit" 
        //S3="rabb_it"
        //"_" marks the removed character.
        public int numDistinct(string A, string B)
        {
            return GetSubString(A, 0, 0, B);
        }

        //Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
        //Example,
        //Given:

        //s1 = "aabcc",
        //s2 = "dbbca",
        //When s3 = "aadbbcbcac", return true.
        //When s3 = "aadbbbaccc", return false.

        //Return 0 / 1 ( 0 for false, 1 for true ) for this problem
        private string s1, s2, s3;
        private bool?[,,] dp;
        public int isInterleave(string A, string B, string C)
        {
            s1 = A;
            s2 = B;
            s3 = C;

            if (s3.Length != s1.Length + s2.Length) return 0;

            dp = new bool?[201, 201, 201];

            var r = IsInterleavedInternal(0, 0, 0);

            return r.HasValue && r.Value ? 1 : 0;
        }

        private bool? IsInterleavedInternal(int i1, int i2, int i3)
        {
            if (i1 == s1.Length && i2 == s2.Length) return i3 == s3.Length;
            if (i3 >= s3.Length) return false;

            if (dp[i1, i2, i3] != null) return dp[i1, i2, i3];

            bool? ans = false;
            if (i1 < s1.Length && s1[i1] == s3[i3]) ans |= IsInterleavedInternal(i1 + 1, i2, i3 + 1);
            if (i2 < s2.Length && s2[i2] == s3[i3]) ans |= IsInterleavedInternal(i1, i2 + 1, i3 + 1);

            dp[i1, i2, i3] = ans;

            return dp[i1, i2, i3];
        }

        //Given two words A and B, find the minimum number of steps required to convert A to B. (each operation is counted as 1 step.)

        //You have the following 3 operations permitted on a word:

        //  Insert a character
        //  Delete a character
        //  Replace a character

        //---------- Example : -----------//
        //edit distance between
        //"Anshuman" and "Antihuman" is 2.

        //Operation 1: Replace s with t.
        //    Operation 2: Insert i.
        public int minDistance(string A, string B)
        {
            int[,] memo = new int[A.Length, B.Length];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }
            return GetEditDistance(A, B, 0, 0, memo);
        }

        private int GetEditDistance(string A, string B, int startA, int startB, int[,] memo)
        {

            if (startB == B.Length)
            {
                return A.Length - startA;
            }
            if (startA == A.Length)
            {
                return B.Length - startB;
            }

            if (memo[startA, startB] == -1)
            {

                if (A[startA] == B[startB])
                {
                    memo[startA, startB] = GetEditDistance(A, B, startA + 1, startB + 1, memo);
                }
                else
                {
                    int min = GetEditDistance(A, B, startA + 1, startB + 1, memo);
                    min = Math.Min(min, GetEditDistance(A, B, startA + 1, startB, memo));
                    min = Math.Min(min, GetEditDistance(A, B, startA, startB + 1, memo));
                    memo[startA, startB] = min + 1;
                }

            }

            return memo[startA, startB];

        }

        //Given an array of integers, find the length of longest subsequence which is first increasing then decreasing.

        //**Example: **

        //For the given array [1 11 2 10 4 5 2 1]

        //Longest subsequence is [1 2 10 4 2 1]

        //Return value 6

        //The problem can be solved as follows:

        //Construct array inc[i] where inc[i] stores Longest Increasing subsequence ending with A[i]. This can be done simply with O(n^2) DP.
        //    Construct array dec[i] where dec[i] stores Longest Decreasing subsequence ending with A[i]. This can be done simply with O(n^2) DP.
        //    Now we need to find the maximum value of(inc[i] + dec[i] - 1)
        public int longestSubsequenceLength(List<int> A)
        {
            int n = A.Count;
            if (A.Count == 0)
                return 0;
            if (A.Count == 1)
                return 1;
            int[] lis = new int[n];
            int[] lid = new int[n];
            for (int i = 0; i < n; i++)
            {
                lis[i] = 1;
                lid[i] = 1;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (A[i] > A[j] && lis[i] < lis[j] + 1)
                    {
                        lis[i] = lis[j] + 1;
                    }
                }
            }
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (A[i] > A[j] && lid[i] < lid[j] + 1)
                    {
                        lid[i] = lid[j] + 1;
                    }
                }
            }

            int max3 = lis[0] + lid[0] - 1;
            for (int k = 1; k < n; k++)
            {
                if (max3 < lis[k] + lid[k] - 1)
                {
                    max3 = lis[k] + lid[k] - 1;
                }
            }
            return max3;
        }
    }
}





