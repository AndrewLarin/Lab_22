using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ведите размер массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Action<Task<int[]>> action1 = new Action<Task<int[]>>(PrintArray);
            task1.ContinueWith(action1);

            Action<Task<int[]>> action2 = new Action<Task<int[]>>(SumOfArray);
            task1.ContinueWith(action2);

            Action<Task<int[]>> action3 = new Action<Task<int[]>>(MaxOfArray);
            task1.ContinueWith(action3);
            
           
            task1.Start();

            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {

            int n = (int)a;
            int[] arr = new int[n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(-100, 100);
            }
            return arr;
        }
        static void PrintArray(Task<int[]> task)
        {
            int[] array = task.Result;
            for (int i = 0; i < array.Count(); i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        static void MaxOfArray(Task<int[]> task)
        {
            int[] arr = task.Result;
            int max = 0;
            foreach (int s in arr)
            {
                if (max < s) max = s;

            }
            Console.WriteLine("Максимальное число в массиве равно:{0}", max);
        }

        static void SumOfArray(Task<int[]> task)
        {
            int[] arr = task.Result;
            int sum = 0;
            foreach (int s in arr)
            {
                sum += s;
            }
            Console.WriteLine("Сумма элементов массива:{0}" ,sum);
        }




    }
}
