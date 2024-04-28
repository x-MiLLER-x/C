/*
 Taxicab numbers. A taxicab number is an integer that can be expressed as the sum of two cubes
of positive integers in two different ways: a^3 3 + b^3 = c^3 + d^3 . 

For example, 1729 is the smallest taxicab number: 9^3+10^3=1^3+12^3. 
Design an algorithm to find all taxicab numbers with a, b, c, and d less than n.

Version 1: Use time proportional to n^2log⁡n and space proportional to n^2 .
Version 2: Use time proportional to n^2log⁡n and space proportional to n.
 */
using System;
using System.Collections.Generic;

class TaxicabNumber
{
    static void FindTaxicabNumbersV1(int n)
    {
        // Create a list to store the taxicab numbers and their corresponding pairs (a, b) and (c, d)
        List<Tuple<int, int, int, int>> taxicabNumbers = new List<Tuple<int, int, int, int>>();

        // Create a dictionary to store the sum of cubes and their corresponding pairs (a, b)
        Dictionary<long, List<Tuple<int, int>>> sumOfCubes = new Dictionary<long, List<Tuple<int, int>>>();

        // Generate all possible pairs (a, b) and calculate their cube sums
        for (int a = 1; a < n; a++)
        {
            for (int b = a; b < n; b++)
            {
                long cubeSum = (long)Math.Pow(a, 3) + (long)Math.Pow(b, 3);
                if (!sumOfCubes.ContainsKey(cubeSum))
                {
                    sumOfCubes[cubeSum] = new List<Tuple<int, int>>();
                }
                sumOfCubes[cubeSum].Add(Tuple.Create(a, b));
            }
        }

        // Iterate through the sumOfCubes dictionary to find taxicab numbers
        foreach (var entry in sumOfCubes)
        {
            if (entry.Value.Count >= 2)
            {
                int count = entry.Value.Count;
                for (int i = 0; i < count; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        var pair1 = entry.Value[i];
                        var pair2 = entry.Value[j];
                        int a1 = pair1.Item1, b1 = pair1.Item2;
                        int a2 = pair2.Item1, b2 = pair2.Item2;
                        taxicabNumbers.Add(Tuple.Create(a1, b1, a2, b2));
                    }
                }
            }
        }

        // Print the taxicab numbers
        foreach (var taxicab in taxicabNumbers)
        {
            Console.WriteLine($"Taxicab Number (Version 1): {taxicab.Item1}^3 + {taxicab.Item2}^3 = {taxicab.Item3}^3 + {taxicab.Item4}^3");
        }
    }

    static void FindTaxicabNumbersV2(int n)
    {
        // Create a dictionary to store the sum of cubes and their corresponding pairs (a, b)
        Dictionary<long, List<Tuple<int, int>>>
            sumOfCubes = new Dictionary<long, List<Tuple<int, int>>>();

        // Generate all possible pairs (a, b) and calculate their cube sums
        for (int a = 1; a < n; a++)
        {
            for (int b = a; b < n; b++)
            {
                long cubeSum = (long)Math.Pow(a, 3) + (long)Math.Pow(b, 3);
                if (!sumOfCubes.ContainsKey(cubeSum))
                {
                    sumOfCubes[cubeSum] = new List<Tuple<int, int>>();
                }
                sumOfCubes[cubeSum].Add(Tuple.Create(a, b));
            }
        }

        // Iterate through the sumOfCubes dictionary to find taxicab numbers
        foreach (var entry in sumOfCubes)
        {
            if (entry.Value.Count >= 2)
            {
                int count = entry.Value.Count;
                for (int i = 0; i < count; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        var pair1 = entry.Value[i];
                        var pair2 = entry.Value[j];
                        int a1 = pair1.Item1, b1 = pair1.Item2;
                        int a2 = pair2.Item1, b2 = pair2.Item2;
                        Console.WriteLine($"Taxicab Number (Version 2): {a1}^3 + {b1}^3 = {a2}^3 + {b2}^3");
                    }
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int n = 1000; // Change n to your desired value

        Console.WriteLine("Taxicab Numbers (Version 1):");
        FindTaxicabNumbersV1(n);

        Console.WriteLine("\nTaxicab Numbers (Version 2):");
        FindTaxicabNumbersV2(n);
    }
}
