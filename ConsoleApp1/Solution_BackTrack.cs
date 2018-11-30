using System.Collections.Generic;
//using ICSharpCode.ILSpy;

namespace ConsoleApp1
{
    public partial class Solution
    {

        private List<List<int>> getCombine(int StartNums, int end, int Count)
        {
            var result = new List<List<int>>();
            if (Count == 1)
            {

                for (int i = StartNums; i <= end; i++)
                {
                    result.Add(new List<int> { i });
                }

                return result;
            }

            for (var i = StartNums; i <= end; i++)
            {
                var tmps = getCombine(i + 1, end + 1, Count - 1);
                foreach (var tm in tmps)
                {
                    var tmp = tm;
                    tmp.Insert(0, i);
                    result.Add(tmp);
                }
            }

            return result;
        }

        public List<List<int>> combine(int A, int B)
        {
            var list = new List<int>();
            var list1 = new List<int>();
            list1.AddRange(list1);

            if (A < B)
                return new List<List<int>>();

            if (A == B)
            {
                var ls = new List<int>();
                for (int i = 1; i <= A; i++)
                {
                    ls.Add(i);
                }

                return new List<List<int>> { ls };
            }

            return getCombine(1, A - B + 1, B);
        }
    }
}





