using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q332_ReconstructGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            p.FindItinerary(new string[,]
                //{{"JFK","KUL"},{"JFK","NRT"},{"NRT","JFK"}}
                { { "JFK", "SFO" }, { "JFK", "ATL" }, { "SFO", "ATL" }, { "ATL", "JFK" }, { "ATL", "SFO" } }
                //{ { "AXA", "EZE" }, { "EZE", "AUA" }, { "ADL", "JFK" }, { "ADL", "TIA" }, { "AUA", "AXA" }, { "EZE", "TIA" }, { "EZE", "TIA" }, { "AXA", "EZE" }, { "EZE", "ADL" }, { "ANU", "EZE" }, { "TIA", "EZE" }, { "JFK", "ADL" }, { "AUA", "JFK" }, { "JFK", "EZE" }, { "EZE", "ANU" }, { "ADL", "AUA" }, { "ANU", "AXA" }, { "AXA", "ADL" }, { "AUA", "JFK" }, { "EZE", "ADL" }, { "ANU", "TIA" }, { "AUA", "JFK" }, { "TIA", "JFK" }, { "EZE", "AUA" }, { "AXA", "EZE" }, { "AUA", "ANU" }, { "ADL", "AXA" }, { "EZE", "ADL" }, { "AUA", "ANU" }, { "AXA", "EZE" }, { "TIA", "AUA" }, { "AXA", "EZE" }, { "AUA", "SYD" }, { "ADL", "JFK" }, { "EZE", "AUA" }, { "ADL", "ANU" }, { "AUA", "TIA" }, { "ADL", "EZE" }, { "TIA", "JFK" }, { "AXA", "ANU" }, { "JFK", "AXA" }, { "JFK", "ADL" }, { "ADL", "EZE" }, { "AXA", "TIA" }, { "JFK", "AUA" }, { "ADL", "EZE" }, { "JFK", "ADL" }, { "ADL", "AXA" }, { "TIA", "AUA" }, { "AXA", "JFK" }, { "ADL", "AUA" }, { "TIA", "JFK" }, { "JFK", "ADL" }, { "JFK", "ADL" }, { "ANU", "AXA" }, { "TIA", "AXA" }, { "EZE", "JFK" }, { "EZE", "AXA" }, { "ADL", "TIA" }, { "JFK", "AUA" }, { "TIA", "EZE" }, { "EZE", "ADL" }, { "JFK", "ANU" }, { "TIA", "AUA" }, { "EZE", "ADL" }, { "ADL", "JFK" }, { "ANU", "AXA" }, { "AUA", "AXA" }, { "ANU", "EZE" }, { "ADL", "AXA" }, { "ANU", "AXA" }, { "TIA", "ADL" }, { "JFK", "ADL" }, { "JFK", "TIA" }, { "AUA", "ADL" }, { "AUA", "TIA" }, { "TIA", "JFK" }, { "EZE", "JFK" }, { "AUA", "ADL" }, { "ADL", "AUA" }, { "EZE", "ANU" }, { "ADL", "ANU" }, { "AUA", "AXA" }, { "AXA", "TIA" }, { "AXA", "TIA" }, { "ADL", "AXA" }, { "EZE", "AXA" }, { "AXA", "JFK" }, { "JFK", "AUA" }, { "ANU", "ADL" }, { "AXA", "TIA" }, { "ANU", "AUA" }, { "JFK", "EZE" }, { "AXA", "ADL" }, { "TIA", "EZE" }, { "JFK", "AXA" }, { "AXA", "ADL" }, { "EZE", "AUA" }, { "AXA", "ANU" }, { "ADL", "EZE" }, { "AUA", "EZE" } }
            );


        }

        //long addCnt = 0;
        List<List<string>> res;
        public IList<string> FindItinerary(string[,] tickets)
        {
            res = new List<List<string>>();
            List<string> path = new List<string>();
            int length = tickets.GetLength(0);
            bool[] visited = new bool[length];
            string from = "JFK";
            path.Add(from);

            List<string[]> sortList = new List<string[]>();
            for (int i = 0; i < length; i++)
            {
                sortList.Add(new string[] { tickets[i, 0], tickets[i, 1] });
            }
            sortList.Sort(new StringArrayCompare());


            // traverse to get results
            DFS(sortList, visited, from, path, 1);

            return res[0];
        }

        private void DFS(List<string[]> tickets, bool[] visited, string from, List<string> path, int stops)
        {
            if (res.Count > 0) return;

            int length = tickets.Count;
            
            // foreach (v,w)
            for (int i = 0; i < length; i++)
            {
                
                if (visited[i]) continue;
                
                // find matches
                if (tickets[i][0] == from)
                {

                    string to = tickets[i][1];
                    path.Add(to);
                    
                    // base case
                    if (stops == length)
                    {
                        
                        //Console.WriteLine(addCnt++);
                        //// replace 
                        //res.Clear();
                        List<string> tmp = new List<string>(path);
                        res.Add(tmp);
                    }
                    else
                    {
                        
                        // visit
                        visited[i] = true;
                        // recursion
                        DFS(tickets, visited, to, path, stops + 1);
                        visited[i] = false;
                    }
                    path.RemoveAt(path.Count - 1);
                    
                }
            }

        }
        public class StringArrayCompare : IComparer<string[]>
        {
            public int Compare(string[] x, string[] y)
            {
                if (x[0].CompareTo(y[0])>0 )
                    return 1;
                if (x[0].CompareTo(y[0]) < 0)
                    return -1;
                else
                {
                    if (x[1].CompareTo(y[1]) > 0)
                        return 1;
                    if (x[1].CompareTo(y[1]) < 0)
                        return -1;
                    else
                        return 0;
                }
                    
            }
        }

    }
}
