using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public partial class Solution
    {
        int getNumFromChar(char c)
        {
            return (int)char.GetNumericValue(c);
        }

        int multi2Char(char a, char b)
        {
            return getNumFromChar(a) * getNumFromChar(b);
        }

        int sum2Char(char a, char b)
        {
            return getNumFromChar(a) + getNumFromChar(b);
        }

        string multiStringWithChar(string a, char b)
        {
            if (b == '0')
                return "0";

            if (a.All(x => x == '0'))
                return "0";

            if (b == '1')
                return a;

            var result = new StringBuilder();
            var remain = 0;

            for (int i = a.Length - 1; i >= 0; i--)
            {
                var total = multi2Char(a[i], b) + remain;
                result.Insert(0, (total % 10).ToString());
                remain = total / 10;
            }

            if (remain >= 1)
                return result.Insert(0, remain).ToString();

            return result.ToString();
        }

        public string sum2String(string a, string b)
        {
            if (b.All(x => x == '0'))
                b = "0";

            if (a.All(x => x == '0'))
                a = "0";

            var larger = a.Length >= b.Length ? a : b;
            var smaller = a.Length >= b.Length ? b : a;
            var min = Math.Min(a.Length, b.Length);
            var max = Math.Max(a.Length, b.Length);
            var result = new StringBuilder();
            var remain = 0;
            var maxIndex = max - 1;
            var minIdex = min - 1;
            while (maxIndex >= 0)
            {
                var smallNum = minIdex >= 0 ? smaller[minIdex] : '0';
                var total = sum2Char(larger[maxIndex], smallNum) + remain;
                var numStr = (total % 10).ToString();
                result.Insert(0, numStr);
                remain = total / 10;
                maxIndex--;
                minIdex--;
            }

            if (remain >= 1)
                result.Insert(0, remain);

            return result.ToString();
        }

        public string multiply(string A, string B)
        {
            A = A.TrimStart('0');
            B = B.TrimStart('0');
            var result = "0";
            var remain = 0;
            int multi = 0;
            var maxIndex = B.Length - 1;
            while (maxIndex >= 0)
            {
                var total = multiStringWithChar(A, B[maxIndex]);

                for (int i = 0; i < multi; i++)
                    total = total + '0';

                result = sum2String(result, total);
                maxIndex--;
                multi++;
            }


            if (A.All(x => x == '0'))
                return "0";

            return result;
        }

        public string DivideBy2(string A)
        {
            var result = new StringBuilder();
            var remain = 0;
            var next = string.Empty;
            var index = 0;
            if (A[0] < '2' && A.Length >= 2)
            {
                next = A.Substring(0, 2);
                index = 2;
            }
            else
            {
                next = A.Substring(0, 1);
                index = 1;
            }

            while (index < A.Length)
            {
                var num = int.Parse(next) + remain;
                var nextNum = num / 2;
                remain = (num % 2) * 10;
                result.Append(nextNum);

                next = A.Substring(index, 1);
                index++;
            }

            var num1 = (int.Parse(next) + remain) / 2;
            result.Append(num1);
            return result.ToString();
        }

        public int power(string A)
        {
            A = A.Trim();

            if (A == "1" || A == "0")
                return 0;

            while (A != "1")
            {
                if (getNumFromChar(A[A.Length - 1]) % 2 != 0)
                    return 0;

                A = DivideBy2(A);
            }

            return 1;
        }
    }
}

