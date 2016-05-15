using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q341_FlatenNestedListIterator
{
    class Program
    {
        static void Main(string[] args)
        {

            Program p = new Program();
            List<NestedInteger> list = new List<NestedInteger>(); ;

            List<NestedInteger> list1 = new List<NestedInteger>();
            list1.Add(new NestedInteger(1));
            list1.Add(new NestedInteger(1));

            NestedInteger ni2 = new NestedInteger(2);

            List<NestedInteger> list3 = new List<NestedInteger>();
            list3.Add(new NestedInteger(1));
            list3.Add(new NestedInteger(1));

            list.Add(new NestedInteger(list1));
            list.Add(ni2);
            list.Add(new NestedInteger(list3));

            NestedIterator i = new NestedIterator(list);
            while (i.HasNext()) Console.Write(i.Next());
        }


    }

    public class NestedInteger {

        int i;
        List<NestedInteger> list;
        bool isI;

        public NestedInteger(int i)
        {
            this.i = i;
            isI = true;
        }

        public NestedInteger(List<NestedInteger> list)
        {
            this.list = list;
            isI = false;

        }
        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger()
        {
            return isI;
        }
 
        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        public int GetInteger()
        {
            return i;
        }
 
        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        public IList<NestedInteger> GetList()
        {
            return list;
        }
    }
 
    public class NestedIterator {

        List<int> valueList = new List<int>();
        int pos;
    
        public NestedIterator(IList<NestedInteger> nestedList) {
        
            valueList = new List<int>();
            pos = 0;
            NestedInteger target;
            for(int i = 0;i<nestedList.Count;i++){
                target = nestedList[i];
                if(target==null)continue;
                if(target.IsInteger()){
                    valueList.Add(target.GetInteger());
                }else{
                    handleList(target.GetList());
                }
            }
        
        }

        public bool HasNext() {
            return (pos < valueList.Count);
        }

        public int Next() {
            return valueList[pos++];
        }
    
        // recursion 
        private void handleList(IList<NestedInteger> list){
            NestedInteger target;
            for(int i = 0;i<list.Count;i++){
                target = list[i];
                if(target==null)continue;
                if(target.IsInteger()){
                    valueList.Add(target.GetInteger());
                }else{
                    handleList(target.GetList());
                }
            
            }
        
        }
    }
}
