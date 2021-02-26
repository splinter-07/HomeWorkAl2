using System;

namespace HomeWorkAl2_2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int BinarySearch(int[] inputArray, int searchValue) // Итоговая сложность O(N/2^i)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2; // делим массив на 2 половины O(N/2), каждая итерация следующее прохождение O((N/2)/2), 
                                           // следующее O(((N/2)/2)/2), здесь выходит сложность O(N/2^i), где i - количество итераций
                                           // пока не останется 1 элемент.
                if (searchValue == inputArray[mid])
                {
                    return mid; //O(1)
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1; //O(1)
                }
                else
                {
                    min = mid + 1; //O(1)
                }
            }
            return -1;
        }
    }
}
