using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Set
    {
        List<int> numbers = new List<int>();

        public List<int> Numbers { get => numbers; set => numbers = value; }

        //public Set(int[] nums) {
        //    foreach (int num in nums) Numbers.Add(num);
        //}
        public void Show()
        {
            string nums = "";
            foreach (int num in numbers)
            {
                nums += num.ToString() + " ";
            }

            Console.WriteLine(nums);
        }

        public Set(List<int> nums)
        {
            foreach (int num in nums) Numbers.Add(num);
        }


        public Set(params int[] nums)
        {
            foreach (int num in nums) Numbers.Add(num);
        }

        public static implicit operator Set(int num)
        {
            return new Set(num);
        }


        public static Set operator +(Set set1, Set set2)
        {
            List<int> newSet = new List<int>();

            foreach(int numSet1 in set1.Numbers)
            {
                if(!newSet.Contains(numSet1)) newSet.Add(numSet1);
            }

            foreach (int numSet2 in set2.Numbers)
            {
                if (!newSet.Contains(numSet2)) newSet.Add(numSet2);
            }
            return new Set(newSet);
        }


        public static Set operator *(Set set1, Set set2)
        {
            List<int> newSet = new List<int>();

            foreach (int numSet1 in set1.Numbers)
            {
                if (set2.Numbers.Contains(numSet1) && !newSet.Contains(numSet1))
                {
                    newSet.Add(numSet1);
                }
            }

            return new Set(newSet);
        }

        public static Set operator -(Set set1, Set set2)
        {
            List<int> newSet = new List<int>();

            foreach (int numSet1 in set1.Numbers)
            {
                if (!set2.Numbers.Contains(numSet1) && !newSet.Contains(numSet1))
                {
                    newSet.Add(numSet1);
                }
            }

            return new Set(newSet);
        }

        public static bool operator <(Set set1, Set set2)
        {

            foreach (int numSet1 in set1.Numbers)
            {
                if (!set2.Numbers.Contains(numSet1))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator >(Set set1, Set set2)
        {

            foreach (int numSet2 in set2.Numbers)
            {
                if (!set1.Numbers.Contains(numSet2))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator ==(Set set1, Set set2)
        {

            if(set1 < set2 && set2 < set1)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Set set1, Set set2)
        {

            if (!(set1 < set2) || !(set1 > set2))
            {
                return true;
            }

            return false;
        }

    }
}
