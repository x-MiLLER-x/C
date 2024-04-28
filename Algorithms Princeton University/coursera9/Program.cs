/*
 Shuffling a linked list. Given a singly-linked list containing n items, rearrange the items uniformly at random. Your 
algorithm should consume a logarithmic (or constant) amount of extra memory and run in time proportional to ⁡
nlogn in the worst case. 
 */
using System;

public class ListNode
{
    public int Value;
    public ListNode Next;

    public ListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

public class ShuffleLinkedList
{
    public static ListNode Shuffle(ListNode head)
    {
        if (head == null || head.Next == null)
            return head;

        // Find the middle of the linked list
        ListNode middle = FindMiddle(head);

        // Split the list into two halves
        ListNode secondHalf = middle.Next;
        middle.Next = null;

        // Recursively shuffle both halves
        ListNode shuffledFirstHalf = Shuffle(head);
        ListNode shuffledSecondHalf = Shuffle(secondHalf);

        // Merge the shuffled halves
        return Merge(shuffledFirstHalf, shuffledSecondHalf);
    }

    private static ListNode FindMiddle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }

    private static ListNode Merge(ListNode first, ListNode second)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (first != null || second != null)
        {
            if (first != null)
            {
                current.Next = first;
                first = first.Next;
                current = current.Next;
            }

            if (second != null)
            {
                current.Next = second;
                second = second.Next;
                current = current.Next;
            }
        }

        return dummy.Next;
    }

    public static void PrintList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        ListNode head = new ListNode(1);
        head.Next = new ListNode(2);
        head.Next.Next = new ListNode(3);
        head.Next.Next.Next = new ListNode(4);
        head.Next.Next.Next.Next = new ListNode(5);

        Console.WriteLine("Original List:");
        PrintList(head);

        head = Shuffle(head);

        Console.WriteLine("Shuffled List:");
        PrintList(head);
    }
}
