/*
 Counting inversions. An inversion in an array a[] is a pair of entries a[i] and a[j] such that  i<j but a[i]>a[j]. 
Given an array, design a linearithmic algorithm to count the number of inversions.
 */
using System;

public class MergeSortExample
{
    public static long CountInversionsAndSort(int[] arr)
    {
        int[] aux = new int[arr.Length];
        return MergeSortAndCountInversions(arr, aux, 0, arr.Length - 1);
    }

    public static long MergeSortAndCountInversions(int[] arr, int[] aux, int lo, int hi)
    {
        if (lo >= hi)
            return 0;

        int mid = lo + (hi - lo) / 2;

        long leftInversions = MergeSortAndCountInversions(arr, aux, lo, mid);
        long rightInversions = MergeSortAndCountInversions(arr, aux, mid + 1, hi);

        long mergeInversions = MergeAndCountInversions(arr, aux, lo, mid, hi);

        return leftInversions + rightInversions + mergeInversions;
    }

    public static long MergeAndCountInversions(int[] arr, int[] aux, int lo, int mid, int hi)
    {
        long inversions = 0;

        for (int i = lo; i <= hi; i++)
        {
            aux[i] = arr[i];
        }

        int left = lo;
        int right = mid + 1;

        for (int i = lo; i <= hi; i++)
        {
            if (left > mid)
            {
                arr[i] = aux[right++];
            }
            else if (right > hi)
            {
                arr[i] = aux[left++];
            }
            else if (aux[left] <= aux[right])
            {
                arr[i] = aux[left++];
            }
            else
            {
                arr[i] = aux[right++];
                inversions += mid - left + 1; // Count inversions
            }
        }

        return inversions;
    }

    public static void Main()
    {
        int[] arr = { 1, 3, 5, 2, 4, 6 };
        long inversionCount = CountInversionsAndSort(arr);

        Console.WriteLine("Inversion Count: " + inversionCount);
    }
}
