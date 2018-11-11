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
                    root = root.right; // swap to right
                }
                else // root is null
                {
                    root = s.Pop();
                    root = root.left; // swap to left
                }
            }

            while(postorder.Count > 0) Console.Write(postorder.Pop()+ " ");

            Console.WriteLine();
        }

        public void LevelorderTraversalIterative(Node root, IList<IList<int>> ls)
        {
            Queue<Node> q = new Queue<Node>();
            if(root!=null) q.Enqueue(root);
            int level = 0;

            while(q.Count > 0)
            {
                int size = q.Count;
                ls.Add(new List<int>());
                for(int i=0;i<size;i++)
                {
                    Node node = q.Dequeue();                    
                    ls[level].Add(node.value);

                    if(node.left!=null) q.Enqueue(node.left);
                    if(node.right!=null) q.Enqueue(node.right);
                }
                level++;
            }
        }

        // 700. Search in a Binary Searcsh Tree
        public Node SearchBST(Node root, int value) {
            if(root==null) { Console.WriteLine("SearchBST: "+ value + " not found!!"); return null; }
        
            if(root.value > value) return SearchBST(root.left, value);
            else if(root.value < value) return SearchBST(root.right, value);
        
            Console.WriteLine("SearchBST: found " + value);
            return root; // found this node
        }

        //617. Merge Two Binary Trees
        public Node MergeTrees(Node t1, Node t2) {
            if(t1==null && t2 == null ) return null;
            
            Node node = new Node(0);
            
            if(t1!=null) node.value = t1.value;
            if(t2!=null) node.value += t2.value;
            
            node.left = MergeTrees((t1!=null) ? t1.left:null,(t2!=null) ? t2.left:null);
            node.right = MergeTrees((t1!=null) ? t1.right:null,(t2!=null) ? t2.right:null);
            return node;
        }

        public bool IsSymmetric(Node root) {
            if(root==null)  // no node
                return true;
                    
            if(root!=null && root.left==null && root.right== null)
                return true; // only one node.
            
            return IsMirror(root.left, root.right);
        }
        
        public bool IsMirror(Node left, Node right)
        {
            if(left!=null && right != null)
            {
                return IsMirror(left.left, right.right) && IsMirror(left.right, right.left) && (left.value==right.value);
            }
            else if(left==right && left==null)
            {
                return true; // both are null
            }
            
            return false;
        }

// 104. Maximum Depth of Binary Tree
        public int MaxDepth(Node root) {
            if(root==null) return 0;        
            if(root.left==null && root.right==null) return 1;        
            return Math.Max( MaxDepth(root.left), MaxDepth(root.right)) + 1;
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
            Tree tree = new Tree( new int[] {1,2,3,4,5,6,7,8,9});
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
            IList<IList<int>> l5 = new List<IList<int>>();            
            tree.LevelorderTraversalIterative(tree.root, l5);
            PrintList("Levelorder Traversal Iterative", l5);
            Console.WriteLine("Max Depth: " + tree.MaxDepth(tree.root));
            tree.SearchBST(tree.root, 7);
            Console.WriteLine("Is tree1 symmetric? " + tree.IsSymmetric(tree.root));

            Tree tree2 = new Tree( new int[] {1,2,2,3,4,4,3});
            tree2.Print();
            Console.WriteLine("Is tree2 symmetric? " + tree2.IsSymmetric(tree2.root));

        }
    }
}