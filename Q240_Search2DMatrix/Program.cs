using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q240_Search2DMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] mat = {
                    //{1,   4,  7, 11, 15, 31},
                    //{2,   5,  8, 12, 19, 32},
                    //{3,   6,  9, 16, 22, 33},
                    //{10, 13, 14, 17, 24, 34},
                    //{18, 21, 23, 26, 30, 35}
                    
                    //{5,8,11,11,12,12,14,14,19},
                    //{9,9,14,17,17,19,21,26,27},
                    //{12,15,15,21,21,26,30,35,36},
                    //{17,17,20,25,28,30,32,35,39},
                    //{20,21,22,29,30,32,34,36,43},
                    //{24,24,25,31,36,40,40,43,45},
                    //{28,31,32,36,36,45,49,53,56},
                    //{29,33,36,39,40,50,54,57,57},
                    //{34,36,37,41,42,53,55,58,59},
                    //{37,40,42,44,47,53,56,58,62}
                    
                    {3,4,5,8},
                    {7,10,15,17},
                    {11,12,17,18}

                };

            Program p = new Program();
            bool b = p.SearchMatrix(mat, 19);

        }

        public bool SearchMatrix(int[,] matrix, int target)
        {

            return Search(matrix, target, new int[] { 0, 0 }, new int[] { matrix.GetLength(0)-1, matrix.GetLength(1)-1 });

        }

        private bool Search(int[,] matrix, int target, int[] start, int[] end)
        {

            if (start[0] == end[0]) return searchInSingleRow(matrix,target,start,end);
            else if (start[1] == end[1]) return searchInSingleCol(matrix, target, start, end);

            // 0 represents Y, 1 represents X
            int[] lowerBound = null, upperBound = null;
            int[] mid = new int[] {
                    (start[0] + end[0]) / 2,
                    (start[1] + end[1]) / 2,
                };

            while (true)
            {
                if (target == matrix[mid[0], mid[1]])
                {
                    return true;
                }
                else if(target>matrix[mid[0],mid[1]]){
                    lowerBound = new int[] { mid[0], mid[1] };
                    mid[0]++;
                    mid[1]++;
                }
                else
                {
                    upperBound = new int[] { mid[0], mid[1] };
                    mid[0]--;
                    mid[1]--;
                }


                if (lowerBound != null && upperBound != null) {
                    // divide and conqure
                    // left bottom block
                    bool s1 = Search(matrix, target,
                        new int[] { upperBound[0], start[1] }, new int[] { end[0], lowerBound[1] });
                    if (s1) return true;

                    // right top block
                    bool s2 = Search(matrix, target,
                        new int[] { start[0], upperBound[1] }, new int[] { lowerBound[0], end[1] });
                    if (s2) return true;
                    return false;
                }

                if (mid[0] < start[0] && mid[1] < start[1] || mid[0] > end[0] && mid[1] > end[1])
                {
                    return false;
                }
                else if (mid[0] < start[0])
                {
                    //exceed top border
                    bool s = Search(matrix, target,
                        new int[] { start[0], start[1] }, new int[] { end[0], mid[1] });
                    return s;
                }
                else if (mid[1] < start[1])
                {
                    //exceed left border
                    bool s = Search(matrix, target,
                        new int[] { start[0], start[1] }, new int[] { mid[0], end[1] });
                    return s;
                }
                else if (mid[1] > end[1])
                {
                    //exceed right border
                    bool s = Search(matrix, target,
                        new int[] { mid[0], start[1] }, new int[] { end[0], end[1] });
                    return s;
                }
                else if (mid[0] > end[0])
                {
                    //exceed bottom border
                    bool s = Search(matrix, target,
                        new int[] { start[0], mid[1] }, new int[] { end[0], end[1] });
                    return s;
                }
                //(mid[0] >= start[0] && mid[0] <= end[0] && mid[1] >= start[1] && mid[1] <= end[1])
            }


        }

        private bool searchInSingleRow(int[,] matrix, int target, int[] start, int[] end)
        {
            int row = start[0];
            int ptrStart = start[1], ptrEnd = end[1];
            

            while (ptrStart<=ptrEnd)
            {
                int ptrMid = (ptrStart + ptrEnd) / 2;
                if (target == matrix[row, ptrMid])
                {
                    return true;
                }
                else if (target > matrix[row, ptrMid])
                {
                    ptrStart = ptrMid + 1;
                }
                else{
                    ptrEnd = ptrMid - 1;
                }

            }
            
            return false;
        }

        private bool searchInSingleCol(int[,] matrix, int target, int[] start, int[] end)
        {
            int col = start[1];
            int ptrStart = start[0], ptrEnd = end[0];


            while (ptrStart <= ptrEnd)
            {
                int ptrMid = (ptrStart + ptrEnd) / 2;
                if (target == matrix[ptrMid, col])
                {
                    return true;
                }
                else if (target > matrix[ptrMid, col])
                {
                    ptrStart = ptrMid + 1;
                }
                else
                {
                    ptrEnd = ptrMid - 1;
                }

            }

            return false;
        }
    }
}
