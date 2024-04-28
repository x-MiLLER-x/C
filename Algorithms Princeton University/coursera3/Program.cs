/*
 Successor with delete. Given a set of n integers ={0,1,...,−1}S={0,1,...,n−1} and a sequence of requests of the 
following form:

Remove x from S

Find the successor of x: the smallest y in S such that y≥x.

design a data type so that all operations (except construction) take logarithmic time or better in the worst case
 */
using System;
using System.Collections.Generic;

public class SuccessorWithDelete
{
    private SortedSet<int> elements; // Sorted set to maintain elements
    private List<int> removedElements; // List to maintain removed elements

    public SuccessorWithDelete(int n)
    {
        elements = new SortedSet<int>();
        removedElements = new List<int>(n);

        // Add all integers from 0 to n-1 initially
        for (int i = 0; i < n; i++)
        {
            elements.Add(i);
        }
    }

    public void Remove(int x)
    {
        if (!elements.Contains(x))
        {
            throw new InvalidOperationException("Element not found.");
        }

        // Remove x from the elements set and add it to the removed elements list
        elements.Remove(x);
        removedElements.Add(x);
    }

    public int FindSuccessor(int x)
    {
        if (x < 0 || x >= elements.Count)
        {
            throw new InvalidOperationException("Invalid input.");
        }

        // Check if x is in the removed elements list
        if (removedElements.Contains(x))
        {
            return x; // x itself is the successor
        }

        // Find the smallest element greater than or equal to x in the elements set
        SortedSet<int> ViewtailSet = elements.GetViewBetween(x, elements.Max);
        if (ViewtailSet.Count > 0)
        {
            return ViewtailSet.Min;
        }
        else
        {
            return -1; // No successor found
        }
    }

    public static void Main(string[] args)
    {
        int n = 10; // The range of integers [0, 9]

        SuccessorWithDelete swd = new SuccessorWithDelete(n);

        swd.Remove(5); // Remove 5 from the set

        int successor1 = swd.FindSuccessor(3); // Find successor of 3
        Console.WriteLine("Successor of 3: " + successor1); // Should print 4

        int successor2 = swd.FindSuccessor(5); // Find successor of 5
        Console.WriteLine("Successor of 5: " + successor2); // Should print 6
    }
}