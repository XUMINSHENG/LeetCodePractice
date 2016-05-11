using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q106_107_ConstructBT
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

            TreeNode root = new TreeNode(1);
            TreeNode n1 = new TreeNode(2);
            TreeNode n2 = new TreeNode(3);
            root.left = n1;
            root.right = n2;
            TreeNode n3 = new TreeNode(4);
            TreeNode n4 = new TreeNode(5);
            TreeNode n7 = new TreeNode(6);
            n1.left = n3;
            n1.right = n4;
            n2.left = n7;

            Program p = new Program();

            //p.PreOrderTraverse(root);
            //Console.WriteLine();
            //p.InOrderTraverse(root);
            //Console.WriteLine();
            //p.PostOrderTraverse(root);
            //Console.WriteLine();

            int[] preorder = 
                {1,2,4,5,3,6 };

            int[] inorder =
                {4,2,5,1,6,3 };
                //{ 1, 2, 3, 4 };
            int[] postorder =
                { 4,5,2,6,3,1 };
                //{ 1, 4, 3, 2 };

            TreeNode preTree = p.BuildTree(preorder, inorder);
            p.PreOrderTraverse(preTree);

            Console.WriteLine();
            Console.ReadKey();
        }

        // build from pre and in
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
        
    
            if (inorder == null || inorder.Length == 0) return null;
            return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree(int[] preorder, int preLeftIdx, int preRightIdx, int[] inorder, int inLeftIdx, int inRightIdx)
        {
            TreeNode root = new TreeNode(preorder[preLeftIdx]);

            //find root index in inorder
            int rootOfIn = -1;
            for (int i = inLeftIdx; i <= inRightIdx; i++)
            {
                if (inorder[i] == root.val)
                {
                    rootOfIn = i;
                    break;
                }
            }

            //find left sub
            int noOfNodeInSubLeft = rootOfIn - inLeftIdx;
            if (noOfNodeInSubLeft == 0)
            {
                root.left = null;
            }
            else
            {

                root.left = BuildTree(preorder, preLeftIdx + 1, preLeftIdx + noOfNodeInSubLeft, inorder, inLeftIdx, inLeftIdx + noOfNodeInSubLeft - 1);
            }

            //find right sub
            int noOfNodeInSubRight = inRightIdx - rootOfIn;
            if (noOfNodeInSubRight == 0)
            {
                root.right = null;
            }
            else
            {

                root.right = BuildTree(preorder, preRightIdx - noOfNodeInSubRight + 1, preRightIdx, inorder, inRightIdx - noOfNodeInSubRight + 1, inRightIdx);
            }

            return root;
        }

        //// build from in and post
        //public TreeNode BuildTree(int[] inorder, int[] postorder)
        //{
        //    if (inorder == null || inorder.Length == 0) return null;
        //    TreeNode root = BuildTree(inorder,0,inorder.Length-1,postorder,0,postorder.Length-1);
        //    return root;
        //}

        //private TreeNode BuildTree(int[] inorder, int inLeftIdx, int inRightIdx, int[] postorder, int postLeftIdx, int postRightIdx)
        //{
        //    TreeNode root = new TreeNode(postorder[postRightIdx]);

        //    //find root index in inorder
        //    int rootOfIn=-1;
        //    for (int i = inLeftIdx; i <= inRightIdx; i++)
        //    {
        //        if (inorder[i] == root.val)
        //        {
        //            rootOfIn = i;
        //            break;
        //        }
        //    }

        //    //find right sub
        //    int noOfNodeInSubRight = inRightIdx - rootOfIn;
        //    if (noOfNodeInSubRight == 0)
        //    {
        //        root.right = null;
        //    }
        //    else
        //    {

        //        root.right = BuildTree(inorder, rootOfIn + 1, inRightIdx, postorder, postRightIdx - noOfNodeInSubRight, postRightIdx - 1);
        //    }
            

        //    //find left sub
        //    int noOfNodeInSubLeft = rootOfIn - inLeftIdx;
        //    if (noOfNodeInSubLeft == 0)
        //    {
        //        root.left = null;
        //    }else
        //    {

        //        root.left = BuildTree(inorder, inLeftIdx, rootOfIn - 1, postorder, postLeftIdx, postLeftIdx + noOfNodeInSubLeft - 1);
        //    }

        //    return root;
        //}


        public void PreOrderTraverse(TreeNode node)
        {
            if (node == null) return;

            Console.Write(node.val + " ");
            
            PreOrderTraverse(node.left);
            
            PreOrderTraverse(node.right);
            
        }

        public void InOrderTraverse(TreeNode node)
        {
            if (node == null) return;
            
            InOrderTraverse(node.left);
            
            Console.Write(node.val + " ");

            InOrderTraverse(node.right);
            

        }

        public void PostOrderTraverse(TreeNode node)
        {
            if (node == null) return;
            
            PostOrderTraverse(node.left);
            
            PostOrderTraverse(node.right);
            
            Console.Write(node.val + " ");

        }

        
    }
}
