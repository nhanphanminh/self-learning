using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Solution
    {
        public List<int> intersect(List<int> A, List<int> B)
        {
            var result = new List<int>();
            var i = 0;
            var j = 0;

            while (i < A.Count && j < B.Count)
            {
                if (i < A.Count && A[i] < B[j])
                {
                    i++;
                }
                else if (j < B.Count && A[i] > B[j])
                {
                    j++;
                }
                else if (i < A.Count && j < B.Count && A[i] == B[j])
                {
                    result.Add(A[i]);
                    i++;
                    j++;
                }
            }

            return result;
        }

        //A : [ 2, 1, -9, -7, -8, 2, -8, 2, 3, -8 ]
        //B : -1
        public int threeSumClosest(List<int> lis, int target)
        {
            int diff = Int32.MaxValue, tdiff = Int32.MaxValue;
            lis.Sort();
            int start, end;
            for (int i = 0; i < lis.Count - 2; i++)
            {
                start = i + 1;
                end = lis.Count - 1;
                while (start < end)
                {
                    int current = lis[i] + lis[start] + lis[end];
                    if (target > current)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                    if (diff > Math.Abs(target - current))
                    {
                        diff = Math.Abs(target - current);
                        tdiff = current;
                    }
                }
            }
            return tdiff;
        }

        public int diffPossible(List<int> A, int B)
        {
            //var start = 0;
            //var end = A.Count - 1;
            //while (end > start)
            //{
            //    var tmp = A[end] - A[start];

            //    if (tmp == B)
            //        return 1;
            //}

            for (int i = 0; i < A.Count - 1; i++)
                for (int j = i + 1; j < A.Count; j++)
                    if (A[j] - A[j] == B)
                        return 1;

            return 0;
        }

        public int singleNumber(List<int> A)
        {
            var tmp = 0;
            for (int i = 0; i < A.Count; i++)
            {
                tmp = tmp ^ A[i];
            }

            return tmp;
        }

        public List<List<int>> threeSum(List<int> A)
        {
            if (A == null || A.Count == 0)
                return new List<List<int>>();


            int[] nums = A.ToArray();
            int n = nums.Length;
            Array.Sort(nums);

            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i <= nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {              // skip same result
                    continue;
                }

                int j = i + 1;
                int k = nums.Length - 1;

                while (j < k)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });
                        j++;
                        k--;
                        while ((j < k) && (nums[j] == nums[j - 1])) j++;// avoid duplicates
                        while ((j < k) && (nums[k] == nums[k + 1])) k--;// avoid duplicates
                    }
                    else if (nums[i] + nums[j] + nums[k] > 0)
                        k--;
                    else
                        j++;

                }
            }

            return result;

        }

        //1 1 0 1 1 0 0 1 1 1 
        public List<int> maxone(List<int> A, int B)
        {
            if (A.Count == 0)
                return new List<int>();

            var start = 0;
            int Start = 0, End = 0, Max = 0;

            while (start >= 0)
            {
                var m = B;
                var tmp = 0;
                var end = start;
                while (end < A.Count)
                {
                    if (A[end] == 0)
                    {
                        if (m > 0)
                        {
                            m--;
                        }
                        else
                        {
                            break;
                        }
                    }
                    tmp++;
                    end++;
                }

                if (tmp > Max)
                {
                    Max = tmp;
                    Start = start;
                    End = end;
                }

                if (start == 0)
                    start++;
                else
                {
                    while (start < A.Count && (A[start - 1] == 1 && A[start] == 1))
                        start++;
                }

            }

            var result = new List<int>();

            for (int i = Start; i <= End; i++)
            {
                result.Add(i + 1);
            }

            return result;
        }

        private int calculateMaxThree(int i, int j, int k)
        {
            var max = Math.Max(Math.Abs(i - j), Math.Abs(i - k));

            return Math.Max(max, Math.Abs(k - j));
        }

        public int minimize(List<int> A, List<int> B, List<int> C)
        {
            var min = int.MaxValue;
            var k = 0;
            var j = 0;

            for (var i = 0; i < A.Count; i++)
            {
                while (true)
                {
                    if (j < B.Count - 1 && Math.Max(Math.Abs(B[j + 1] - A[i]), Math.Abs(B[j + 1] - C[k]))
                        <= Math.Max(Math.Abs(B[j] - A[i]), Math.Abs(B[j] - C[k])))
                    {
                        j++;
                    }
                    else if (k < C.Count - 1 && Math.Max(Math.Abs(C[k + 1] - A[i]), Math.Abs(C[k + 1] - B[j]))
                        <= Math.Max(Math.Abs(C[k] - A[i]), Math.Abs(B[j] - C[k])))
                    {
                        k++;
                    }
                    else
                    {
                        break;
                    }
                }

                var tmp = calculateMaxThree(A[i], B[j], C[k]);

                if (tmp == 0)
                    return 0;

                if (tmp < min)
                    min = tmp;
            }

            return min;
        }

        //largest area
        public int maxArea(List<int> A)
        {
            var max = 0;

            for (int i = 0; i < A.Count - 1; i++)
            {
                if (A[i] == 0)
                    continue;


                for (int j = A.Count - 1; j > i; j--)
                {
                    if (A[i] * (j - i) < max)
                        break;

                    if (A[j] == 0)
                        continue;

                    var tmp = (j - i) * Math.Min(A[i], A[j]);

                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }
            }

            return max;
        }
    }
}





