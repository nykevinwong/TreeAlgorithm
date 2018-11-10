using System.Collections.Generic;
using System;

namespace Algorithm
{
    public class Node
    {
        public Node left;
        public Node right;
        public int value;
        public Node(int value)
        {
            this.value = value;
        }
    }

    public class Tree
    {
        public Node root;
        public Tree(int[] nums)
        {
            this.root = this.CreateTreeFromSortedArray(nums, 0);
        }

        public Node CreateTreeFromSortedArray(int[] nums, int start)
        {
            int left = start*2+1;
            int right = start*2+2;
            Node node = new Node(nums[start]);

            if(left < nums.Length) node.left = CreateTreeFromSortedArray(nums, left);
            if(right < nums.Length) node.right = CreateTreeFromSortedArray(nums, right);
            
            return node;
        }

        public void LevelorderTraversalRecursive(Node root, int level, IList<IList<int>> ls)
        {
            if(root==null) return;
            if(ls.Count == level) ls.Add(new List<int>());

            ls[level].Add(root.value); // print/add/verify your data here.
            LevelorderTraversalRecursive(root.left, level+1, ls);
            LevelorderTraversalRecursive(root.right, level+1, ls);
        }

        public void InorderTraversalRecusrive(Node root, IList<int> l)
        {
            if(root==null) return;
            InorderTraversalRecusrive(root.left, l);
            l.Add(root.value); // print/add/verify your data here
            InorderTraversalRecusrive(root.right, l);
        }

        public void PreorderTraversalRecusrive(Node root, IList<int> l)
        {            
            if(root==null) return;
            l.Add(root.value); // print/add/verify your data here
            PreorderTraversalRecusrive(root.left, l);
            PreorderTraversalRecusrive(root.right, l);
        }

        public void PostorderTraversalRecusrive(Node root, IList<int> l)
        {
            if(root==null) return;
            PostorderTraversalRecusrive(root.left, l);
            PostorderTraversalRecusrive(root.right, l);
            l.Add(root.value); // print/add/verify your data here
        }
        public void PreorderTraversalIterative(Node root)
        {
            Stack<Node> s = new Stack<Node>();
            Console.Write("Preorder Traversal Iterative: ");

            while(root!=null || s.Count > 0)
            {
                if(root!=null)
                {
                    s.Push(root);
                    Console.Write(root.value + " ");
                    root = root.left;
                }
                else // root is null
                {
                    root = s.Pop();
                    root = root.right;
                }
            }
            Console.WriteLine();
        }

        public void InorderTraversalIterative(Node root)
        {
            Stack<Node> s = new Stack<Node>();
            Console.Write("Inorder Traversal Iterative: ");

            while(root!=null || s.Count > 0)
            {
                if(root!=null)
                {
                    s.Push(root);
                    root = root.left;
                }
                else // root is null
                {
                    root = s.Pop();
                    Console.Write(root.value + " ");
                    root = root.right;
                }
            }
            Console.WriteLine();
        }

        public void PostorderTraversalIterative(Node root)
        {
            Stack<Node> s = new Stack<Node>();
            Console.Write("Postorder Traversal Iterative: ");
            Stack<int> postorder = new Stack<int>();

            while(root!=null || s.Count > 0)
            {
                if(root!=null)
                {
                    s.Push(root);
                    postorder.Push(root.value);
                    root = root.left;
                }
                else // root is null
                {
                    root = s.Pop();
                    root = root.right;
                }
            }

            while(postorder.Count > 0) Console.Write(postorder.Pop()+ " ");

            Console.WriteLine();
        }

        public void Print() { Print(root); }

        private void Print(Node root)
        {
            if(root==null) return;
            BTreePrinter.Print(root);
        }
    }

    public class TreeTraversal
    {
        public static void PrintList(string message, IList<int> l)
        {
            Console.Write(message + ": ");
            foreach(int x in l)
                Console.Write(x + " ");

            Console.WriteLine();
        }
        public static void PrintList(string message, IList<IList<int>> ls)
        {
            int count = 0;
            Console.Write(message + ": [ ");
            foreach(IList<int> l in ls)
            {
                Console.Write("[ ", ++count);
                foreach(int x in l) Console.Write(x + " ");
                Console.Write(" ],");
            }

            Console.WriteLine(" ]");
        }

        static void Main(string[] argv)
        {
            int[] nums = {1,2,3,4,5,6,7,8,9};
            Tree tree = new Tree(nums);
            tree.Print();
            
            IList<int> l1 = new List<int>();            
            tree.PreorderTraversalRecusrive(tree.root, l1);
            PrintList("Preorder Traversal Recursive", l1 );
            IList<int> l2 = new List<int>();            
            tree.InorderTraversalRecusrive(tree.root, l2);
            PrintList("Inorder Traversal Recursive", l2);
            IList<int> l3 = new List<int>();            
            tree.PostorderTraversalRecusrive(tree.root, l3);
            PrintList("Postorder Traversal Recursive", l3);
            IList<IList<int>> l4 = new List<IList<int>>();            
            tree.LevelorderTraversalRecursive(tree.root, 0, l4);
            PrintList("Levelorder Traversal Recursive", l4);

            tree.PreorderTraversalIterative(tree.root);
            tree.InorderTraversalIterative(tree.root);
            tree.PostorderTraversalIterative(tree.root);

        }
    }
}