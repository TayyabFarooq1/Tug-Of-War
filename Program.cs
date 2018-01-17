using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace tug_of_war
{
    class Program
    {
        public long comb, num = 0;
        public int sub = int.MaxValue;
        public int current = 0;
       
        public static long GetFactorial(int number)
        {

            if (number == 0)
            {

                return 1;

            }

            return number * GetFactorial(number - 1);

        }
        public long combination(int n, int r)
        {
            long a, b, c;
            long comb, temp;
            a = GetFactorial(n);
            b = GetFactorial(r);
            c = GetFactorial(n - r);
            temp = b * c;
            comb = a / temp;
            return comb;
        }
        public int difference(int[] arr1, int[] arr2)
        {
            int sum1=0, sum2=0;
            int diff;
            for(int i=0; i<arr1.Length; i++)
            {
                sum1 = sum1 + arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                sum2 = sum2 + arr2[i];
            }
            if (sum1 > sum2)
                diff = sum1 - sum2;
            else
                diff = sum2 - sum1;
            return diff;
        }
        public static int[] r_function(string path)
        {

            int[] b = new int[11];
            string take;
            using (StreamReader obj = new StreamReader(path))
            {
                for (int i = 0; i < 11; i++)
                {
                    take = obj.ReadLine();
                    b[i] = Convert.ToInt32(take);
                }
            }
            return b;
        }
        public void subset(int[] arr,int[] real_arr1,int[] real_arr2, bool[] used, int startIndex, int currentsize, int k)
        {
            int count, num1=0, num2=0;
            int[] subarray1;
            int[] subarray2;
            
            
            
            comb = combination(arr.Length, k);
             if (arr.Length % 2 != 0)
                {
                    subarray1 = new int[k];
                    subarray2 = new int[k + 1];
                    count = k + 1;
                }
                else
                {
                    subarray1 = new int[k];
                    subarray2 = new int[k];
                    count = k;
                }
             
            if(currentsize == k)
            {
                for(int i=0; i<arr.Length; i++)
                {
                    if (used[i] == true)
                    {
                        subarray1[num1] = arr[i];
                        num1++;
                    }
                    else
                    {
                        subarray2[num2] = arr[i];
                        num2++;
                    }
                }
                current = difference(subarray1, subarray2);
                if(current<sub)
                {
                    for (int i = 0; i < real_arr1.Length; i++)
                    {
                        real_arr1[i] = subarray1[i];
                    }
                    for (int i = 0; i < real_arr2.Length; i++)
                    {
                        real_arr2[i] = subarray2[i];
                    }
                    sub = current;
                    //Console.WriteLine(current);
                    //Console.WriteLine(sub);
                }
                num++;
                if(num == comb)
                {
                    Console.WriteLine("Sub Array 1 : ");
                    for (int i = 0; i < real_arr1.Length; i++)
                    {
                        Console.WriteLine(real_arr1[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Sub Array 2 : ");
                    for (int i = 0; i < real_arr2.Length; i++)
                    {
                        Console.WriteLine(real_arr2[i]);
                    }
                }
                //Console.WriteLine();
                return;
            }
            if (startIndex == arr.Length)
                return;

            used[startIndex] = true;
            subset(arr, real_arr1, real_arr2, used, startIndex + 1, currentsize + 1, k);

            used[startIndex] = false;
            subset(arr,real_arr1,real_arr2, used, startIndex + 1, currentsize, k);
            return;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            int[] arr = new int[11];
            string path = "C:\\Users\\Tayyab Farooq\\Desktop\\tug of war.txt";
            arr = r_function(path);
            int k = 5;
            Console.WriteLine("Real Array : ");
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
            int[] real_arr1;
            int[] real_arr2;
            if (arr.Length % 2 != 0)
            {
                real_arr1 = new int[k];
                real_arr2 = new int[k + 1];
            }
            else
            {
                real_arr1 = new int[k];
                real_arr2 = new int[k];
            }
            bool[] used = new bool[arr.Length];
            p.subset(arr,real_arr1,real_arr2, used, 0, 0, k);
            Console.ReadLine();
        }
    }
}
