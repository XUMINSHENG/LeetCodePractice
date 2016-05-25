using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheoryRelated
{
    class Program
    {
        static void Main(string[] args)
        {


            Program p = new Program();
            //Console.WriteLine(p.CountPrimes(1000));
            p.NthUglyNumber(1407);

        }

        // Q204
        // sieves
        public int CountPrimes(int n)
        {
            if (n < 2) return 0;
            int cnt = 0;
            bool[] isComposite = new bool[n + 1];
            isComposite[0] = true;
            isComposite[1] = true;
            int idx = 2;

            while (idx <= n)
            {
                for (int i = idx + idx; i <= n; i += idx)
                {
                    isComposite[i] = true;
                }

                // find next prime
                while (++idx <= n && isComposite[idx]) { }
                cnt++;
            }

            return cnt;
        }

        // Q263
        public bool IsUgly(int num)
        {
            if (num == 0) return false;
            bool isActed = true;
            int tmp;
            while (isActed)
            {
                isActed = false;
                //2
                tmp = num / 2;
                if(num - tmp * 2 == 0){
                    isActed = true;
                    num /= 2;
                }

                //3
                tmp = num / 3;
                if (num - tmp * 3 == 0)
                {
                    isActed = true;
                    num /= 3;
                }

                //5
                tmp = num / 5;
                if (num - tmp * 5 == 0)
                {
                    isActed = true;
                    num /= 5;
                }
                
            }

            if (num == 1) 
                return true;
            else 
                return false;
        }

        // Q264
        public int NthUglyNumber(int n) {
            int res = 0;
            
            Heap minHeap = new Heap(n * 3);
            minHeap.Insert(1);

            for (int i = 0; i < n;i++ )
            {
                res = minHeap.DeleteMin();
                while (res == minHeap.PeekMin())
                {
                    minHeap.DeleteMin();
                }

                int tmp;
                tmp = res * 2;
                if (tmp > 0)
                {
                    minHeap.Insert(tmp);
                    tmp = res * 3;
                    if (tmp > 0)
                    {
                        minHeap.Insert(tmp);
                        tmp = res * 5;
                        if (tmp > 0)
                        {
                            minHeap.Insert(tmp);
                        }
                    }
                }
                
            }

            return res;
        }
    }
}

public class Heap
{

    private int size;
    private int Max_Size;
    private int[] array;

    public Heap(int maxSize)
    {
        this.Max_Size = maxSize;

        this.array = new int[maxSize + 1];
        this.size = 0;
        this.array[0] = int.MinValue;
    }

    public void Insert(int x)
    {
        int i;
        if (size >= Max_Size) Console.WriteLine("PQ is full");
        else
        {
            i = ++size;
            while (array[i / 2] > x)
            {
                array[i] = array[i / 2];
                i /= 2;
            }
            array[i] = x;
        }

    }

    public int PeekMin()
    {
        if (size == 0)
        {
            return array[0];
        }
        
        return array[1];

    }
    public int DeleteMin(){
		int i, child;
		if (size == 0){
            Console.WriteLine("PQ is empty");
			return array[0];
		}
		
		int min, last;
		min = array[1];
		last = array[size];
		
		for(i=1; i*2 < size;i=child){
			child = i * 2;
			
			// right child < left child, move smaller one
			if((child != size)&&(array[child+1]<array[child])){
				child ++;
			}
			
			// compare last with the smaller of two children
			if(last > array[child]){
				array[i] = array[child];
			}else{
				break;
			}
		}
		array[i] = last;
		size--;
		return min;
		
	}

}
