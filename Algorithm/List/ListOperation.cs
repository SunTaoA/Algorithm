using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }

    class ListOperation
    {
        /// <summary>
        /// merge two list, assume each list has increase progressively node 
        /// </summary>
        /// <param name="pHead1"></param>
        /// <param name="pHead2"></param>
        /// <returns></returns>
        public ListNode Merge(ListNode pHead1, ListNode pHead2)
        {
            ListNode retHead = null;
            ListNode ret = null;// write code here
            if (pHead1 == null && pHead2 == null)
                return ret;

            if (pHead1 == null && pHead2 != null)
            {
                ret = pHead2;
                return ret;
            }

            if (pHead1 != null && pHead2 == null)
            {
                ret = pHead1;
                return ret;
            }

            bool bHead = true;
            while (pHead1 != null && pHead2 != null)
            {
                if (pHead1.val < pHead2.val)
                {

                    if (bHead)
                    {
                        ret = pHead1;
                        retHead = ret;
                    }
                    else
                    { 
                        ret.next = pHead1;
                        ret = ret.next;
                    }
                    pHead1 = pHead1.next;
                }
                else
                {
                    if (bHead)
                    {
                        ret = pHead2;
                        retHead = ret;
                    }
                    else
                    { 
                        ret.next = pHead2;
                        ret = ret.next;
                    }
                    
                    pHead2 = pHead2.next;
                }
                bHead = false;
            }

            if (pHead1 != null) ret.next = pHead1;
            if (pHead2 != null) ret.next = pHead2;

            return retHead;
        }

        // Find K node from the rear
        public ListNode FindKthToTail(ListNode head, int k)
        {
            int i = 0;
            ListNode cal = head;
            while (cal!=null)
            {
                i++;
                cal = cal.next; 
            }

            int j = i - k + 1;
            for (int start = 1; start < j; start++)
                head = head.next;

            return head;// write code here
        }

        //Reverse a list
        public ListNode ReverseList(ListNode pHead)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            while (pHead != null)
            {
                stack.Push(pHead);
                pHead = pHead.next;
            }

            ListNode ret = null;
            ListNode start = null;
            while(stack.Count > 0)
            {
                if (ret == null)
                {
                    ret = stack.Pop();
                    start = ret;
                }
                else
                {
                    ret.next = stack.Pop();
                    ret = ret.next;
                }
            }

            if (ret != null) ret.next = null;

            return start;
        }

        //Link list clone example
        public class RandomListNode
        {
            public int label;
            public RandomListNode next, random;
            public RandomListNode(int x)
            {
                this.label = x;
            }
        }

        RandomListNode cloneHead = null;
        public RandomListNode Clone(RandomListNode pHead)
        {
            if (pHead == null) return null;

            RandomListNode cur = null;
            cur = new RandomListNode(pHead.label);
            cloneHead = cur;
            if (pHead.random != null)
                cur.random = new RandomListNode(pHead.random.label);

            pHead = pHead.next;
            while (pHead != null)
            {
                cur.next = new RandomListNode(pHead.label);
                if (pHead.random != null)
                    cur.next.random = new RandomListNode(pHead.random.label);

                pHead = pHead.next;
                cur = cur.next;
            }

            return cloneHead;
        }

        //Find first intersection node of two different  link list
        public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
        {
            //ListNode pHeadHelp = pHead2;
            while (pHead1 != null)
            {
                ListNode pHeadHelp = pHead2;
                while (pHeadHelp != null)
                {
                    if (pHead1 == pHeadHelp)
                        return pHead1;
                    else
                    {
                        pHeadHelp = pHeadHelp.next;
                    }
                }
                pHead1 = pHead1.next;
            }
            return null;
        }
    }

    
}
