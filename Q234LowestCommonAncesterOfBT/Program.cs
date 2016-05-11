using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q234LowestCommonAncesterOfBT
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
            root.right = n2;
            TreeNode n3 = new TreeNode(1);
            TreeNode n4 = new TreeNode(4);
            TreeNode n7 = new TreeNode(2);
            n1.left = n3;
            n1.right = n4;
            n3.right = n7;

            Program p = new Program();

            Console.WriteLine(p.LowestCommonAncestor(root, n3, n7).val);
            Console.ReadKey();
        }

        // 184ms
        static Stack<TreeNode> pst, qst;
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            pst = new Stack<TreeNode>();
            qst = new Stack<TreeNode>();
            if (root == null) return null;

            TreeNode result, ptr = root;
            bool pb, qb;
            // common ance is that both p and q are child
            // lowest is that one node that both are true, but not for each of its child

            pb = isChildOf(ptr, p, pst);
            qb = isChildOf(ptr, q, qst);

            result = root;
            while(true){

                if (pst.Count == 0 || qst.Count == 0 || pst.Peek() != qst.Peek()) return result;
                else
                {
                    result = pst.Pop();
                    qst.Pop();
                }
                
            }
        }

        private bool isChildOf(TreeNode ance, TreeNode child, Stack<TreeNode> stack)
        {
            
            //bool result = false;
            
            if (ance == child)
            {
                //result = true;
                stack.Push(ance);
                return true;
            }

            if (ance.left != null && isChildOf(ance.left, child, stack))
            {
                //result = true;
                stack.Push(ance);
                return true;
            }

            if (ance.right != null && isChildOf(ance.right, child, stack))
            {
                //result = true;
                stack.Push(ance);
                return true;
            }

            return false;
        }



        
        ////252ms
        //static Dictionary<string, bool> dict; 
        //public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        //{
        //    dict = new Dictionary<string, bool>();
        //    TreeNode result = findCommonAncestor(root, p, q);
        //    if (result == null) return root;
        //    return result;
        //}

        //private TreeNode findCommonAncestor(TreeNode node, TreeNode p, TreeNode q)
        //{
        //    if (node == null) return null;

        //    TreeNode result, ptr = node;
        //    bool pb, qb;
        //    // common ance is that both p and q are child
        //    // lowest is that one node that both are true, but not for each of its child

        //    pb = isChildOf(ptr, p);
        //    qb = isChildOf(ptr, q);
        //    if (pb && qb)
        //    {

        //        result = findCommonAncestor(ptr.left, p, q);
        //        if (result != null) return result;

        //        result = findCommonAncestor(ptr.right, p, q);
        //        if (result != null) return result;

        //        return ptr;
        //    }
        //    else return null;

        //}

        //private bool isChildOf(TreeNode ance, TreeNode child)
        //{
        //    string key = ance.GetHashCode() + "-" + child.GetHashCode();
        //    bool result = false;
        //    if (dict.TryGetValue(key, out result))
        //    {
        //        return result;
        //    }


        //    if (ance == child || ance.left == child || ance.right == child)
        //    {
        //        result = true;
        //        dict.Add(key, result);
        //        return true;
        //    }

        //    if (ance.left != null && isChildOf(ance.left, child))
        //    {
        //        result = true;
        //        dict.Add(key, result);
        //        return true;
        //    }

        //    if (ance.right != null && isChildOf(ance.right, child))
        //    {
        //        result = true;
        //        dict.Add(key, result);
        //        return true;
        //    }

        //    result = false;
        //    dict.Add(key, result);
        //    return false;
        //}

    }
}
