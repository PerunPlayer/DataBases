using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sort
{
    public class Program
    {
        static void Main()
        {
            var numbers = GenerateNumbers(100);
            Shuffle(numbers);

            Console.WriteLine(string.Join(" ", numbers));

            var qSorted = QuickSort(numbers, true);
            var mSorted = MergeSort(numbers);

            Console.WriteLine();
            Console.Write("QuickSort -> ");
            Console.WriteLine(string.Join(" ", qSorted));
            Console.WriteLine();
            Console.Write("MergeSort -> ");
            Console.WriteLine(string.Join(" ", mSorted));
        }

        public static List<int> MergeSort(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            int midIndex = numbers.Count / 2;
            var left = numbers.Take(midIndex).ToList();
            var right = numbers.Skip(midIndex).ToList();

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }

        public static List<int> QuickSort(List<int> numbers, bool isAsync = false)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            if (numbers.Count == 30)
            {
                InsertionSort(numbers);
            }

            int middleIndex = numbers.Count / 2;
            int firstIndex = 0;
            int lastIndex = numbers.Count - 1;

            int middle = numbers[middleIndex];
            int first = numbers[firstIndex];
            int last = numbers[lastIndex];
            int pivot = FindPivot(first, middle, last);

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < middleIndex; i++)
            {
                if (numbers[i] <= pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }
            for (int i = middleIndex + 1; i < numbers.Count; i++)
            {
                if (numbers[i] < pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            List<int> result = new List<int>();

            List<int> sortedLeft = null;
            List<int> sortedRight = null;

            if (isAsync) // if you have 2 free cores
            {
                Task leftTask = Task.Run(() => sortedLeft = QuickSort(left));
                Task rightTask = Task.Run(() => sortedRight = QuickSort(right));
                Task.WaitAll(leftTask, rightTask);
            }
            else   // if you haven't
            {
                sortedLeft = QuickSort(left);
                sortedRight = QuickSort(right);
            }

            result.AddRange(sortedLeft);
            result.Add(pivot);
            result.AddRange(sortedRight);

            return result;
        }

        public static List<int> InsertionSort(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            for (int i = 1; i < numbers.Count; i++)
            {
                int j = i;
                while (j > 0 && numbers[j] < numbers[j - 1])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
            }

            return numbers;
        }

        public static List<int> GenerateNumbers(int maxNumber)
        {
            List<int> result = new List<int>();

            for (int i = 1; i < maxNumber + 1; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public static void Shuffle<T>(List<T> numbers)
        {
            Random random = new Random();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int randomIndex = random.Next(i + 1, numbers.Count);
                Swap(numbers, i, randomIndex);
            }
        }

        public static void Swap<T>(List<T> numbers, int firstIndex, int secondIndex)
        {
            T temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }

        public static int FindPivot(int first, int middle, int last)
        {
            int pivot = 0;

            if (first <= last && first >= middle || first >= last && first <= middle)
            {
                pivot = first;
            }
            else if (last <= first && last >= middle || last >= first && last <= middle)
            {
                pivot = last;
            }
            else
            {
                pivot = middle;
            }

            return pivot;
        }
    }
}
