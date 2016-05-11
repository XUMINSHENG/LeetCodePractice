using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q200GraphicAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string[] inp = { "11111011111111101011", "01111111111110111110", "10111001101111111111", "11110111111111111111", "10011111111111111111", "10111111011101110111", "01111111111101101111", "11111111111101111011", "11111111110111111111", "11111111111111111111", "01111111011111111111", "11111111111111111111", "11111111111111111111", "11111011111110111111", "10111110111011110111", "11111111111101111110", "11111111111110111100", "11111111111111111111", "11111111111111111111", "11111111111111111111" };
            char[,] grid = new char[inp.Length, inp[0].Length];
            for (int i = 0; i < inp.Length; i++)
            {
                char[] tmp = inp[i].ToCharArray();
                for (int j = 0; j < tmp.Length; j++)
                {
                    grid[i, j] = tmp[j];
                }
            }

            int res = p.NumIslands(grid);
            Console.WriteLine(res);
            Console.ReadKey();


        }
        int m, n;
        Queue<int> queue;
        bool[,] visited, inQueue;
        public int NumIslands(char[,] grid)
        {
            int result = 0;
            m = grid.GetLength(0);
            n = grid.GetLength(1);
            queue = new Queue<int>();
            visited = new bool[m, n];
            inQueue = new bool[m, n];
            int i, j;

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (grid[i, j] == '0' || visited[i, j]) continue;

                    // grid[i, j] == '1'
                    visited[i, j] = true;
                    Enqueue(grid, i, j);
                    while (queue.Count != 0)
                    {
                        int tmpI = queue.Dequeue();
                        int tmpJ = queue.Dequeue();
                        visited[tmpI, tmpJ] = true;
                        Enqueue(grid, tmpI, tmpJ);
                    }
                    result++;
                }
            }


            return result;
        }

        private void Enqueue(char[,] grid, int i, int j)
        {
            //check up
            if (i > 0 && grid[i - 1, j] == '1' && !inQueue[i - 1, j] && !visited[i - 1, j])
            {
                inQueue[i - 1, j] = true;
                queue.Enqueue(i - 1);
                queue.Enqueue(j);
            }

            //check down
            if (i < m - 1 && grid[i + 1, j] == '1' && !inQueue[i + 1, j] && !visited[i + 1, j])
            {
                inQueue[i + 1, j] = true;
                queue.Enqueue(i + 1);
                queue.Enqueue(j);
            }

            //check left
            if (j > 0 && grid[i, j - 1] == '1' && !inQueue[i, j - 1] && !visited[i, j - 1])
            {
                inQueue[i, j - 1] = true;
                queue.Enqueue(i);
                queue.Enqueue(j - 1);
            }

            //check right
            if (j < n - 1 && grid[i, j + 1] == '1' && !inQueue[i, j + 1] && !visited[i, j + 1])
            {
                inQueue[i, j + 1] = true;
                queue.Enqueue(i);
                queue.Enqueue(j + 1);
            }
        }
    }
}
