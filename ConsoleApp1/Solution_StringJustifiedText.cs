using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public partial class Solution
    {

        //words: ["This", "is", "an", "example", "of", "text", "justification."]

        //L: 16.

        //Return the formatted lines as:

        //[
        //"This    is    an",
        //"example  of text",
        //"justification.  "
        //]
        public List<string> fullJustify(List<string> A, int B)
        {
            var start = 0;
            var end = 0;
            var result = new List<string>();

            while (end < A.Count)
            {
                if (A[end].Length > B)
                {
                    return new List<string>();
                }
                var sentence = new StringBuilder();
                var totalLength = 0;
                var numOfWord = 0;
                var totalWordLength = 0;
                while (end < A.Count && A[end].Length + totalLength + 1 <= B)
                {
                    totalLength += A[end].Length;
                    totalWordLength += A[end].Length;
                    end++;
                    numOfWord++;
                    if (numOfWord > 1)
                        totalLength++;
                }

                var numOfSpace = B - totalWordLength;
                var numOfWordsSpace = numOfWord > 1 ? numOfWord - 1 : 1;
                var addedSpace = numOfSpace / numOfWordsSpace;
                var remain = numOfSpace % numOfWordsSpace;

                totalLength = B;
                for (int i = start; i < end; i++)
                {
                    sentence = sentence.Append(A[i]);
                    totalLength -= A[i].Length;
                    var addSpace = remain > 0 ? addedSpace + 1 : addedSpace;
                    if (end >= A.Count)
                        addSpace = 1;

                    remain--;
                    if (totalLength > 0)
                    {
                        sentence.Append(' ', addSpace);
                        totalLength -= addSpace;
                    }
                }

                if (end >= A.Count)
                {
                    sentence.Append(' ', totalLength);
                }

                result.Add(sentence.ToString());

                start = end;
            }

            return result;
        }
    }
}


