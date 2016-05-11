using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q207_CourseSche
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.FindOrder(2, new int[,] { { 1, 0 }});

            Console.WriteLine();
            //Console.ReadKey();
        }

        int totalCnt;
        int[] indegree;
        //bool[] visited;
        Queue<int> q;
        int[] order;

        // the II question has a different defination of the prerequisites
        // first element is the course, 2nd is the prerequisite
        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            int cnt = 0;
            totalCnt = numCourses;
            indegree = new int[totalCnt];
            order = new int[totalCnt];
            //visited = new bool[totalCnt];
            q = new Queue<int>();

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                indegree[prerequisites[i, 0]]++;
            }

            for (int i = 0; i < totalCnt; i++)
            {
                if (indegree[i] == 0) q.Enqueue(i);
            }

            while (q.Count > 0)
            {
                int next = q.Dequeue();
                order[cnt++] = next;

                string s1=""; s1.IndexOf("");
                // for all vertex adjacent to next
                for (int j = 0; j < prerequisites.GetLength(0); j++)
                {
                    if (prerequisites[j, 1] == next)
                    {
                        if (--indegree[prerequisites[j, 0]] == 0)
                        {
                            q.Enqueue(prerequisites[j, 0]);
                        }
                    }
                }
                //visited[next] = true;
            }

            if (cnt == totalCnt)
            {
                return order;
            }
            else
                return new int[totalCnt];
        }

        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            int cnt = 0;
            totalCnt = numCourses;
            indegree = new int[totalCnt];
            //visited = new bool[totalCnt];
            q = new Queue<int>();

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                indegree[prerequisites[i, 1]]++;
            }

            for (int i = 0; i < totalCnt; i++)
            {
                if (indegree[i] == 0) q.Enqueue(i);
            }

            while(q.Count>0)
            {
                int next = q.Dequeue();
                cnt++;

                // for all vertex adjacent to next
                for (int j = 0; j < prerequisites.GetLength(0); j++)
                {
                    if (prerequisites[j, 0] == next)
                    {
                        if (--indegree[prerequisites[j, 1]] == 0)
                        {
                            q.Enqueue(prerequisites[j, 1]);
                        }
                    }
                }
                //visited[next] = true;
            }

            if(cnt==totalCnt){
                return true;
            }else 
                return false;
        }

        //private int FindNextVertex()
        //{
        //    for(int i=0;i<totalCnt;i++){
        //        if (indegree[i] == 0 && !visited[i]) return i;
        //    }
        //    return -1;
        //}

        
    }
}
