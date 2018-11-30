using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public partial class Solution
    {
        public int ComparisonMethod(int x, int y)
        {
            return y.CompareTo(x);
        }

        //List.Sort((x, y) => ComparisonMethod(x, y));   

        private void InsertSorted(List<int> sortedList, int value)
        {
            if (sortedList == null)
            {
                sortedList = new List<int> { value };
                return;
            }

            if (!sortedList.Any())
            {
                sortedList.Add(value);
                return;
            }

            var index = 0;

            while (index < sortedList.Count && value < sortedList[index])
            {
                index++;
            }

            sortedList.Insert(index, value);
        }

        public int nchoc(int A, List<int> B)
        {
            const int N = 1000000007;

            if (A == 0 || !B.Any())
            {
                return 0;
            }

            B.Sort((x, y) => y.CompareTo(x));
            var times = 1;
            long rs = 0;

            while (times <= A)
            {
                rs = ((rs % N) + (B[0] % N)) % N;

                var tmp = B[0] / 2;
                B.RemoveAt(0);

                if (tmp > 0)
                {
                    InsertSorted(B, tmp);
                }

                if (!B.Any())
                {
                    rs %= N;
                    return (int)rs;
                }

                times++;
            }

            rs %= N;
            return (int)rs;
        }

        private Dictionary<int, int> GetFirstDic(List<int> A, int B)
        {
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < B; i++)
            {
                int tmp;

                if (dict.TryGetValue(A[i], out tmp))
                {
                    dict[A[i]]++;
                }
                else
                {
                    dict.Add(A[i], 1);
                }
            }

            return dict;
        }

        public List<int> dNums(List<int> A, int B)
        {
            if (A == null || !A.Any() || A.Count < B)
            {
                return new List<int>();
            }

            var dict = GetFirstDic(A, B);
            var lastIndex = A.Count - B;
            var result = new List<int> { dict.Count };

            for (var index = 1; index <= lastIndex; index++)
            {
                // remove 1st value
                var preIndex = index - 1;

                if (dict[A[preIndex]] > 1)
                {
                    dict[A[preIndex]]--;
                }
                else
                {
                    dict.Remove(A[index - 1]);
                }

                //add next value
                var nextIndex = index + B - 1;

                if (dict.ContainsKey(A[nextIndex]))
                {
                    dict[A[nextIndex]]++;
                }
                else
                {
                    dict.Add(A[nextIndex], 1);
                }

                result.Add(dict.Count);
            }

            return result;
        }

        private int _capacity;
        private Dictionary<int, int> _dict;
        private List<int> caches;
        public Solution(int capacity)
        {
            _capacity = capacity;
            _dict = new Dictionary<int, int>();
            caches = new List<int>();
        }

        public int get(int key)
        {
            int tmp = -1;

            if (_dict.TryGetValue(key, out tmp))
            {
                caches.Remove(key);
                caches.Add(key);
                return tmp;
            }

            return -1;
        }

        public void set(int key, int value)
        {
            if (_dict.ContainsKey(key))
            {
                _dict[key] = value;
                caches.Remove(key);
                caches.Add(key);
                return;
            }

            if (_dict.Count >= _capacity)
            {
                if (caches.Any())
                {
                    var lastKey = caches[0];
                    caches.RemoveAt(0);
                    _dict.Remove(lastKey);

                }
                else
                {
                    _dict.Remove(_dict.Keys.First());
                }
            }

            caches.Remove(key);
            caches.Add(key);
            _dict.Add(key, value);
        }

        public List<int> solve(List<int> A, List<int> B)
        {
            if (!A.Any())
            {
                return new List<int>();
            }

            if (A.Count == 1)
            {
                return new List<int> { A[0] + B[0] };
            }

            A.Sort();
            B.Sort();
            var N = A.Count;
            var AEnd = N - 1;
            var BEnd = N - 1;
            var rs = new List<int>();

            while (rs.Count <= N)
            {
                rs.Add(A[AEnd] + B[BEnd]);

                if (rs.Count == N)
                {
                    return rs;
                }

                var sumB = int.MinValue;

                if (BEnd >= 1)
                    sumB = A[AEnd] + B[BEnd - 1];

                for (int i = AEnd - 1; i >= 0; i--)
                {
                    var tmpSum = A[i] + B[BEnd];

                    if (tmpSum >= sumB)
                    {
                        rs.Add(tmpSum);

                        if (rs.Count == N)
                        {
                            return rs;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                var sumA = int.MinValue;
                if (AEnd >= 1)
                    sumA = A[AEnd - 1] + B[BEnd];

                for (int i = BEnd - 1; i >= 0; i--)
                {
                    var tmpSum = B[i] + A[AEnd];

                    if (tmpSum >= sumA)
                    {
                        rs.Add(tmpSum);

                        if (rs.Count == N)
                        {
                            return rs;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                AEnd--;
                BEnd--;
            }

            return rs;
        }
    }


}





