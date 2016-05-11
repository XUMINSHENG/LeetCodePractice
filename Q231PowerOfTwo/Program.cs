using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q231PowerOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.IsPowerOfTwo(1073741824));
            Console.ReadKey();

        }

        public bool IsPowerOfTwo(int n)
        {
            int num;
            if (n == 1) return true;
            else
            {
                if (n <= 1073741824)
                {
                    num = 2;
                }
                else
                {
                    return false;
                }

                do
                {
                    if (num == n) return true;
                    num = num << 1;
                } while (num <= n);

                return false;

            }

        }
    }
}
