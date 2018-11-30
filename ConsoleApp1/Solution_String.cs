using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public partial class Solution
    {
        private string GetNextSequenceString(string currentString)
        {
            var index = 1;
            var count = 1;
            var current = currentString[0];
            var result = new StringBuilder();

            while (index < currentString.Length)
            {
                if (currentString[index] == current)
                    count++;
                else
                {
                    result.Append(count);
                    result.Append(current);
                    count = 1;
                    current = currentString[index];
                }
                index++;
            }

            result.Append(count);
            result.Append(current);

            return result.ToString();
        }

        public string countAndSay(int A)
        {
            if (A < 1)
                return string.Empty;

            var result = "1";
            var index = 1;

            while (index < A)
            {
                result = GetNextSequenceString(result);
                index++;
            }

            return result;
        }

        public int lengthOfLastWord(string A)
        {
            var trim = A.Trim();
            var s = trim.Split(' ');
            if (s.Length == 0)
                return 0;
            var x = s[s.Length - 1];
            return x.Length;
        }

        [Benchmark]
        public string addBinary(string A, string B)
        {
            var ALength = A.Length;
            var BLength = B.Length;
            var N = Math.Max(ALength, BLength);
            var c = new StringBuilder();
            var mod = 0;

            for (int i = 1; i <= N; i++)
            {
                var a = ALength - i >= 0 ? (int)char.GetNumericValue(A[ALength - i]) : 0;
                var b = BLength - i >= 0 ? (int)char.GetNumericValue(B[BLength - i]) : 0;

                var total = a + b;
                var c1 = (total + mod) % 2;
                mod = (total + mod) / 2;
                c.Insert(0, c1);
                if (ALength - i < 0 && mod == 0)
                {
                    c.Insert(0, B.Substring(0, BLength - i));
                    return c.ToString();
                }

                if (BLength - i < 0 && mod == 0)
                {
                    c.Insert(0, A.Substring(0, ALength - i));
                    return c.ToString();
                }
            }

            if (mod != 0)
            {
                c.Insert(0, mod);
            }

            return c.ToString();
        }


        private void addChar(StringBuilder S, int num, string C)
        {
            S.Insert(0, C, num);
        }

        private int processChar(int A, StringBuilder S, string a, string b, string c, int num)
        {
            var S1 = new StringBuilder();
            var numC = A / num;
            if (numC > 0)
            {
                if (numC <= 3)
                {
                    addChar(S1, numC, a);
                }
                else if (numC == 4)
                {
                    addChar(S1, 1, b);
                    addChar(S1, 1, a);
                }
                else if (numC > 4 && numC <= 8)
                {
                    addChar(S1, numC - 5, a);
                    addChar(S1, 1, b);
                }
                else if (numC == 9)
                {
                    addChar(S1, 1, c);
                    addChar(S1, 1, a);
                }

                A = A - numC * num;
            }

            S.Append(S1);

            return A;
        }

        public string intToRoman(int A)
        {
            var result = new StringBuilder();
            //add M:
            var numM = A / 1000;
            if (numM > 0)
            {
                addChar(result, numM, "M");
                A = A - numM * 1000;
            }



            //add C,D
            A = processChar(A, result, "C", "D", "M", 100);
            //add X, L
            A = processChar(A, result, "X", "L", "C", 10);

            processChar(A, result, "I", "V", "X", 1);
            return result.ToString();
        }

        private readonly Dictionary<char, int> _map = new Dictionary<char, int> {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public int romanToInt(string s)
        {
            var sum = _map[s[s.Length - 1]];
            for (var i = s.Length - 2; i >= 0; i--)
            {
                if (_map[s[i]] < _map[s[i + 1]])
                {
                    sum -= _map[s[i]];
                }
                else
                {
                    sum += _map[s[i]];
                }
            }
            return sum;
        }

        public int strStr(string A, string B)
        {
            if (B.Length > A.Length || string.IsNullOrEmpty(B) || string.IsNullOrEmpty(A))
                return -1;

            var index = 0;
            var Bcount = 0;

            while (index + B.Length <= A.Length)
            {
                if (A[index] == B[Bcount])
                {
                    while (Bcount < B.Length)
                    {
                        if (A[index + Bcount] != B[Bcount])
                        {
                            Bcount = 0;
                            break;
                        }

                        Bcount++;
                    }

                    if (Bcount == B.Length)
                        return index;
                }

                index++;

            }

            return -1;
        }

        private bool isPalindromic(string A)
        {
            var start = 0;
            var end = A.Length - 1;
            while (start < end)
            {
                if (A[start] != A[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }

        private string GetMaxSubStringIsPalindromicFromindex(string A, int i)
        {
            if (string.IsNullOrEmpty(A))
                return string.Empty;

            var max = 1;
            var j = A.Length - i;
            var subResult = A[0].ToString();

            while (j > max && j > 1)
            {
                var sub = A.Substring(i, j);

                if (isPalindromic(sub))
                {
                    if (max < sub.Length)
                    {
                        max = j;
                        subResult = sub;
                    }

                }

                j--;
            }

            return subResult;
        }

        public int solve(string A)
        {
            if (A.Length <= 1)
                return 0;

            var s = GetMaxSubStringIsPalindromicFromindex(A, 0);
            return A.Length - s.Length;
        }

        private string GetMaxSubStringIsPalindromic(string A)
        {
            int max = 1;
            var subResult = A[0].ToString();
            for (int i = 0; i < A.Length - 1; i++)
            {
                GetMaxSubStringIsPalindromicFromindex(A, i);
            }

            return subResult;
        }



        //insert everywhere to become Palindromic
        public int InsertToPalindromic(string A)
        {
            while (A.Length > 1)
            {
                if (A[0] != A[A.Length - 1])
                {
                    break;
                }

                A = A.Remove(0, 1);
                A = A.Remove(A.Length - 1, 1);
            }

            if (A.Length <= 1)
                return 0;

            var s = GetMaxSubStringIsPalindromic(A);

            return A.Length - s.Length;
        }

        private int CompareVerString(string A, string B)
        {
            if (A.Length == B.Length)
                return string.Compare(A, B);

            return A.Length > B.Length ? 1 : -1;
        }

        public int compareVersion(string A, string B)
        {
            var verA = A.Split('.');
            var verB = B.Split('.');
            var max = Math.Max(verA.Length, verB.Length);
            char[] reduntdants = { ' ', '0' };

            for (int i = 0; i < max; i++)
            {
                var aver = i < verA.Length ? verA[i].TrimStart(reduntdants) : string.Empty;
                var bver = i < verB.Length ? verB[i].TrimStart(reduntdants) : string.Empty;

                if (aver == bver)
                    continue;

                return CompareVerString(aver, bver);
            }

            return 0;
        }

        private bool isInteger(string A)
        {
            if (string.IsNullOrEmpty(A))
                return false;

            if (A[0] == '-')
                A = A.Remove(0, 1);
            A = A.Trim();
            if (string.IsNullOrEmpty(A))
                return false;

            for (int i = 0; i < A.Length; i++)
                if (A[i] < '0' || A[i] > '9')
                    return false;

            return true;
        }

        private bool isFloatNumber(string A, bool isDecimal)
        {

            if (string.IsNullOrEmpty(A))
                return false;

            if (A[0] == '.')
                A = '0' + A;
            if (!isDecimal)
                if (A.Contains("."))
                    return false;

            var nums = A.Split('.');
            if (nums.Length > 2)
                return false;

            foreach (var num in nums)
            {
                if (!isInteger(num))
                    return false;
            }
            return true;
        }

        public int isNumber(string A)
        {
            var nums = A.Split('e');
            if (nums.Length > 2)
                return 0;

            if (!isFloatNumber(nums[0], true))
                return 0;

            if (nums.Length == 2)
                if (!isFloatNumber(nums[1], false))
                    return 0;

            return 1;
        }

        //ZIGZAC
        public string convert(string A, int B)
        {
            if (A.Length <= 2 || B <= 1)
                return A;

            var results = new List<StringBuilder>();

            for (int j = 0; j < B; j++)
                results.Add(new StringBuilder());

            var index = 0;
            bool isDone = false;

            while (!isDone)
            {
                for (int j = 0; j < B; j++)
                {
                    results[j].Append(A[index]);
                    index++;
                    if (index >= A.Length)
                    {
                        isDone = true;
                        break;
                    }
                }

                if (isDone)
                    break;

                for (int j = B - 2; j >= 1; j--)
                {
                    results[j].Append(A[index]);
                    index++;
                    if (index >= A.Length)
                    {
                        isDone = true;
                        break;
                    }
                }
            }

            var result = new StringBuilder();
            foreach (var st in results)
            {
                result.Append(st);
            }

            return result.ToString();
        }
    }
}


