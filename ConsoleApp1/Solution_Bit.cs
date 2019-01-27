using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Solution
    {
        //Input : [1, 2, 4, 3, 3, 2, 2, 3, 1, 1]
        //Output : 4
        // every numbers repeat thrice 3 times except 1
        public int singleNumberInThriceList(List<int> A)
        {
            int first = 0;
            int second = 0;

            foreach (var tmpInt in A)
            {
                first = (first ^ tmpInt) & ~second;
                second = (second ^ tmpInt) & ~first;
            }

            return first;
        }

        private int countSetBits(int n)
        {
            int count = 0;

            while (n > 0)
            {
                n &= (n - 1);
                count++;
            }

            return count;
        }

        //public int cntBits(List<int> A)
        //{
        //    const int MOD = 1000000007;
        //    if (A.Count <= 1)
        //        return 0;

        //    var tmp = 0;

        //    for (int i = 0; i < A.Count - 1; i++)
        //    {
        //        for (int j = i + 1; j < A.Count; j++)
        //        {
        //            if (A[i] == A[j])
        //            {
        //                continue;
        //            }

        //            tmp = (tmp + countSetBits(A[i] ^ A[j])) % MOD;
        //            //tmp = ((tmp % MOD) + (countSetBits(A[i] ^ A[j]) % MOD)) % MOD;
        //        }
        //    }

        //    return (tmp * 2) % MOD;
        //}

        //better solution: change something
        public int cntBits(List<int> A)
        {
            
            long ans = 0;
            // Initialize result
            int n = A.Count;
            long mo = 1000000007;
            // traverse over all bits
            for (int i = 0; i < 31; i++)
            {
                // count number of elements with i'th bit set
                long count = 0;
                for (int j = 0; j < n; j++)
                    if ((A[j] & (1 << i)) != 0)
                        count++;

                // Add "count * (n - count) * 2" to the answer
                ans += (count * (n - count) * 2) % mo;
                if (ans >= mo) ans -= mo;
            }

            return (int)ans;
        }
    }
}





