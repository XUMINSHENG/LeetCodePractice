using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q124_BinaryTreeDFS
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
            TreeNode root = new TreeNode(9);
            TreeNode n1 = new TreeNode(6);
            TreeNode n2 = new TreeNode(-3);

            TreeNode n3 = new TreeNode(-6);
            TreeNode n4 = new TreeNode(2);
            TreeNode n5 = new TreeNode(2);
            TreeNode n6 = new TreeNode(-6);
            TreeNode n7 = new TreeNode(-6);
            TreeNode n8 = new TreeNode(-6);

            root.left = n1;
            root.right = n2;
            n2.left = n3;
            n2.right = n4;
            

            n4.left = n5;
            n5.left = n6;
            n5.right = n7;
            n6.left = n8;

            Program p = new Program();
            int res = p.MaxPathSum(root);
            Console.WriteLine(res);
            Console.ReadKey();
            
        }

        int max;
        public int MaxPathSum(TreeNode root)
        {

            if (root == null) return 0;
            max = int.MinValue;
            CalcPathSum(root);

            return max;
        }

        public int CalcPathSum(TreeNode node)
        {
            int pathSum = node.val;
            if (max < pathSum) max = pathSum;

            int pathLeft = 0, pathRight = 0;

            if (node.left != null)
            {
                pathLeft = CalcPathSum(node.left);
                if (pathLeft > 0)
                {
                    pathSum += pathLeft;
                    if (max < pathSum) max = pathSum;
                }
            }

            if (node.right != null)
            {
                pathRight = CalcPathSum(node.right);
                if (pathRight > 0)
                {
                    pathSum += pathRight;
                    if (max < pathSum) max = pathSum;
                }
            }

            // max between left path and right path, should not include both
            int res = node.val + (pathLeft > pathRight ? pathLeft : pathRight);
            return res>0?res:0;
        }

    }
}
