# Java
 Algorithms Princeton University

This repository contains projects developed as part of the Algorithms course at Princeton University, implemented in C#.

Task 1
 /*
 Social network connectivity. Given a social network containing n members and a log file containing m 
timestamps at which times pairs of members formed friendships, design an algorithm to determine the earliest
time at which all members are connected (i.e., every member is a friend of a friend of a friend ... of a friend). 
Assume that the log file is sorted by timestamp and that friendship is an equivalence relation. 

The running time of your algorithm should be log⁡mlogn or better and use extra space proportional to n.
 */

Task 2
/*
 Union-find with specific canonical element. Add a method find() to the union-find data type so that 
find(i) returns the largest element in the connected component containing i. The operations, union(), 
connected(), and find() should all take logarithmic time or better.

For example, if one of the connected components is {1,2,6,9}{1,2,6,9}, then the find() method should return 99 for 
each of the four elements in the connected components.
 */

Task 3
/*
 Successor with delete. Given a set of n integers ={0,1,...,−1}S={0,1,...,n−1} and a sequence of requests of the 
following form:

Remove x from S

Find the successor of x: the smallest y in S such that y≥x.

design a data type so that all operations (except construction) take logarithmic time or better in the worst case
 */

Task 4
/*
 3-SUM in quadratic time. Design an algorithm for the 3-SUM problem that takes time proportional to n^2 in the 
worst case. You may assume that you can sort the n integers in time proportional to n^2 or better.
 */

Task 5
/*
Search in a bitonic array. An array is bitonic if it is comprised of an increasing sequence of integers followed 
immediately by a decreasing sequence of integers. Write a program that, given a bitonic array of n distinct integer 
values, determines whether a given integer is in the array.Standard version: 

Use ⁡∼3lgn compares in the worst case.

Signing bonus: Use ∼2lgn compares in the worst case (and prove that no algorithm can guarantee to perform fewer than ∼2lg⁡∼2lgn compares in the worst case).
*/

Task 6
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

Task 7
/*
 Merging with smaller auxiliary array. Suppose that the subarray a[0] 
to a[n−1] is sorted and the subarray a[n] to a[2∗n−1] is sorted. 
How can you merge the two subarrays so that a[0] to a[2∗n−1] is sorted using an 
auxiliary array of length n (instead of 2n)?
 */

Task 8
/*
 Counting inversions. An inversion in an array a[] is a pair of entries a[i] and a[j] such that  i<j but a[i]>a[j]. 
Given an array, design a linearithmic algorithm to count the number of inversions.
 */

Task 9
/*
 Shuffling a linked list. Given a singly-linked list containing n items, rearrange the items uniformly at random. Your 
algorithm should consume a logarithmic (or constant) amount of extra memory and run in time proportional to ⁡
nlogn in the worst case. 
 */

Task 10
/*
 Dynamic median. Design a data type that supports insert in logarithmic time, find-the-median in constant time, 
and remove-the-median in logarithmic time. If the number of keys in the data type is even, find/remove the lower median.
 */

Task 11
/*
 Randomized priority queue. Describe how to add the methods sample() and delRandom() to our binary heap implementation. 
The two methods return a key that is chosen uniformly at random among the remaining keys, with the latter method also removing that key. 
The sample() method should take constant time; the delRandom() method should take logarithmic time. Do not worry about resizing the underlying array.
 
JAVA VERSION
 */

Task 12
/*
 Taxicab numbers. A taxicab number is an integer that can be expressed as the sum of two cubes
of positive integers in two different ways: a^3 3 + b^3 = c^3 + d^3 . 

For example, 1729 is the smallest taxicab number: 9^3+10^3=1^3+12^3. 
Design an algorithm to find all taxicab numbers with a, b, c, and d less than n.

Version 1: Use time proportional to n^2log⁡n and space proportional to n^2 .
Version 2: Use time proportional to n^2log⁡n and space proportional to n.
 */
