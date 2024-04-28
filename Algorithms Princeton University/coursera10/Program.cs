/*
 Dynamic median. Design a data type that supports insert in logarithmic time, find-the-median in constant time, 
and remove-the-median in logarithmic time. If the number of keys in the data type is even, find/remove the lower median.
 */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DynamicMedian<int> dynamicMedian = new DynamicMedian<int>();

        // Insert elements
        dynamicMedian.Insert(5);
        dynamicMedian.Insert(2);
        dynamicMedian.Insert(8);
        dynamicMedian.Insert(1);

        Console.WriteLine("Current median: " + dynamicMedian.FindMedian()); // Should print 5

        // Remove median
        int removedMedian = dynamicMedian.RemoveMedian();
        Console.WriteLine("Removed median: " + removedMedian); // Should print 5

        Console.WriteLine("Current median: " + dynamicMedian.FindMedian()); // Should print 2

        // Insert more elements
        dynamicMedian.Insert(4);
        dynamicMedian.Insert(7);

        Console.WriteLine("Current median: " + dynamicMedian.FindMedian()); // Should print 4
    }
}

public class DynamicMedian<T> where T : IComparable<T>
{
    private readonly Heap<T> maxHeap; // Max-heap for the lower half
    private readonly Heap<T> minHeap; // Min-heap for the upper half

    public DynamicMedian()
    {
        maxHeap = new Heap<T>(HeapType.MaxHeap);
        minHeap = new Heap<T>(HeapType.MinHeap);
    }

    public void Insert(T item)
    {
        if (maxHeap.Count == 0 || item.CompareTo(maxHeap.Peek()) <= 0)
        {
            maxHeap.Insert(item);
        }
        else
        {
            minHeap.Insert(item);
        }

        // Balance the heaps
        BalanceHeaps();
    }

    public T FindMedian()
    {
        if (maxHeap.Count == minHeap.Count)
        {
            return maxHeap.Peek();
        }
        else if (maxHeap.Count > minHeap.Count)
        {
            return maxHeap.Peek();
        }
        else
        {
            return minHeap.Peek();
        }
    }

    public T RemoveMedian()
    {
        if (maxHeap.Count == 0 && minHeap.Count == 0)
        {
            throw new InvalidOperationException("The data type is empty.");
        }

        T median;
        if (maxHeap.Count == minHeap.Count)
        {
            median = maxHeap.Extract();
        }
        else if (maxHeap.Count > minHeap.Count)
        {
            median = maxHeap.Extract();
        }
        else
        {
            median = minHeap.Extract();
        }

        // Balance the heaps
        BalanceHeaps();

        return median;
    }

    private void BalanceHeaps()
    {
        while (maxHeap.Count > minHeap.Count + 1)
        {
            T root = maxHeap.Extract();
            minHeap.Insert(root);
        }

        while (minHeap.Count > maxHeap.Count)
        {
            T root = minHeap.Extract();
            maxHeap.Insert(root);
        }
    }
}

public enum HeapType
{
    MaxHeap,
    MinHeap
}

public class Heap<T> where T : IComparable<T>
{
    private readonly List<T> heap;
    private readonly HeapType heapType;

    public Heap(HeapType type)
    {
        heap = new List<T>();
        heapType = type;
    }

    public int Count => heap.Count;

    public T Peek()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }
        return heap[0];
    }

    public void Insert(T item)
    {
        heap.Add(item);
        HeapifyUp(heap.Count - 1);
    }

    public T Extract()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        T root = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
        HeapifyDown(0);

        return root;
    }

    private void HeapifyUp(int childIndex)
    {
        int parentIndex = (childIndex - 1) / 2;

        while (childIndex > 0 && Compare(heap[childIndex], heap[parentIndex]) > 0)
        {
            Swap(childIndex, parentIndex);
            childIndex = parentIndex;
            parentIndex = (childIndex - 1) / 2;
        }
    }

    private void HeapifyDown(int parentIndex)
    {
        int maxIndex = parentIndex;
        int leftChildIndex = 2 * parentIndex + 1;
        int rightChildIndex = 2 * parentIndex + 2;

        if (leftChildIndex < heap.Count && Compare(heap[leftChildIndex], heap[maxIndex]) > 0)
        {
            maxIndex = leftChildIndex;
        }

        if (rightChildIndex < heap.Count && Compare(heap[rightChildIndex], heap[maxIndex]) > 0)
        {
            maxIndex = rightChildIndex;
        }

        if (parentIndex != maxIndex)
        {
            Swap(parentIndex, maxIndex);
            HeapifyDown(maxIndex);
        }
    }

    private void Swap(int index1, int index2)
    {
        T temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }

    private int Compare(T item1, T item2)
    {
        return heapType == HeapType.MaxHeap ? item1.CompareTo(item2) : item2.CompareTo(item1);
    }
}
