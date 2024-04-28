/*
 Egg drop. Suppose that you have an n-story building (with floors 1 through n) and plenty of eggs. An egg breaks if 
it is dropped from floor T or higher and does not break otherwise. Your goal is to devise a strategy to determine the 
value of T given the following limitations on the number of eggs and tosses:

Version 0: 1 egg, ≤T tosses.

Version 1: ⁡∼1lgn eggs and ∼1lgn tosses.

Version 2: ∼lgT eggs and ⁡∼2lgT tosses.

Version 3: 2 eggs and ∼2sqrt(n)​ tosses.

Version 4: 2 eggs and ≤csqrt(T)​ tosses for some fixed constant c.
 */
using System;

class EggDrop
{
    // Version 0: 1 egg, ≤T tosses.
    public static int EggDropVersion0(int T)
    {
        int tosses = 0;
        int height = 0;

        while (height < T)
        {
            tosses++;
            height += tosses;
        }

        return tosses;
    }

    // Version 1: ∼1lgn eggs and ∼1lgn tosses.
    public static int EggDropVersion1(int T)
    {
        return (int)Math.Ceiling(Math.Log(T + 1, 2));
    }

    // Version 2: ∼lgT eggs and ∼2lgT tosses.
    public static int EggDropVersion2(int T)
    {
        int eggs = (int)Math.Ceiling(Math.Log(T, 2));
        int tosses = 2 * eggs - 1;
        return tosses;
    }

    // Version 3: 2 eggs and ∼2sqrt(n) tosses.
    public static int EggDropVersion3(int n)
    {
        int tosses = (int)Math.Ceiling(2 * Math.Sqrt(n));
        return tosses;
    }

    // Version 4: 2 eggs and ≤csqrt(T) tosses for some fixed constant c.
    public static int EggDropVersion4(int T)
    {
        double c = 2.0; // You can adjust the constant 'c' as needed.
        int tosses = (int)Math.Ceiling(c * Math.Sqrt(T));
        return tosses;
    }

    static void Main(string[] args)
    {
        int T = 100; // Replace with the desired value of T or n for different versions.

        Console.WriteLine("Version 0: " + EggDropVersion0(T));
        Console.WriteLine("Version 1: " + EggDropVersion1(T));
        Console.WriteLine("Version 2: " + EggDropVersion2(T));
        Console.WriteLine("Version 3: " + EggDropVersion3(T));
        Console.WriteLine("Version 4: " + EggDropVersion4(T));
    }
}
