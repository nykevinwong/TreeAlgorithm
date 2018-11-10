

namespace Algorithm
{
    public class Node<T>
    {
        public Node<T> left;
        public Node<T> right;
        public T value;
        public Node(T value)
        {
            this.value = value;
        }
    }

    public class Tree
    {
        Node<int> root;
        public Tree(int[] nums)
        {
            this.root = this.CreateTreeFromSortedArray(nums, 0);
        }

        public Node<int> CreateTreeFromSortedArray(int[] nums, int start)
        {
            int left = start*2+1;
            int right = start*2+2;
            Node<int> node = new Node<int>(nums[start]);

            if(left < nums.Length) node.left = CreateTreeFromSortedArray(nums, left);
            if(right < nums.Length) node.right = CreateTreeFromSortedArray(nums, right);
            
            return node;
        }

        public void Print()
        {
            Print(root);
        }

        private void Print(Node<int> root)
        {
            if(root==null) return;
        }
    }

    public class TreeTraversal
    {
        static void Main(string[] argv)
        {
            int[] nums = {1,2,3,4,5,6,7,8};
            Tree tree = new Tree(nums);
        }
    }
    
}