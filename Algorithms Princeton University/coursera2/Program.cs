/*
 Union-find with specific canonical element. Add a method find() to the union-find data type so that 
find(i) returns the largest element in the connected component containing i. The operations, union(), 
connected(), and find() should all take logarithmic time or better.

For example, if one of the connected components is {1,2,6,9}{1,2,6,9}, then the find() method should return 99 for 
each of the four elements in the connected components.
 */
public class UnionFindWithLargest
{
    private int[] parent;
    private int[] size;
    private int[] largest;  // Stores the largest element in each component

    public UnionFindWithLargest(int n)
    {
        parent = new int[n];
        size = new int[n];
        largest = new int[n];

        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
            largest[i] = i;
        }
    }

    public int Find(int i)
    {
        while (i != parent[i])
        {
            // Path compression: Make every other node in the path point to its grandparent
            parent[i] = parent[parent[i]];
            i = parent[i];
        }
        return largest[i];
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
            largest[rootQ] = Math.Max(largest[rootP], largest[rootQ]);
        }
        else
        {
            parent[rootQ] = rootP;
            size[rootP] += size[rootQ];
            largest[rootP] = Math.Max(largest[rootP], largest[rootQ]);
        }
    }

    public int GetLargestInComponent(int i)
    {
        return largest[Find(i)];
    }

    public static void Main(string[] args)
    {
        int n = 10;  // The number of elements

        UnionFindWithLargest uf = new UnionFindWithLargest(n);

        // Perform union operations
        uf.Union(1, 2);
        uf.Union(2, 6);
        uf.Union(6, 9);

        // The largest element in the connected component
        int largestElement = uf.GetLargestInComponent(1);
        Console.WriteLine(largestElement);  // This will print 9 for all elements in the connected component
    }
}