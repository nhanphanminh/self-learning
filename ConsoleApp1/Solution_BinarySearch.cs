using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Solution
    {
        public void InsertList(List<int> list, int a)
        {
            var index = list.Count / 2;
            //if(index)
        }

        public int findMedian(List<List<int>> A)
        {
            var N = A.Count;
            var M = A[0].Count;
            var list = new List<int>();

            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    //InsertList(list, A[i][j]);
                    list.Add(A[i][j]);
            list.Sort();
            return list[(N * M) / 2];
        }


        public bool IsPossible(List<int> arr, int m, int currMin)
        {
            var currSum = 0;
            var painter = 1;

            for (var i = 0; i < arr.Count; i++)
            {
                if (arr[i] > currMin)
                    return false;

                if (currSum + arr[i] > currMin)
                {
                    painter++;
                    currSum = arr[i];

                    if (painter > m)
                        return false;
                }
                else
                {
                    currSum += arr[i];
                }
            }

            return true;
        }

        public int paint(int m, int b, List<int> arr)
        {
            var sum = 0;

            for (var i = 0; i < arr.Count; i++)
                sum += arr[i];

            var start = 0;
            var end = sum;
            var result = int.MaxValue;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (IsPossible(arr, m, mid))
                {
                    result = Math.Min(mid, result);
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return (int)(((long)result * b) % 10000003);
        }

        public int books(List<int> A, int B)
        {
            return FindPages(A.ToArray(), A.Count, B);
        }
        bool IsPossible(int[] pages, int numberOfBooks, int numberOfStudents, int halfOfTotalPages)
        {
            int studentsRequired = 1;
            int curr_sum = 0;

            // iterate over all books
            for (int i = 0; i < numberOfBooks; i++)
            {
                // check if current number of pages are greater
                // than curr_min that means we will get the result
                // after mid no. of pages
                if (pages[i] > halfOfTotalPages)
                    return false;

                // count how many students are required
                // to distribute curr_min pages
                if (curr_sum + pages[i] > halfOfTotalPages)
                {
                    // increment student count
                    studentsRequired++;

                    // update curr_sum
                    curr_sum = pages[i];

                    // if students required becomes greater
                    // than given no. of students,return false
                    if (studentsRequired > numberOfStudents)
                        return false;
                }

                // else update curr_sum
                else
                    curr_sum += pages[i];
            }
            return true;
        }

        // function to find minimum pages
        public int FindPages(int[] pages, int numberOfBooks, int numberOfStudents)
        {
            int totalPages = 0;

            // return -1 if no. of books is less than
            // no. of students
            if (numberOfBooks < numberOfStudents)
                return -1;

            // Count total number of pages
            for (int i = 0; i < numberOfBooks; i++)
                totalPages += pages[i];

            // initialize start as 0 pages and end as
            // total pages
            int start = 0, end = totalPages;
            int result = int.MaxValue;

            // traverse until start <= end
            while (start <= end)
            {
                // check if it is possible to distribute
                // books by using mid is current minimum
                int halfOfTotalPages = (start + end) / 2;
                if (IsPossible(pages, numberOfBooks, numberOfStudents, halfOfTotalPages))
                {
                    // if yes then find the minimum distribution
                    result = Math.Min(result, halfOfTotalPages);

                    // as we are finding minimum and books
                    // are sorted so reduce end = mid -1
                    // that means
                    end = halfOfTotalPages - 1;
                }

                else
                    // if not possible means pages should be
                    // increased so update start = mid + 1
                    start = halfOfTotalPages + 1;
            }

            // at-last return minimum no. of  pages
            return result;
        }
    }
}

