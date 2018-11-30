namespace ConsoleApp1
{
    public partial class Solution
    {
        //A message containing letters from A-Z is being encoded to numbers using the following mapping:

        //'A' -> 1
        //'B' -> 2
        //...
        //'Z' -> 26
        //Given an encoded message containing digits, determine the total number of ways to decode it.

        //    Example :

        //Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

        //The number of ways decoding "12" is 2.
        public int numDecodings(string A)
        {
            if (string.IsNullOrEmpty(A))
            {
                return 0;
            }

            if (A.Length <= 2)
            {
                int tmp;

                if (!int.TryParse(A, out tmp))
                {
                    return 0;
                }

                if (tmp <= 0)
                {
                    return 0;
                }



                if (tmp > 10 && tmp <= 26)
                {
                    if (tmp % 10 == 0)
                    {
                        return 1;
                    }

                    return 2;
                }

                if (tmp > 26 && tmp % 10 == 0)
                {
                    return 0;
                }

                return 1;
            }

            var result = 0;

            if (A[0] == '0')
            {
                return 0;
            }

            var str = A.Substring(0, 2);

            if (!int.TryParse(str, out var tmpNUm))
            {
                return 0;
            }

            if (tmpNUm == 10)
            {
                return numDecodings(A.Substring(2));
            }
            else if (tmpNUm > 10 && tmpNUm <= 26)
            {
                if (tmpNUm == 20)
                {
                    result += numDecodings(A.Substring(1));
                }
                else
                {
                    var rs1 = numDecodings(A.Substring(1));
                    //if (rs1 == 0)
                    //{
                    //    return 0;
                    //}

                    var rs2 = numDecodings(A.Substring(2));
                    result += rs1 + rs2;
                }

            }
            else if (tmpNUm >= 27)
            {
                if (tmpNUm % 10 == 0)
                {
                    return 0;
                }

                return numDecodings(A.Substring(1));
            }
            else
            {
                return 0;
            }

            return result;
        }
    }
}





