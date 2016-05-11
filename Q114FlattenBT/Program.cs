using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q114FlattenBT
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            TreeNode n1 = new TreeNode(3);
            TreeNode n2 = new TreeNode(6);
            root.left = n1;
            n1.left = n2;
            //TreeNode n3 = new TreeNode(1);
            //TreeNode n4 = new TreeNode(4);
            //TreeNode n7 = new TreeNode(2);
            //n1.left = n3;
            //n1.right = n4;
            //n3.right = n7;

            Program p = new Program();
            p.Flatten(root);
            Console.WriteLine(root.val);
            Console.ReadKey();
        }

        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            FlatTree(root);

        }


        // return tail?
        private TreeNode FlatTree(TreeNode node)
        {
            

            //base case - leaf
            if (node.left == null && node.right == null) return node;

            TreeNode rightTail = null;
            if (node.right != null)
                rightTail = FlatTree(node.right);

            TreeNode leftTail = null;
            if (node.left != null)
            {
                leftTail = FlatTree(node.left);
                leftTail.right = node.right;
                node.right = node.left;
                node.left = null;
            }

            return rightTail == null ? leftTail : rightTail;

        }

    }
}
