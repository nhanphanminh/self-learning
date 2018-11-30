namespace ConsoleApp1.Extensions
{
    public static class StriiingExtention
    {
        public static int Length(this string str)
        {
            return str.Length;
        }

        public static int Length(this string str, int a)
        {
            return str.Length - a;
        }
    }
}
