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

    public class Node2
    {
        public Node2 left;
        public Node2 right;
        public Node2 next;
        public int value;
        public Node2(int value)
        {
            this.value = value;
        }
    }

    public class Tree
    {
        public Node root;
        public string name;
        public Tree()
        {
            
        }
        public Tree(string name)
        {
            this.name = name;
        }

        public static Node CreateBTFromSortedArray(int[] nums, int start=0)
        {
            int left = start*2+1;
            int right = start*2+2;
            Node node = new Node(nums[start]);

            if(left < nums.Length) node.left = CreateBTFromSortedArray(nums, left);
            if(right < nums.Length) node.right = CreateBTFromSortedArray(nums, right);
            
            return node;
        }

        public static Node CreateBSTFromSortedArray(int[] nums)         
        {
            return CreateBSTFromSortedArray(nums, 0, nums.Length-1);
        }

        //[EASY] 108. Convert Sorted Array to Binary Search Tree
        //https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
        public static Node CreateBSTFromSortedArray(int[] nums, int start, int end)         
        {
            if(start > end) return null;
            int mid = (start+end)/2;
            Node node = new Node(nums[mid]);
            node.left = CreateBSTFromSortedArray(nums, start, mid-1);
            node.right = CreateBSTFromSortedArray(nums, mid+1, end);
            return node;
        }

        // 94. Binary Tree Inorder Traversal
        public static void InorderTraversalRecusrive(Node root, IList<int> l)
        {
            if(root==null) return;
            InorderTraversalRecusrive(root.left, l);
            l.Add(root.value); // print/add/verify your data here
            InorderTraversalRecusrive(root.right, l);
        }

        public static void InorderTraversalIterative(Node root)
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


        // 144. Binary Tree Preorder Traversal
        public static void PreorderTraversalRecusrive(Node root, IList<int> l)
        {            
            if(root==null) return;
            l.Add(root.value); // print/add/verify your data here
            PreorderTraversalRecusrive(root.left, l);
            PreorderTraversalRecusrive(root.right, l);
        }

        public static void PreorderTraversalIterative(Node root)
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


        public static void PostorderTraversalRecusrive(Node root, IList<int> l)
        {
            if(root==null) return;
            PostorderTraversalRecusrive(root.left, l);
            PostorderTraversalRecusrive(root.right, l);
            l.Add(root.value); // print/add/verify your data here
        }

        public static void PostorderTraversalIterative(Node root)
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

        //102. Binary Tree Level Order Traversal
        public static void LevelorderTraversalRecursive(Node root, int level, IList<IList<int>> ls)
        {
            if(root==null) return;
            if(ls.Count == level) ls.Add(new List<int>());

            ls[level].Add(root.value); // print/add/verify your data here.
            LevelorderTraversalRecursive(root.left, level+1, ls);
            LevelorderTraversalRecursive(root.right, level+1, ls);
        }


        //102. Binary Tree Level Order Traversal
        public static void LevelorderTraversalIterative(Node root, IList<IList<int>> ls)
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
        public static Node SearchBST(Node root, int value) {
            if(root==null) { Console.WriteLine("SearchBST: "+ value + " not found!!"); return null; }
        
            if(root.value > value) return SearchBST(root.left, value);
            else if(root.value < value) return SearchBST(root.right, value);
        
            Console.WriteLine("SearchBST: found " + value);
            return root; // found this node
        }

        //617. Merge Two Binary Trees
        public static Node MergeTrees(Node t1, Node t2) {
            if(t1==null && t2 == null ) return null;
            
            Node node = new Node(0);
            
            if(t1!=null) node.value = t1.value;
            if(t2!=null) node.value += t2.value;
            
            node.left = MergeTrees((t1!=null) ? t1.left:null,(t2!=null) ? t2.left:null);
            node.right = MergeTrees((t1!=null) ? t1.right:null,(t2!=null) ? t2.right:null);
            return node;
        }

        // 101. Symmetric Tree
        // https://leetcode.com/problems/symmetric-tree/
        public static bool IsSymmetric(Node root) {
            if(root==null)  // no node
                return true;
                    
            if(root!=null && root.left==null && root.right== null)
                return true; // only one node.
            
            return IsMirror(root.left, root.right);
        }
        
        public static bool IsMirror(Node left, Node right)
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
        public static int MaxDepth(Node root) {
            if(root==null) return 0;        
            if(root.left==null && root.right==null) return 1;        
            return Math.Max( MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        // 230. Kth Smallest Element in a BST
        // solution 1a
        public static int KthSmallestInorderCompare(Node root, int k) {
        int value = -1;
        InorderCompare(root, ref k, ref value);
        return value;
        }
        
        public static void InorderCompare(Node root, ref int k, ref int value)
        {
            if(root==null) return;
            
            InorderCompare(root.left, ref k, ref value);
            
            if(--k==0)
            {
                value = root.value;
                return;
            }
            InorderCompare(root.right, ref k, ref value);
            
        }
        
        // 230. Kth Smallest Element in a BST
        // solution 1b
        public static int KthSmallestInorderReturn(Node root, int k) 
        {  return KthSmallestInorderReturn(root, ref k); }
        
        public static int KthSmallestInorderReturn(Node root, ref int k)
        {
            if(root==null) return -1;
            
            int value = KthSmallestInorderReturn(root.left, ref k);
            
            if(k==0) return value;        
            if(--k==0) return root.value;
            
            return KthSmallestInorderReturn(root.right, ref k);        
        }
        
        // 230. Kth Smallest Element in a BST
        // solution 2 - iterative inorder traversal        
        public static int KthSmallestInorderIterative(Node root, int k) 
        {
            Stack<Node> s = new Stack<Node>();
            Node node = root;
            
            while(node != null || s.Count > 0)
            {
                for(;node!=null;node=node.left) s.Push(node);
                
                node = s.Pop();
                if(--k==0) return node.value;
                
                node= node.right;
            }
            
            return -1;
        }
        
        // 230. Kth Smallest Element in a BST
       // solution 3 - divide and conquer for valid BST & valid k only  
        public static int KthSmallestDivideConquer(Node root, int k) {
            int count = CountNodes(root.left);
            if (k <= count) 
                return KthSmallestDivideConquer(root.left, k);
            else if (k > count + 1) 
                return KthSmallestDivideConquer(root.right, k-1-count); // 1 is counted as current node        
            
            return root.value;
        }
        
        public static int CountNodes(Node node) {
            if (node == null) return 0;
            
            return 1 + CountNodes(node.left) + CountNodes(node.right);
        }

        // 98. Validate Binary Search Tree
// Given a binary tree, determine if it is a valid binary search tree (BST).
// Assume a BST is defined as follows:
// The left subtree of a node contains only nodes with keys less than the node's key.
// The right subtree of a node contains only nodes with keys greater than the node's key.
// Both the left and right subtrees must also be binary search trees

    // solution 1
    public static bool IsValidBST1(Node root) {
        if (root == null) return true;    
        return IsValidBSTRecursive(root, long.MinValue, long.MaxValue);
	}
        
    public static bool IsValidBSTRecursive(Node root, long low, long high) {
        if (root == null) return true;
        if (root.value <= low || root.value >= high) return false;
        return IsValidBSTRecursive(root.left, low, root.value) && IsValidBSTRecursive(root.right, root.value, high);
    }
    
    // solution 2
    public static bool IsValidBST2(Node root) {
        List<int> list = new List<int>();
        CreateInorderListRecursive(root, list);
        
        int[] nums = list.ToArray();        
        for(int i=0;i<nums.Length-1;i++)
            if(nums[i] >= nums[i+1]) return false;
        
        return true;
	}
	
    public static void CreateInorderListRecursive(Node root, List<int> list)
    {
        if(root==null) return;
        
        CreateInorderListRecursive(root.left, list);
        list.Add(root.value);
        CreateInorderListRecursive(root.right, list);
    }
    
    // solution 3
    public static bool IsValidBST3(Node root) {
        bool valid = true;
        InorderCompareRecusrive(root, ref valid);
        return valid;
    }
	
    public static Node prev;
    public static void InorderCompareRecusrive(Node root, ref bool valid)
    {
        if(root==null) return;
        
        InorderCompareRecusrive(root.left, ref valid);
        
		if(prev != null && prev.value >= root.value ) { valid=false; return; }
		prev = root;            
        
        InorderCompareRecusrive(root.right, ref valid);
    }
    
    // solution 4: stack/DFS/Inorder
    public static bool IsValidBST4(Node root) {
        if(root==null) return true;
        Stack<Node> s = new Stack<Node>();
        Node p = root, prev = null;
        while (p != null || s.Count > 0) {
            while (p != null) {
                s.Push(p);
                p = p.left;
            }
            Node t = s.Pop();
            if (prev != null && prev.value >= t.value) return false;
            prev = t;
            p = t.right;
        }
        return true;
    }

	// solution 5: Iterative solution without stack and recusrive. O(N) time with O(1) space
    public static bool IsValidBST(Node root) {
        if (root==null) return true;
        Node cur = root, prev=null, parent=null;
        bool res = true;
        while (cur!=null) {
            if (cur.left==null) {
                if (parent!=null && parent.value >= cur.value) { res = false; }
                parent = cur;
                cur = cur.right;
            } 
            else 
            {
                prev = cur.left;
                while (prev.right!=null && prev.right != cur) prev = prev.right;
                
                if (prev.right==null) {
                    prev.right = cur;
                    cur = cur.left;
                } 
                else 
                {
                    prev.right = null;
                    if (parent.value >= cur.value) { res = false; }
                    parent = cur;
                    cur = cur.right;
                }
            }
        }
        
        return res;
    }

// 116. Populating Next Right Pointers in Each Node [**PREFETC BINARY TREE]
// Given the following perfect binary tree. after calling your function, the tree should look like:
//      1				    1 -> NULL
//     /  \				   /  \
//    2    3			  2 -> 3 -> NULL
//   / \  / \			 / \  / \
//  4  5  6  7			4->5->6->7 -> NULL	

// solution 1: recursive
    public static void PopulateNextRightPointer(Node2 root) {
        if(root==null) return;
        
        if(root.left!=null) root.left.next = root.right;        
        if(root.right!=null && root.next != null) root.right.next = root.next.left;        
        PopulateNextRightPointer(root.left);
        PopulateNextRightPointer(root.right);        
    }

	// solution 2[Java]: queue level-order traversal
    public void PopulateNextRightPointer2(Node2 root) {
        if(root==null) return;
        Queue<Node2> q = new Queue<Node2>();
        
        q.Enqueue(root);
        
        while(q.Count > 0)
        {
            int size = q.Count;
            for(int i=0;i< size; i++)
            {
                Node2 node = q.Dequeue();               
                
                if(node.left!=null) node.left.next = node.right;
                if(node.right!=null && node.next !=null) node.right.next = node.next.left;
                    
                if(node.left!=null) q.Enqueue(node.left);
                if(node.right!=null) q.Enqueue(node.right);
            }
        }
                
    }

	// solution 3: optimal O(1) space solution
	public void PopulateNextRightPointer3(Node2 root) {
        if (root==null) return;
        Node2 start = root, node = null;
        while (start.left!=null) {
            node = start;
            while (node!=null) {
                node.left.next = node.right;
                if (node.next!= null) node.right.next = node.next.left;
                node = node.next;
            }
            start = start.left;
        }                
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
            Tree tree = new Tree("tree");
            tree.root = Tree.CreateBTFromSortedArray(new int[] {1,2,3,4,5,6,7,8,9});
            tree.Print();
            
            Console.WriteLine("is it valid binary search tree? v1:{0},v2:{1},v3:{2},v4:{3}, v5:{4}", Tree.IsValidBST(tree.root), Tree.IsValidBST1(tree.root), Tree.IsValidBST2(tree.root), Tree.IsValidBST3(tree.root), Tree.IsValidBST4(tree.root));
            IList<int> l1 = new List<int>();            
            Tree.PreorderTraversalRecusrive(tree.root, l1);
            PrintList("Preorder Traversal Recursive", l1 );
            IList<int> l2 = new List<int>();            
            Tree.InorderTraversalRecusrive(tree.root, l2);
            PrintList("Inorder Traversal Recursive", l2);
            IList<int> l3 = new List<int>();            
            Tree.PostorderTraversalRecusrive(tree.root, l3);
            PrintList("Postorder Traversal Recursive", l3);
            IList<IList<int>> l4 = new List<IList<int>>();            
            Tree.LevelorderTraversalRecursive(tree.root, 0, l4);
            PrintList("Levelorder Traversal Recursive", l4);

            Tree.PreorderTraversalIterative(tree.root);
            Tree.InorderTraversalIterative(tree.root);
            Tree.PostorderTraversalIterative(tree.root);
            IList<IList<int>> l5 = new List<IList<int>>();            
            Tree.LevelorderTraversalIterative(tree.root, l5);
            PrintList("Levelorder Traversal Iterative", l5);
            Console.WriteLine("Max Depth: " + Tree.MaxDepth(tree.root));

            Tree tree2 = new Tree("tree2");
            tree2.root = Tree.CreateBSTFromSortedArray(new int[] {1,2,3,4,5,6,7,8,9});
            tree2.Print();

            Tree.SearchBST(tree2.root, 7);
            
            Console.WriteLine("is it valid binary search tree? v1:{0},v2:{1},v3:{2},v4:{3}, v5:{4}", Tree.IsValidBST(tree2.root), Tree.IsValidBST1(tree2.root), Tree.IsValidBST2(tree2.root), Tree.IsValidBST3(tree2.root), Tree.IsValidBST4(tree2.root));

            Console.WriteLine("Is {0} symmetric? {1}", tree2.name,  Tree.IsSymmetric(tree2.root));
            Console.WriteLine("Node Count(s): " + Tree.CountNodes(tree2.root));
            Console.WriteLine("Kth Smallest Algorithm: ");
            Console.WriteLine("InorderDivideConquer 5th smallest = " + Tree.KthSmallestDivideConquer(tree2.root, 5));
            Console.WriteLine("InorderCompare 4th smallest = " + Tree.KthSmallestInorderCompare(tree2.root, 4));
            Console.WriteLine("InorderReturn 3rd smallest = " + Tree.KthSmallestInorderReturn(tree2.root, 3)); 
            Console.WriteLine("InorderIterative 2nd smallest = " + Tree.KthSmallestInorderIterative(tree2.root, 2));

            Tree tree3 = new Tree("tree3");
            tree3.root = Tree.CreateBTFromSortedArray(new int[] {1,2,2,3,4,4,3});
            tree3.Print();            
            Console.WriteLine("Is {0} symmetric? {1} ", tree3.name,  Tree.IsSymmetric(tree3.root));
            Console.WriteLine("Node Count(s): " + Tree.CountNodes(tree3.root));
        }
    }
}