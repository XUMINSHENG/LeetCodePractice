using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q297SeriDeseBT
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
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            root.left = n2;
            root.right = n3;
            n2.left = n4;
            n2.right = n5;

            Codec codec = new Codec();
            string str = codec.serialize(root);
            TreeNode nh = codec.deserialize(str);

        }

        

    }

    public class Codec
    {
        
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            //StringBuilder sb = new StringBuilder();
            List<string> list = new List<string>();
            PreOrder(list, root);

            return String.Join(",", list.ToArray());
        }

        private void PreOrder(List<string> list, TreeNode node)
        {
            if (node == null)
                list.Add("#");
            else
            {
                list.Add(node.val.ToString());
                PreOrder(list, node.left);
                PreOrder(list, node.right);
            }

        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            string[] list = data.Split(',');
            
            if (list[0] == "#") return null;

            TreeNode root = new TreeNode(Int32.Parse(list[0]));
            Stack<TreeNode> stack = new Stack<TreeNode>(list.Length/2);

            TreeNode ptr = root,node;
            int successiveNull = 0;

            for (int i = 1; i < list.Length - 1; i++)
            {
                
                if (list[i] != "#")
                {
                    node = new TreeNode(Int32.Parse(list[i]));
                    if (successiveNull==0)
                    {
                        ptr.left = node;
                        stack.Push(ptr);
                    }else{
                        ptr.right = node;
                        successiveNull = 0;
                    }

                    
                    ptr = node;

                }
                else{
                    successiveNull++;

                    if (successiveNull!=1)
                    {
                        //ptr.right = null;
                        ptr = stack.Pop();
                    }

                }
            }

            return root;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
