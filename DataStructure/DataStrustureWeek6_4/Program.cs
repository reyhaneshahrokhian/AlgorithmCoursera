using System;
using System.Collections.Generic;

namespace DataStrustureWeek6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = new string[3];
            SplayTree splayTree = new SplayTree();
            long hold = 0;
            List<string> ans = new List<string>();
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                if (a[0] == "+")
                {
                    splayTree.Add((long.Parse(a[1]) + hold) % M);
                }
                else if (a[0] == "-")
                {
                    splayTree.Delete((long.Parse(a[1]) + hold) % M);
                }
                else if (a[0] == "?")
                {
                    if (splayTree.Find((long.Parse(a[1]) + hold) % M))
                        ans.Add("Found");
                    else
                        ans.Add("Not found");
                }
                else if (a[0] == "s")
                {
                    long temp = splayTree.Sum((long.Parse(a[1]) + hold) % M,(long.Parse(a[2]) + hold) % M);
                    ans.Add(temp.ToString());
                    hold = temp % M;
                }
            }
            foreach (var item in ans)
                Console.WriteLine(item);
        }
        public static long M = (long)Math.Pow(10, 9) + 1;
        class Node
        {
            public long key;
            public long sum;
            public Node left;
            public Node right;
            public Node parent;
            public Node(long key, long sum, Node left, Node right, Node parent)
            {
                this.key = key;
                this.sum = sum;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }
        }
        class Pair
        {
            public Node left;
            public Node right;
            public Pair(Node left, Node right)
            {
                this.left = left;
                this.right = right;
            }
            public Pair() { }
        }
        class SplayTree
        {
            Node root = null;
            public Node splay(Node n)
            {
                if (n == null)
                    return null;

                while (n.parent != null)
                {
                    if (n.parent.parent == null)
                    {
                        SmallRotate(n);
                        break;
                    }
                    BigRotate(n);
                }
                return n;
            }
            public void Change(Node n)
            {
                if (n == null)
                    return;
                n.sum = n.key;
                if (n.left != null)
                {
                    n.sum += n.left.sum;
                    n.left.parent = n;
                }
                if (n.right != null)
                {
                    n.sum += n.right.sum;
                    n.right.parent = n;
                }
            }
            public void SmallRotate(Node n)
            {
                Node parent = n.parent;
                if (parent == null)
                    return;

                Node pp = parent.parent;
                if (parent.left == n)
                {
                    Node hold = n.right;
                    n.right = parent;
                    parent.left = hold;
                }
                else
                {
                    Node hold = n.left;
                    n.left = parent;
                    parent.right = hold;
                }
               
                Change(parent);
                Change(n);

                n.parent = pp;
                if (pp != null && pp.left == parent)
                    pp.left = n;

                else if (pp != null)
                    pp.right = n;
            }
            public void BigRotate(Node n)
            {
                Node parent = n.parent;
                if ((parent.left == n && parent.parent.left == parent) || (parent.right == n && parent.parent.right == parent))
                {
                    SmallRotate(parent);
                    SmallRotate(n);
                }
                else
                {
                    SmallRotate(n);
                    SmallRotate(n);
                }
            }
            public Node Merge(Node left, Node right)
            {
                if (right == null)
                    return left;

                if (left == null)
                    return right;

                while (right.left != null)
                    right = right.left;
                
                right = splay(right);
                right.left = left;
                Change(right);

                return right;
            }
            public Pair find(Node root, long key)
            {
                Node n = root;
                Node last = root;
                Node next = null;
                while (n != null)
                {
                    if (n.key >= key && (next == null || n.key < next.key))
                        next = n;
                    
                    last = n;
                    if (n.key == key)
                        break;

                    else if (n.key < key)
                        n = n.right;
                    
                    else
                        n = n.left;
                }
                root = splay(last);

                return new Pair(next, root);
            }
            public Pair split(Node root, long key)
            {
                Pair ans = new Pair();
                Pair findRoot = find(root, key);
                root = findRoot.right;
                ans.right = findRoot.left;
                if (ans.right == null)
                {
                    ans.left = root;
                    return ans;
                }
                ans.right = splay(ans.right);
                ans.left = ans.right.left;
                ans.right.left = null;
                if (ans.left != null)
                    ans.left.parent = null;
                
                Change(ans.left);
                Change(ans.right);

                return ans;
            }
            public void Add(long x)
            {
                Node left = null;
                Node right = null;
                Node New = null;
                Pair leftRight = split(root, x);
                left = leftRight.left;
                right = leftRight.right;
                if (right == null || right.key != x)
                    New = new Node(x, x, null, null, null);

                root = Merge(Merge(left, New), right);
            }
            public void Delete(long x)
            {
                Pair leftMiddle = split(root, x);
                Node left = leftMiddle.left;
                Node middle = leftMiddle.right;
                Pair middleRight = split(middle, x + 1);
                middle = middleRight.left;
                Node right = middleRight.right;

                if (middle == null || middle.key != x)
                    root = Merge(Merge(left, middle), right);
                
                else
                {
                    middle = null;
                    root = Merge(left, right);
                }
            }
            public bool Find(long x)
            {
                Node left = null;
                Node right = null;
                Pair leftRight = split(root, x);
                left = leftRight.left;
                right = leftRight.right;
                if (right == null || right.key != x)
                {
                    root = Merge(left, right);
                    return false;
                }
                else
                {
                    root = Merge(left, right);
                    return true;
                }
            }
            public long Sum(long start, long end)
            {
                Pair leftMiddle = split(root, start);
                Node left = leftMiddle.left;
                Node middle = leftMiddle.right;
                Pair middleRight = split(middle, end + 1);
                middle = middleRight.left;
                Node right = middleRight.right;

                long ans = 0;
                if (middle != null)
                    ans = middle.sum;

                middle = Merge(middle, right);
                root = Merge(left, middle);

                return ans;
            }
        }      
    }
}
