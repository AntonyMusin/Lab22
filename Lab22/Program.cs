using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        static void MethodMax (Task task,object[]arr)
        {
            Console.WriteLine("Метод Мах начал работу");
            int max = 0;
            foreach (int a in arr)
            {
                if (a > max)
                    max = a;
                Thread.Sleep(300);
            }
            Console.WriteLine($"Метод Мах окончил работу, максимальное число = {max}");
        }
        static void MethodSum(int[] array)
        {
            Console.WriteLine("Метод Sum начал работу");
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                Thread.Sleep(300);
            }
            Console.WriteLine($"Метод Sum окончил работу, сумма = {sum}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число N>0, для формирования массива размером N");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
                Console.WriteLine(array[i]);
            }

            Task task1 = new Task(()=>MethodSum(array));
            Action<Task, object> actionTask = new Action<Task, object>(MethodMax);

            Task task2=task1.ContinueWith(actionTask,array);
            task1.Start();
            Console.ReadKey();
        }
    }
}

