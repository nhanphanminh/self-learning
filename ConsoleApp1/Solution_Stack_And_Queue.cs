using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public partial class Solution
    {
        //path = "/home/", => "/home"
        //path = "/a/./b/../../c/", => "/c"
        public string simplifyPath(string path)
        {
            if (string.IsNullOrEmpty(path) || path.Length <= 2)
                return path;

            path = path.Trim();
            var paths = path.Split('/');
            var oPaths = new List<string>();

            for (int i = 0; i < paths.Length; i++)
            {
                var p = paths[i].Trim();

                if (p.Equals(".") || string.IsNullOrWhiteSpace(p))
                {
                    continue;
                }

                if (!p.Equals(".."))
                {
                    oPaths.Add(p);
                }
                else
                {
                    if (oPaths.Count >= 1)
                    {
                        oPaths.RemoveAt(oPaths.Count - 1);
                    }
                }
            }

            if (!oPaths.Any())
                return "/";

            var root = new StringBuilder();

            for (int i = 0; i < oPaths.Count; i++)
            {
                root.Append("/");
                root.Append(oPaths[i]);
            }

            return root.ToString();
        }

        //((a + b)) has redundant braces so answer will be 1
        //(a + (a + b)) doesn't have have any redundant braces so answer will be 0
        //public int braces(string A)
        //{
        //}

        //Example:

        //Input : A : [4, 5, 2, 10, 8]
        //Return : [-1, 4, -1, 2, 2]

        //Example 2:

        //Input : A : [3, 2, 1]
        //Return : [-1, -1, -1]

        public List<int> prevSmaller(List<int> A)
        {
            var rs = new List<int>();
            if (A == null || !A.Any())
                return rs;

            rs.Add(-1);
            if (A.Count == 1)
            {
                return rs;
            }

            var min = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                if (min >= A[i])
                {
                    rs.Add(-1);
                    min = A[i];
                    continue;
                }

                var isMatched = false;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (A[j] < A[i])
                    {
                        rs.Add(A[j]);
                        isMatched = true;
                        break;
                    }
                }

                if (!isMatched)
                {
                    rs.Add(-1);
                }
            }

            return rs;
        }

        // max area
        public int largestRectangleArea(List<int> A)
        {
            if (A.Count == 1)
                return A[0];

            var max = 0;

            for (var i = 0; i < A.Count; i++)
            {
                if (A[i] == 0 || i > 0 && A[i] <= A[i - 1])
                    continue;

                var tmpMin = A[i];

                if (max < A[i])
                    max = A[i];

                for (var j = i + 1; j < A.Count; j++)
                {
                    tmpMin = Math.Min(tmpMin, A[j]);

                    if (A[j] == 0 || tmpMin * (A.Count - i + 1) < max)
                        break;

                    var tmp = (j - i + 1) * tmpMin;

                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }
            }

            return max;
        }

        //[1 3 -1 -3 5 3 6 7]
        //[3,3,5,5,6,7]
        public List<int> slidingMaximum(List<int> A, int B)
        {
            if (A == null || !A.Any())
                return new List<int>();

            if (A.Count <= B)
            {
                return new List<int> { A.Max() };
            }

            var result = new List<int>();
            var index = 0;
            var lastIndex = A.Count - B;
            var tmpMax = int.MaxValue;
            var tmpList = new List<int>();
            var tmpCount = 0;

            while (index < A.Count)
            {
                if (tmpCount < B)
                {
                    tmpList.Add(A[index]);
                    tmpCount++;
                }
                else /*if (tmpCount == B)*/
                {
                    result.Add(tmpList.Max());
                    tmpList.RemoveAt(0);
                    tmpList.Add(A[index]);
                    tmpCount++;
                }
                //else
                //{
                //    tmpList.RemoveAt(0);
                //    tmpList.Add(A[index]);
                //    result.Add(tmpList.Max());
                //}

                index++;
            }
            result.Add(tmpList.Max());
            return result;
        }
        #region better solution
        ////better solution
        //public List<int> slidingMaximum(List<int> A, int B)
        //{

        //    int l = A.Count;
        //    List<int> result = new List<int>();
        //    int[] deque = new int[l];
        //    int front = -1;
        //    int rear = -1;
        //    int i;
        //    for (i = 0; i < B; i++)
        //    {
        //        while (rear >= front && rear >= 0 && A[i] >= A[deque[rear]])
        //        {
        //            rear--;
        //        }
        //        if (front == -1)
        //            front = 0;

        //        deque[++rear] = i;
        //    }
        //    for (; i < l; i++)
        //    {
        //        result.Add(A[deque[front]]);

        //        while (rear >= front && front < l && deque[front] <= i - B)
        //        {
        //            front++;
        //        }
        //        while (rear >= front && rear >= 0 && A[i] >= A[deque[rear]])
        //        {
        //            rear--;
        //        }
        //        if (front == -1)
        //            front = 0;

        //        deque[++rear] = i;

        //    }

        //    result.Add(A[deque[front]]);
        //    return result;
        //}
        #endregion

        //Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.
        public List<int> getTraps(List<int> A)
        {
            if (A == null || A.Count <= 1)
            {
                return new List<int>();
            }

            if (A.Count == 2)
            {
                return A;
            }
            var index = 0;
            while (index < A.Count && A[index] <= 0)
            {
                index++;
            }

            if (index >= A.Count)
                return new List<int>();

            var left = A[index];
            var rs = new List<int> { index };

            var leftIndex = 0;

            while (index < A.Count)
            {
                if (index < A.Count - 1 && A[index] <= A[index + 1])
                {
                    index++;
                    left = A[index];
                    rs.RemoveAt(rs.Count - 1);
                    rs.Add(index);
                    continue;
                }

                var tmpMaxRight = 0;
                var rightIndex = index + 2;
                var j = rightIndex;

                while (j < A.Count && A[j] < left)
                {
                    if (tmpMaxRight <= A[j])
                    {
                        tmpMaxRight = A[j];
                        rightIndex = j;
                    }

                    j++;
                }


                if (rightIndex >= A.Count)
                {
                    break;
                }

                if (j < A.Count)
                {
                    rs.Add(j);
                    left = A[j];
                    index = j;
                }
                else
                {
                    index = rightIndex;
                    rs.Add(rightIndex);
                }
            }

            return rs;
        }

        public int CalculateTrap(List<int> A, int left, int right)
        {
            var result = 0;
            var min = Math.Min(A[left], A[right]);

            for (int i = left + 1; i <= right - 1; i++)
            {
                var tmp = min - A[i];
                if (tmp > 0)
                {
                    result += tmp;
                }
            }

            return result;
        }

        public int trap(List<int> A)
        {
            var traps = getTraps(A);

            if (traps.Count <= 1)
            {
                return 0;
            }

            var rs = 0;
            for (int i = 0; i < traps.Count - 1; i++)
            {
                rs += CalculateTrap(A, traps[i], traps[i + 1]);
            }

            return rs;
        }
    }
}





