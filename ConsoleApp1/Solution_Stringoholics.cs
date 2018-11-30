using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public partial class Solution
    {
        private string rotateString(string S, int i)
        {
            if (i == S.Length)
                return S;

            if (i > S.Length)
                i = i % S.Length;

            var end = S.Substring(0, i);
            var start = S.Substring(i);
            return start + end;
        }

        private List<bool> InitList(int N)
        {
            var result = new List<bool>();
            for (int i = 0; i < N; i++)
                result.Add(false);

            return result;
        }

        private List<int> InitListRotate(int N)
        {
            var result = new List<int>();
            for (int i = 0; i < N; i++)
                result.Add(1);

            return result;
        }


        public int solve(List<string> A)
        {
            A.RemoveAll(S => S.All(x => x == 'a'));
            A.RemoveAll(S => S.All(x => x == 'b'));
            var checkedList = InitList(A.Count);
            var maxLength = A.Max(x => x.Length);
            var listRotate = InitListRotate(A.Count);
            var result = 0;
            var current = new List<string>(A);
            var max = 0;
            var done = false;
            var i = 1;
            while (true)
            {
                var tmp = 0;

                for (int j = 0; j < A.Count; j++)
                {
                    if (!checkedList[j])
                    {
                        current[j] = rotateString(current[j], listRotate[j]);
                        if (current[j] == A[j])
                        {
                            tmp++;
                            checkedList[j] = true;
                        }
                        else
                        {
                            listRotate[j]++;
                        }
                    }
                }

                if (tmp == A.Count)
                    return i;

                if (i == 487555988)
                {
                    Console.WriteLine("it 's him");
                }

                if (checkedList.All(x => x))
                {
                    return BCNN109Plus7(listRotate);
                }

                i++;
            }

            //487555988
            return result;
        }
    }
}


