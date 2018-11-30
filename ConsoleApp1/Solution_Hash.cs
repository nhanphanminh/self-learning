using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public partial class Solution
    {
        private int getProduct(string A)
        {
            if (A.Length <= 1)
                return int.Parse(A);

            var tmp = 1;
            for (int i = 0; i < A.Length; i++)
            {
                var num = (int)char.GetNumericValue(A[i]);
                tmp *= num;
            }

            return tmp;
        }

        private int colorful(string A)
        {
            List<int> products = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 1; j <= A.Length - i; j++)
                {
                    var tmp = A.Substring(i, j);
                    var product = getProduct(tmp);
                    if (!products.Contains(product))
                    {
                        products.Add(product);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            return 1;
        }

        public int colorful(int A)
        {
            return colorful(A.ToString());
        }

        public List<List<int>> fourSum1(List<int> A, int B)
        {
            if (A.Count < 4)
            {
                return new List<List<int>>();
            }

            A.Sort();

            var rs = new List<List<int>>();
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < A.Count - 3; i++)
            {
                for (int j = i + 1; j < A.Count - 2; j++)
                {
                    for (int k = j + 1; k < A.Count - 1; k++)
                    {
                        for (int x = k + 1; x < A.Count; x++)
                        {
                            if (A[i] + A[j] + A[k] + A[x] == B)
                            {
                                var tmp = A[i].ToString() + A[j] + A[k] + A[x];

                                if (dict.ContainsKey(tmp))
                                {
                                    continue;
                                }
                                else
                                {
                                    dict.Add(tmp, B);
                                    rs.Add(new List<int> { A[i], A[j], A[k], A[x] });
                                }
                            }
                        }
                    }
                }
            }

            return rs;
        }

        public List<List<int>> fourSum(List<int> A, int target)
        {
            if (A.Count < 4)
            {
                return new List<List<int>>();
            }

            var rs = new List<List<int>>();
            var dict = new Dictionary<string, int>();
            var B = new List<int>();
            A.Sort();

            for (int i = 0; i < A.Count - 3; i++)
            {
                B.Add(target - A[i]);
            }

            for (int i = 0; i < A.Count - 3; i++)
            {
                var j = i + 1;
                while (j < A.Count - 2 && B[i] >= A[j])
                {
                    var sum2 = B[i] - A[j];
                    var k = j + 1;

                    while (k < A.Count - 1 && A[k] <= sum2)
                    {

                        var x = k + 1;
                        var sum3 = sum2 - A[k];
                        while (x < A.Count && A[x] <= sum3)
                        {
                            if (A[x] == sum3)
                            {
                                var tmp1 = A[i].ToString() + A[j] + A[k] + A[x];
                                if (!dict.ContainsKey(tmp1))
                                {
                                    dict.Add(tmp1, target);
                                    rs.Add(new List<int> { A[i], A[j], A[k], A[x] });
                                }
                            }

                            x++;
                        }

                        k++;
                    }

                    j++;
                }
            }

            return rs;
        }

        public List<int> lszero(List<int> A)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();
            int minIndex = -1, length = 0;


            int[] ar = A.ToArray();
            int sum = 0;
            map.Add(0, -1);

            for (int i = 0; i < A.Count; i++)
            {
                sum += ar[i];

                if (map.ContainsKey(sum))
                {
                    int val = map[sum];
                    int clen = val == -1 ? i + 1 : i - val;
                    if (length < clen)
                    {
                        minIndex = val + 1;
                        length = clen;
                    }

                }

                if (!map.ContainsKey(sum))
                {
                    map[sum] = i;
                }
            }

            List<int> ans = new List<int>();

            for (int i = 0; i < length; i++)
            {
                ans.Add(ar[minIndex + i]);
            }

            return ans;
        }

        public List<int> twoSum(List<int> A, int B)
        {
            var c = new List<int>();
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < A.Count; i++)
            {
                var tmp = B - A[i];
                c.Add(tmp);

                if (dict.ContainsKey(tmp))
                {
                    var j = dict[tmp];
                    i++;
                    j++;
                    return i > j ? new List<int> { j, i } : new List<int> { i, j };
                }

                if (!dict.ContainsKey(A[i]))
                    dict.Add(A[i], i);
            }

            return new List<int>();
        }

        //A : [ 11, 85, 100, 44, 3, 32, 96, 72, 93, 76, 67, 93, 63, 5, 10, 45, 99, 35, 13 ]
        //B : 60
        public int diffPossible2(List<int> A, int B)
        {
            var C = new List<int>();
            for (int i = 0; i < A.Count - 1; i++)
            {
                for (int j = i + 1; j < A.Count; j++)
                {
                    if (Math.Abs(A[i] - A[j]) == B)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public int diffPossible1(List<int> A, int B)
        {
            var C = new Dictionary<int, List<int>>();

            for (int i = 0; i < A.Count; i++)
            {
                var key = A[i] - B;
                List<int> values;
                if (C.TryGetValue(key, out values))
                {
                    values.Add(i);
                }
                else
                {
                    C.Add(key, new List<int> { i });
                }
            }

            for (int i = 0; i < A.Count; i++)
            {
                List<int> values;
                if (C.TryGetValue(A[i], out values))
                {
                    if (values.Exists(j => j != i))
                        return 1;
                }
            }

            return 0;
        }

        private string GetKey(string A)
        {
            if (string.IsNullOrEmpty(A))
            {
                return string.Empty;
            }

            var c = A.ToList();
            c.Sort();

            var key = string.Empty;
            var i = 0;
            while (i < c.Count)
            {
                var tmp = 1;
                while (i + 1 < c.Count && c[i] == c[i + 1])
                {
                    tmp++;
                    i++;
                }

                key += tmp.ToString() + c[i];
                i++;
            }

            return key;
        }

        public List<List<int>> anagrams(List<string> A)
        {
            var dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < A.Count; i++)
            {
                var key = GetKey(A[i]);
                List<int> values;

                if (dict.TryGetValue(key, out values))
                {
                    values.Add(i + 1);
                }
                else
                {
                    dict.Add(key, new List<int> { i + 1 });
                }
            }

            return dict.Values.ToList();
        }

        private int isLargerThan(List<int> current, List<int> next)
        {
            if (!current.Any())
                return 1;

            if (current[0] > next[0])
                return 1;

            if (current[0] < next[0])
                return -1;

            if (current[1] > next[1])
                return 1;
            if (current[1] < next[1])
                return -1;

            if (current[2] > next[2])
                return 1;
            if (current[2] < next[2])
                return -1;

            if (current[3] > next[3])
                return 1;
            if (current[3] < next[3])
                return -1;

            return 0;
        }

        public List<int> equal(List<int> A)
        {
            var sumsDict = new Dictionary<int, List<int>>();
            var rs = new List<int>();
            for (int i = 0; i < A.Count - 1; i++)
            {
                for (int j = i + 1; j < A.Count; j++)
                {
                    var tmp = A[i] + A[j];
                    List<int> values;

                    if (!sumsDict.TryGetValue(tmp, out values))
                    {
                        values = new List<int> { i, j };
                        sumsDict.Add(tmp, values);
                    }
                    else
                    {
                        if (values.Any())
                        {
                            if (!values.Contains(i) && !values.Contains(j))
                            {
                                values.Add(i);
                                values.Add(j);
                                if (isLargerThan(rs, values) == 1)
                                {
                                    rs = values.ToList();
                                }
                            }


                        }
                        else
                        {
                            values.Add(i);
                            values.Add(j);
                        }
                    }

                }
            }

            return rs;
        }

        public class CharInfor
        {
            public int NumOfCharacter = 0;
            public bool IsContinue = true;
            public Dictionary<char, int> DictChars = new Dictionary<char, int>();
        }

        public int lengthOfLongestSubstring(string A)
        {
            if (string.IsNullOrEmpty(A))
            {
                return 0;
            }

            var max = 0;

            var index = 0;
            var listInfo = new List<CharInfor>();
            var tmp = 0;

            while (index < A.Length)
            {
                listInfo.Add(new CharInfor());

                for (int i = tmp; i < listInfo.Count; i++)
                {
                    var info = listInfo[i];

                    if (!info.IsContinue)
                    {
                        continue;
                    }

                    if (info.DictChars.ContainsKey(A[index]))
                    {
                        info.IsContinue = false;

                        if (max < info.NumOfCharacter)
                        {
                            max = info.NumOfCharacter;
                        }

                        tmp = i;
                    }
                    else
                    {
                        info.DictChars.Add(A[index], 0);
                        info.NumOfCharacter++;
                    }

                    if (max < info.NumOfCharacter)
                    {
                        max = info.NumOfCharacter;
                    }
                }

                index++;
            }

            return max;
        }


        public string minWindow(string A, string B)
        {
            int len1 = A.Length;
            int len2 = B.Length;

            int minLen = int.MaxValue;
            int finalStart = 0;
            int[] dp = new int[256];
            for (int i = 0; i < len2; i++)
            {
                dp[B[i]]++;
            }

            int start = 0;
            int end = 0;
            int count = len2;

            while (end < len1)
            {
                if (dp[A[end]] > 0)
                {
                    count--;
                }

                dp[A[end]]--;

                while (count == 0)
                {
                    if (end - start + 1 < minLen)
                    {
                        finalStart = start;
                        minLen = end - start + 1;
                    }

                    dp[A[start]]++;
                    if (dp[A[start]] > 0)
                    {
                        count++;
                    }

                    start++;
                }

                end++;
            }

            if (minLen == Int32.MaxValue)
            {
                return "";
            }

            return A.Substring(finalStart, minLen);
        }

        public string fractionToDecimal(int a, int b)
        {
            bool isNegative = (a > 0 && b < 0) || (a < 0 && b > 0);
            long A = a > 0 ? (long)a : (long)0 - (long)a;
            long B = b > 0 ? (long)b : (long)0 - (long)b;
            var mapRem = new Dictionary<long, int>();


            long div = (long)A / (long)B;
            var result = div.ToString();
            if (isNegative)
                result = "-" + result;
            var remain = (long)A % (long)B;
            var fraction = new StringBuilder(".");
            var repeatIndex = 0;

            while (remain != 0 && !mapRem.ContainsKey(remain))
            {
                mapRem.Add(remain, repeatIndex);
                remain *= 10;
                div = remain / B;
                fraction.Append(div.ToString());
                remain = remain % B;
                repeatIndex++;
            }

            if (mapRem.TryGetValue(remain, out repeatIndex))
            {
                repeatIndex++;
                var repeat = fraction.ToString(repeatIndex, fraction.Length - repeatIndex);
                return result + fraction.ToString(0, repeatIndex) + "(" + repeat + ")";
            }

            if (fraction.ToString() == ".")
                return result;

            return result + fraction.ToString();
        }
        public List<int> findSubstring(string A, List<string> B)
        {
            int nWords = B.Count;
            int aWordLength = B[0].Length;
            int wordsLength = nWords * aWordLength;
            var idxs = new List<int>();
            var countDict = B.GroupBy(iden => iden)
                .ToDictionary(g => g.Key, g => g.Count());

            for (var i = 0; i <= A.Length - wordsLength; i++)
            {
                var tmp = new List<string>();
                for (var j = 0; j < nWords; j++)
                {
                    tmp.Add(A.Substring(i + j * aWordLength, aWordLength));
                }
                var dict = tmp.GroupBy(iden => iden)
                    .ToDictionary(g => g.Key, g => g.Count());

                if (dict.Count == countDict.Count && !countDict.Except(dict).Any())
                    idxs.Add(i);
            }

            return idxs;
        }
    }
}





