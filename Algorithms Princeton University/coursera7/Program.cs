/*
 Merging with smaller auxiliary array. Suppose that the subarray a[0] 
to a[n−1] is sorted and the subarray a[n] to a[2∗n−1] is sorted. 
How can you merge the two subarrays so that a[0] to a[2∗n−1] is sorted using an 
auxiliary array of length n (instead of 2n)?
 */
using System;

public class MergeSortExample
{
    public static void Merge(int[] arr, int[] aux, int lo, int mid, int hi)
    {
        int left = lo;
        int right = mid + 1;

        for (int k = lo; k <= hi; k++)
        {
            if (left > mid) aux[k] = arr[right++];
            else if (right > hi) aux[k] = arr[left++];
            else if (arr[right] < arr[left]) aux[k] = arr[right++];
            else aux[k] = arr[left++];
        }

        for (int i = lo; i <= hi; i++)
        {
            arr[i] = aux[i];
        }
    }

    public static void MergeSort(int[] arr, int[] aux, int lo, int hi)
    {
        if (hi <= lo) return;
        int mid = lo + (hi - lo) / 2;
        MergeSort(arr, aux, lo, mid);
        MergeSort(arr, aux, mid + 1, hi);
        Merge(arr, aux, lo, mid, hi);
    }

    public static void Main()
    {
        int[] arr = { 38, 27, 43, 3, 9, 82, 10 };
        int[] aux = new int[arr.Length];
        int lo = 0;
        int hi = arr.Length - 1; // Уменьшите hi на 1, чтобы он указывал на последний элемент массива

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        MergeSort(arr, aux, lo, hi);

        Console.WriteLine("Sorted Array:");
        PrintArray(arr);
    }

    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
