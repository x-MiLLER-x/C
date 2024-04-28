/*
Search in a bitonic array. An array is bitonic if it is comprised of an increasing sequence of integers followed 
immediately by a decreasing sequence of integers. Write a program that, given a bitonic array of n distinct integer 
values, determines whether a given integer is in the array.Standard version: 

Use ⁡∼3lgn compares in the worst case.

Signing bonus: Use ∼2lgn compares in the worst case (and prove that no algorithm can guarantee to perform fewer than ∼2lg⁡∼2lgn compares in the worst case).
*/
using System;

class BitonicArraySearch
{
    public static int Search(int[] arr, int target)
    {
        int peakIndex = FindBitonicPeak(arr);

        int leftResult = BinarySearchIncreasing(arr, target, 0, peakIndex);

        if (leftResult != -1)
            return leftResult;

        int rightResult = BinarySearchDecreasing(arr, target, peakIndex + 1, arr.Length - 1);

        return rightResult;
    }

    public static int FindBitonicPeak(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] < arr[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }

        return left; // Peak index
    }

    public static int BinarySearchIncreasing(int[] arr, int target, int left, int right)
    {
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Element not found
    }

    public static int BinarySearchDecreasing(int[] arr, int target, int left, int right)
    {
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] > target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Element not found
    }

    static void Main(string[] args)
    {
        int[] bitonicArray = { 1, 3, 5, 9, 12, 10, 6, 4, 2 };
        int target = 10;

        int result = Search(bitonicArray, target);

        if (result != -1)
            Console.WriteLine($"Element {target} found at index {result}");
        else
            Console.WriteLine($"Element {target} not found in the array");
    }
}