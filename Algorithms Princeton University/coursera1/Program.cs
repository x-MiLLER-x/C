/*
 Social network connectivity. Given a social network containing n members and a log file containing m 
timestamps at which times pairs of members formed friendships, design an algorithm to determine the earliest
time at which all members are connected (i.e., every member is a friend of a friend of a friend ... of a friend). 
Assume that the log file is sorted by timestamp and that friendship is an equivalence relation. 

The running time of your algorithm should be log⁡mlogn or better and use extra space proportional to n.
 */
using System;
using System.Collections.Generic;

public class UnionFind
{
    private int[] parent;
    private int[] size;
    private int count;  // Number of connected components

    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];
        count = n;

        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int i)
    {
        while (i != parent[i])
        {
            parent[i] = parent[parent[i]];  // Path compression
            i = parent[i];
        }
        return i;
    }

    public bool Connected(int p, int q)
    {
        return Find(p) == Find(q);
    }

    public void Union(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);

        if (rootP == rootQ)
        {
            return;
        }

        if (size[rootP] < size[rootQ])
        {
            parent[rootP] = rootQ;
            size[rootQ] += size[rootP];
        }
        else
        {
            parent[rootQ] = rootP;
            size[rootP] += size[rootQ];
        }

        count--;  // Decrement the number of connected components
    }

    public int CountConnectedComponents()
    {
        return count;
    }


    public static int EarliestAllConnected(int n, List<Tuple<int, int, int>> logFile)
    {
        UnionFind uf = new UnionFind(n);

        foreach (var entry in logFile)
        {
            int timestamp = entry.Item1;
            int member1 = entry.Item2;
            int member2 = entry.Item3;

            if (!uf.Connected(member1, member2))
            {
                uf.Union(member1, member2);
                if (uf.CountConnectedComponents() == 1)
                {
                    return timestamp;
                }
            }
        }

        return -1;  // Return -1 if not all members are connected
    }

    public static void Main(string[] args)
    {
        int n = 10;  // The number of members
        var logFile = new List<Tuple<int, int, int>>()
    {
        Tuple.Create(1, 1, 2),
        Tuple.Create(2, 2, 3),
        Tuple.Create(3, 4, 5),
        Tuple.Create(4, 6, 7),
        Tuple.Create(5, 8, 9),
        Tuple.Create(6, 2, 7)
    };

        int earliestTime = EarliestAllConnected(n, logFile);
        Console.WriteLine("Earliest time when all members are connected: " + earliestTime);
    }
}