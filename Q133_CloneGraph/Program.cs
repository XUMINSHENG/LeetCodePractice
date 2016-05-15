using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q133_CloneGraph
{

    public class UndirectedGraphNode {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // make graph
            //UndirectedGraphNode g0 = new UndirectedGraphNode(0);
            //UndirectedGraphNode g1 = new UndirectedGraphNode(1);
            //UndirectedGraphNode g2 = new UndirectedGraphNode(2);

            //g0.neighbors.Add(g1);
            //g1.neighbors.Add(g0);

            //g0.neighbors.Add(g2);
            //g2.neighbors.Add(g0);

            //g1.neighbors.Add(g2);
            //g2.neighbors.Add(g1);

            //g2.neighbors.Add(g2);

            // -1 1
            UndirectedGraphNode g0 = new UndirectedGraphNode(-1);
            UndirectedGraphNode g1 = new UndirectedGraphNode(1);
            

            g0.neighbors.Add(g1);
            //g1.neighbors.Add(g0);


            Program p = new Program();
            p.CloneGraph(g0);
            
        }
        
        // using hash, according to req, label of nodes are unique
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null) return null;

            UndirectedGraphNode res = new UndirectedGraphNode(node.label);

            // store nodes
            List<UndirectedGraphNode> oriNodeList = new List<UndirectedGraphNode>();
            List<UndirectedGraphNode> cpyNodeList = new List<UndirectedGraphNode>();
            oriNodeList.Add(node);
            cpyNodeList.Add(res);
            int cnt = 0;
            // store the node's index
            Dictionary<int, int> oriDict = new Dictionary<int, int>();
            Dictionary<int, int> cpyDict = new Dictionary<int, int>();
            oriDict.Add(node.label, cnt);
            cpyDict.Add(res.label, cnt);
            cnt++;

            // pointer
            UndirectedGraphNode oriNode;
            UndirectedGraphNode cpyNode;
            
            for (int i = 0; i < oriNodeList.Count;i++ )
            {
                oriNode = oriNodeList[i];
                cpyNode = cpyNodeList[i];
                foreach (UndirectedGraphNode ptrOri in oriNode.neighbors)
                {
                    if (ptrOri == oriNode)
                    {
                        // connect to self
                        cpyNode.neighbors.Add(cpyNode);
                    }
                    else
                    {
                        // connect to others
                        int idx = -1;
                        if (oriDict.TryGetValue(ptrOri.label, out idx))
                        {
                            // existing ones
                            cpyNode.neighbors.Add(cpyNodeList[idx]);
                        }
                        else
                        {
                            // new node
                            UndirectedGraphNode ptrCpy = new UndirectedGraphNode(ptrOri.label);
                            cpyNode.neighbors.Add(ptrCpy);

                            oriNodeList.Add(ptrOri);
                            cpyNodeList.Add(ptrCpy);

                            oriDict.Add(ptrOri.label, cnt);
                            cpyDict.Add(ptrCpy.label, cnt);
                            cnt++;

                        }

                    }

                }
            }

            return res;
        }

        // using array, exceed time limitation
        public UndirectedGraphNode CloneGraph_List(UndirectedGraphNode node)
        {
            if (node == null) return null;
            UndirectedGraphNode res = new UndirectedGraphNode(node.label);

            // store nodes to visit
            List<UndirectedGraphNode> oriNodeList = new List<UndirectedGraphNode>();
            List<UndirectedGraphNode> cpyNodeList = new List<UndirectedGraphNode>();
            oriNodeList.Add(node);
            cpyNodeList.Add(res);

            // pointer
            UndirectedGraphNode oriNode;
            UndirectedGraphNode cpyNode;

            while (oriNodeList.Count > 0)
            {
                oriNode = oriNodeList[0];
                cpyNode = cpyNodeList[0];
                oriNodeList.Remove(oriNode);
                cpyNodeList.Remove(cpyNode);
                foreach (UndirectedGraphNode ptrOri in oriNode.neighbors)
                {
                    if (ptrOri == oriNode)
                    {
                        // connect to self
                        cpyNode.neighbors.Add(cpyNode);
                    }
                    else
                    {
                        // connect to others
                        int idx = oriNodeList.IndexOf(ptrOri);
                        if (idx != -1)
                        {
                            // existing ones
                            cpyNode.neighbors.Add(cpyNodeList[idx]);
                            cpyNodeList[idx].neighbors.Add(cpyNode);
                        }
                        else
                        {
                            // new node
                            UndirectedGraphNode ptrCpy = new UndirectedGraphNode(ptrOri.label);
                            cpyNode.neighbors.Add(ptrCpy);
                            ptrCpy.neighbors.Add(cpyNode);

                            oriNodeList.Add(ptrOri);
                            cpyNodeList.Add(ptrCpy);
                        }

                        // remove the link to node
                        ptrOri.neighbors.Remove(oriNode);

                    }

                }
            }

            return res;
        }

    }
}
