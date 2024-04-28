/*
 3-SUM in quadratic time. Design an algorithm for the 3-SUM problem that takes time proportional to n^2 in the 
worst case. You may assume that you can sort the n integers in time proportional to n^2 or better.
 */
using System;
using System.Collections.Generic;

class ThreeSum
{
    public static List<List<int>> Find3Sum(int[] nums)
    {
        Array.Sort(nums);
        List<List<int>> result = new List<List<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
            {
                int left = i + 1;
                int right = nums.Length - 1;
                int target = -nums[i];

                while (left < right)
                {
                    if (nums[left] + nums[right] == target)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        while (left < right && nums[left] == nums[left + 1])
                            left++;

                        while (left < right && nums[right] == nums[right - 1])
                            right--;

                        left++;
                        right--;
                    }
                    else if (nums[left] + nums[right] < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
        }

        return result;
    }

    static void Main()
    {
        int[] nums = { -1, 0, 1, 2, -1, -4 };
        List<List<int>> triplets = Find3Sum(nums);

        foreach (var triplet in triplets)
        {
            Console.WriteLine(string.Join(" ", triplet));
        }
    }
}
