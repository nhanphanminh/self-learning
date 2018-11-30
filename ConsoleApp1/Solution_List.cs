using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleApp1
{
    public partial class Solution
    {

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }

        public ListNode reverseBetween(ListNode A, int B, int C)
        {

            var result = A;
            int index = 1;

            // get prosition of reservers(pre_m -> m->n ->next_n
            ListNode startReserver = null, endReserver = null;
            ListNode preStartReserver = null, nextEndReserver = null;

            while (index <= C)
            {
                if (index == B - 1)
                {
                    preStartReserver = A;
                }

                if (index == B)
                {
                    startReserver = A;
                }

                if (index == C)
                {
                    endReserver = A;
                    nextEndReserver = A.next;
                }

                A = A.next;
                index++;

            }

            if (startReserver == null)
            {
                return result;
            }

            //reserver specified range
            var reserverList = new ListNode(startReserver.val);
            var end = reserverList;
            while (startReserver != endReserver && startReserver.next != null)
            {
                startReserver = startReserver.next;
                var tmp = new ListNode(startReserver.val);
                tmp.next = reserverList;
                reserverList = tmp;
            }

            //get result
            if (preStartReserver != null)
            {
                preStartReserver.next = reserverList;
            }
            else
            {
                result = reserverList;
            }

            end.next = nextEndReserver;

            return result;
        }

        public ListNode deleteAllDuplicates(ListNode list)
        {
            if (list == null)
            {
                return null;
            }

            var start = list;
            var isStart = true;
            var pre = start;
            var tmp = list.val;

            while (list?.next != null)
            {

                if (tmp == list.next.val)
                {
                    while (list?.val == tmp)
                    {
                        list = list.next;
                    }

                    if (isStart)
                    {
                        start = list;
                        pre = start;
                    }
                    else
                    {
                        pre.next = list;
                    }

                    if (list == null)
                    {
                        return start;
                    }

                    tmp = list.val;
                }
                else
                {
                    pre = list;
                    list = list.next;
                    tmp = list.val;
                    isStart = false;
                }
            }

            return start;
        }

        public int lPalin(ListNode A)
        {
            if (A == null || A.next == null)
                return 1;

            var B = new ListNode(A.val);

            var A1 = A;

            while (A1.next != null)
            {
                A1 = A1.next;
                var tmp = new ListNode(A1.val);
                tmp.next = B;
                B = tmp;
            }

            while (A.next != null)
            {
                if (A.val != B.val)
                    return 0;
                A = A.next;
                B = B.next;
            }

            return 1;
        }

        public ListNode deleteDuplicates(ListNode A)
        {
            var start = A;

            while (A.next != null)
            {
                if (A.val == A.next.val)
                {
                    A.next = A.next.next;
                }
                else
                {
                    A = A.next;
                }
            }

            return start;
        }

        public int findMinXor(List<int> A)
        {
            if (A.Count <= 1)
            {
                throw new InvalidEnumArgumentException("list must be contain more than 2 numbers.");
            }

            if (A.Count == 2)
            {
                return A[0] ^ A[1];
            }

            var min = int.MaxValue;
            A.Sort();

            for (int i = 1; i < A.Count; i++)
            {
                var tmp = A[i] ^ A[i - 1];

                if (tmp < min)
                {
                    min = tmp;
                }

            }

            return min;
        }

        public ListNode mergeTwoLists(ListNode A, ListNode B)
        {
            if (A == null)
            {
                return B;
            }
            else if (B == null)
            {
                return B;
            }

            ListNode start = null;
            if (A.val > B.val)
            {
                start = B;
                B = B.next;
            }
            else
            {
                start = A;
                A = A.next;
            }

            var tmp = start;

            while (A != null && B != null)
            {
                if (A.val > B.val)
                {
                    tmp.next = B;
                    tmp = tmp.next;
                    B = B.next;
                }
                else
                {
                    tmp.next = A;
                    tmp = tmp.next;
                    A = A.next;
                }
            }

            if (A != null)
            {
                tmp.next = A;
            }
            else
            {
                tmp.next = B;
            }

            return start;
        }

        //Given 1->2->3->4->5->NULL and k = 2,
        //return 4->5->1->2->3->NULL.
        public ListNode rotateRight(ListNode A, int B)
        {
            if (A == null || B == 0)
                return A;

            if (A.next == null)
                return A;

            var start = A;

            var n = countNode(A);
            B = B % n;

            for (int i = 0; i < B; i++)
            {
                while (A.next.next != null)
                {
                    A = A.next;
                }

                var last = A.next;
                A.next = null;
                last.next = start;

                A = last;
                start = A;
            }

            return start;
        }

        public ListNode removeNthFromEnd(ListNode A, int B)
        {
            if (A == null)
                return null;

            if (B == 0)
                return A;

            var N = countNode(A);

            var start = A;

            //remove 1st node
            if (N <= B)
            {
                return start.next;
            }

            var nth = N - B;
            var index = 1;

            while (index < nth)
            {
                A = A.next;
                index++;
            }

            A.next = A.next.next;

            return start;
        }

        public ListNode InsertNthFromStart(ListNode A, int value, int B)
        {
            if (A == null)
                return null;

            if (B == 0)
                return A;

            var index = 1;
            var start = A;
            while (index < B)
            {
                A = A.next;
                index++;
            }

            ListNode next = A.next;

            A.next = new ListNode(value);
            A.next.next = next;

            return start;
        }

        private int countNode(ListNode A)
        {
            if (A == null)
                return 0;

            var tmp = 0;
            while (A != null)
            {
                A = A.next;
                tmp++;
            }

            return tmp;
        }

        //L0 → Ln → L1 → Ln-1 → L2 → Ln-2 → …
        public ListNode reorderList(ListNode A)
        {
            var N = countNode(A);

            if (N <= 2)
            {
                return A;
            }

            var rs = new ListNode(A.val);
            var index = 1;
            var tmp = rs;
            while (index <= N / 2)
            {

                A = A.next;
                tmp.next = new ListNode(A.val);
                tmp = tmp.next;
                index++;
            }

            if (N % 2 == 0)
                index -= 2;
            else
                index--;

            while (A.next != null)
            {
                A = A.next;
                rs = InsertNthFromStart(rs, A.val, index);
                index--;
            }

            return rs;
        }


        ////Re-order list -better solution
        //private ListNode reverse(ListNode head)
        //{
        //    if (head == null || head.next == null) return head;
        //    var pre = head;
        //    var curr = head.next;
        //    while (curr != null)
        //    {
        //        var t = curr.next;
        //        curr.next = pre;
        //        pre = curr;
        //        curr = t;
        //    }
        //    head.next = null;
        //    return pre;
        //}

        //public ListNode reorderList(ListNode head)
        //{
        //    if (head == null || head.next == null) return head;

        //    // split
        //    var slow = head;
        //    var fast = head;
        //    while (fast != null && fast.next != null && fast.next.next != null)
        //    {
        //        slow = slow.next;
        //        fast = fast.next.next;
        //    }

        //    var secondHead = slow.next;
        //    slow.next = null;

        //    // reverse second list
        //    secondHead = reverse(secondHead);

        //    // merge two lists
        //    var p1 = head;
        //    var p2 = secondHead;
        //    while (p2 != null)
        //    {
        //        var t1 = p1.next;
        //        var t2 = p2.next;

        //        p1.next = p2;
        //        p2.next = t1;

        //        p1 = t1;
        //        p2 = t2;
        //    }
        //    return head;
        //}

        //Sum 2 numbers

        private ListNode RemoveZerosTails(ListNode rs)
        {
            var start = rs;
            ListNode preZeros = null;

            while (rs.next != null)
            {
                if (rs.next.val == 0 && preZeros == null)
                {
                    preZeros = rs;
                }
                else if (rs.next.val != 0)
                {
                    preZeros = null;
                }

                rs = rs.next;
            }

            if (preZeros != null)
            {
                preZeros.next = null;
            }

            return start;
        }

        public ListNode addTwoNumbers(ListNode A, ListNode B)
        {
            if (A == null)
                return B;

            if (B == null)
                return A;

            ListNode rs = null, rsTail = null;
            int remember = 0;

            while (A != null && B != null)
            {
                var sum = A.val + B.val + remember;
                var value = sum % 10;
                remember = sum >= 10 ? 1 : 0;
                var tmp = new ListNode(value);
                if (rs == null)
                {
                    rs = tmp;
                    rsTail = tmp;
                }
                else
                {
                    rsTail.next = tmp;
                    rsTail = tmp;
                }

                A = A.next;
                B = B.next;
            }

            while (A != null)
            {
                var sum = A.val + remember;
                var value = sum % 10;
                remember = sum >= 10 ? 1 : 0;
                var tmp = new ListNode(value);
                rsTail.next = tmp;
                rsTail = tmp;
                A = A.next;
            }

            while (B != null)
            {
                var sum = B.val + remember;
                var value = sum % 10;
                remember = sum >= 10 ? 1 : 0;
                var tmp = new ListNode(value);
                rsTail.next = tmp;
                rsTail = tmp;
                B = B.next;
            }

            if (remember != 0)
            {
                var tmp = new ListNode(remember);
                rsTail.next = tmp;
                return rs;
            }

            if (rsTail.val == 0)
            {
                rs = RemoveZerosTails(rs);
            }

            return rs;
        }

        public ListNode swapNode(ListNode A, ListNode preNode = null)
        {
            if (A == null || A.next == null)
                return preNode;

            var tmp = A.next;
            var last = A.next.next;
            A.next = last;
            tmp.next = A;

            if (preNode == null)
            {
                return tmp;
            }

            preNode.next = tmp;
            return preNode;
        }

        public ListNode swapPairs(ListNode A)
        {
            if (A == null || A.next == null)
            {
                return A;
            }

            ListNode start = null;
            ListNode preNode = null;
            while (A != null)
            {
                var swapped = swapNode(A, preNode);
                if (start == null)
                {
                    start = swapped;
                }

                if (swapped.next == null || swapped.next.next == null)
                {
                    return start;
                }

                preNode = preNode == null ? swapped.next : swapped.next.next;
                A = preNode.next;
            }

            return start;
        }

        public void swapNodeValues(ref ListNode A, ref ListNode B)
        {
            if (A == null || B == null)
                return;

            var tmp = A.val;
            A.val = B.val;
            B.val = tmp;
        }

        public ListNode sortList(ListNode A)
        {
            if (A == null || A.next == null)
            {
                return A;
            }

            var start = A;
            var i = A;
            while (i.next != null)
            {
                var j = i.next;
                while (j != null)
                {
                    if (i.val > j.val)
                    {
                        swapNodeValues(ref i, ref j);
                    }

                    j = j.next;
                }

                i = i.next;
            }

            return start;
        }
        #region MergeSort List
        //Merge Sort List
        //public ListNode sortList(ListNode list)
        //{
        //    if (list == null) return null;
        //    if (list.next == null) return list;

        //    var slow = list;
        //    var preSlow = list;
        //    var fast = list;

        //    // Find middle node of the list by keeping track of it's previous node
        //    while (fast != null && fast.next != null)
        //    {
        //        preSlow = slow;
        //        slow = slow.next;
        //        fast = fast.next.next;
        //    }

        //    // Separate list in two parts (first is list, second is slow)
        //    preSlow.next = null;

        //    // Call recursively sort and merge results
        //    return MergeSortedLists(sortList(list), sortList(slow));
        //}

        //private ListNode MergeSortedLists(ListNode first, ListNode second)
        //{
        //    if (first == null) return second;
        //    if (second == null) return first;
        //    if (first == null && second == null) return null;

        //    var dummy = new ListNode(-1);
        //    var tail = dummy;

        //    while (first != null && second != null)
        //    {
        //        if (first.val < second.val)
        //        {
        //            tail.next = first;
        //            first = first.next;
        //        }
        //        else
        //        {
        //            tail.next = second;
        //            second = second.next;
        //        }
        //        tail = tail.next;
        //    }

        //    tail.next = first ?? second;

        //    return dummy.next;
        //}

        #endregion MergeSort List


        //Given 1->4->3->2->5->2 and x = 3,
        //return 1->2->2->4->3->5.
        public ListNode inserNode(ListNode A, int value, bool isAccending)
        {
            if (A == null)
                return new ListNode(value);

            var start = A;
            ListNode pre = null, next = null;

            while (A != null)
            {
                if (isAccending)
                {
                    if (A.val >= value || A.next == null)
                    {
                        pre = A;
                        next = pre.next;
                        break;
                    }
                }
                else
                {
                    if (A.val <= value || A.next == null)
                    {

                        pre = A;
                        next = pre.next;
                        break;
                    }
                }

                A = A.next;
            }

            //if (A.next == null)
            //{
            //    A.next = new ListNode(value);
            //}
            //else
            //{
            if (pre == null)
            {
                var tmp = new ListNode(value);
                tmp.next = start;
                start = tmp;
            }
            else
            {
                var tmp = new ListNode(value);
                pre.next = tmp;
                tmp.next = next;
            }
            //}

            return start;
        }

        public ListNode partition(ListNode A, int B)
        {
            ListNode before = null;
            ListNode after = null;

            while (A != null)
            {
                if (A.val <= B)
                {
                    before = inserNode(before, A.val, true);
                }
                else
                {
                    after = inserNode(after, A.val, false);
                }

                A = A.next;
            }

            if (before == null)
            {
                return after;
            }

            var tmp = before;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = after;
            return before;
        }
    }
}





