using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q235LowestCommonAncesterOfBST
{

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //// 0 1 2
            //TreeNode root = new TreeNode(0);
            //TreeNode left = new TreeNode(1);
            //TreeNode right = new TreeNode(2);

            //[5,3,6,1,4,null,null,null,2]
            //node with value 4
            //node with value 2
            TreeNode root = new TreeNode(5);
            TreeNode n1 = new TreeNode(3);
            TreeNode n2 = new TreeNode(6);
            root.left = n1;
            root.right = n2;
            TreeNode n3 = new TreeNode(1);
            TreeNode n4 = new TreeNode(4);
            TreeNode n7 = new TreeNode(2);
            n1.left = n3;
            n1.right = n4;
            n4.right = n7;


            //root.left = left;
            //left.right = right;

            Program p = new Program();
            
            Console.WriteLine(p.LowestCommonAncestor(root, n4, n7).val);
            Console.ReadKey();
        }

        // 196
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
           
            TreeNode result = findCommonAncestor(root, p, q);
            if (result == null) return root;
            return result;
        }
        private TreeNode findCommonAncestor(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == null) return null;

            if ((p.val <= node.val && node.val <= q.val)
                ||
                (q.val <= node.val && node.val <= p.val)) return node;
            else if (p.val < node.val && q.val < node.val)
            {
                return findCommonAncestor(node.left, p, q);
            }
            else if (p.val > node.val && q.val > node.val)
            {
                return findCommonAncestor(node.right, p, q);
            }
            else return null;

        }


        //204 ms
        public TreeNode LowestCommonAncestorByTraverse(TreeNode root, TreeNode p, TreeNode q)
        {

            TreeNode result = findCommonAncestor(root, p, q);
            if (result == null) return root;
            return result;
        }

        private TreeNode findCommonAncestorByTraverse(TreeNode node, TreeNode p, TreeNode q)
        {
            if(node == null)return null;

            TreeNode result, ptr = node;
            bool pb, qb;
            // common ance is that both p and q are child
            // lowest is that one node that both are true, but not for each of its child
            
            pb = isChildOf(ptr, p);
            qb = isChildOf(ptr, q);
            if (pb && qb)
            {

                result = findCommonAncestor(ptr.left, p, q);
                if (result != null) return result;
                    
                result = findCommonAncestor(ptr.right, p, q);
                if (result != null) return result;

                return ptr;
            }
            else return null;

        }

        private bool isChildOf(TreeNode ance, TreeNode child)
        {

            if (ance == child || ance.left == child || ance.right == child) return true;

            if (ance.left != null && isChildOf(ance.left, child)) return true;

            if (ance.right != null && isChildOf(ance.right, child)) return true;

            return false;
        }
    
    }
}
