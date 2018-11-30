using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Solution
    {
        private bool CheckPath_recursion(List<int> A, int currentIndex)
        {
            if (currentIndex == A.Count - 1)
            {
                return true;
            }

            if (A[currentIndex] <= 0)
            {
                return false;
            }

            var steps = A[currentIndex];
            A[currentIndex] = 0;
            var nextIndex = currentIndex + 1;

            while (steps > 0 && nextIndex < A.Count)
            {
                if (CheckPath_recursion(A, nextIndex))
                {
                    return true;
                }

                nextIndex++;
                steps--;
            }

            return false;
        }

        private bool CheckPath(List<int> A)
        {
            var indexs = new List<int> { 0 };

            while (indexs.Count > 0)
            {
                var current = indexs[0];
                indexs.RemoveAt(0);

                if (A[current] <= 0)
                {
                    continue;
                }

                for (var steps = 1; steps <= A[current]; steps++)
                {
                    var nextIndex = current + steps;

                    if (nextIndex >= A.Count - 1)
                    {
                        return true;
                    }

                    if (A[nextIndex] == 0)
                    {
                        continue;
                    }

                    indexs.Add(nextIndex);
                }

                A[current] = 0;
            }

            return false;
        }

        public int canJump(List<int> A)
        {
            if (A == null || A.Count <= 1)
            {
                return 1;
            }

            if (A[0] == 0)
            {
                return 0;
            }

            return CheckPath(A) ? 1 : 0;
        }

        //public int jump(List<int> A)
        //{
        //    if (A == null || A.Count <= 1)
        //    {
        //        return 0;
        //    }

        //    if (A[0] == 0)
        //    {
        //        return -1;
        //    }

        //    var indexs = new Dictionary<int, int> { { 0, 0 } };
        //    var totalSteps = 1;

        //    while (indexs.Count > 0)
        //    {
        //        var tmp = new Dictionary<int, int>();

        //        foreach (var current in indexs.Keys)
        //        {
        //            if (A[current] <= 0)
        //            {
        //                continue;
        //            }

        //            for (var steps = 1; steps <= A[current]; steps++)
        //            {
        //                var nextIndex = current + steps;

        //                if (nextIndex > A.Count - 1)
        //                {
        //                    break;
        //                }

        //                if (nextIndex == A.Count - 1)
        //                {
        //                    return totalSteps;
        //                }

        //                if (A[nextIndex] == 0)
        //                {
        //                    continue;
        //                }

        //                if (!tmp.ContainsKey(nextIndex))
        //                {
        //                    tmp.Add(nextIndex, 0);
        //                }
        //            }

        //            A[current] = 0;
        //        }

        //        totalSteps++;
        //        indexs = tmp;
        //    }

        //    return -1;
        //}

        public int jump(List<int> A)
        {
            if (A == null || A.Count <= 1)
            {
                return 0;
            }

            if (A[0] == 0)
            {
                return -1;
            }

            var indexs = new Dictionary<int, int> { { 0, 0 } };
            var totalSteps = 1;
            var min = 1;
            var max = A[0];

            while (min <= max)
            {
                var tmpMin = int.MaxValue;
                var tmpMax = 0;

                for (int index = min; index <= max; index++)
                {
                    if (index == A.Count - 1)
                    {
                        return totalSteps;
                    }

                    if (A[index] == 0)
                    {
                        continue;
                    }

                    var minRange = index + 1;

                    if (tmpMin > minRange)
                    {
                        tmpMin = minRange;
                    }

                    var maxRange = A[index] + index;
                    if (tmpMax < maxRange)
                    {
                        tmpMax = maxRange;
                    }

                }

                min = tmpMin;
                max = tmpMax;

                totalSteps++;
            }

            return -1;
        }
    }
}





