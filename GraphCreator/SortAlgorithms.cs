namespace GraphCreator
{
    /// <summary>
    /// Класс для выполнения алгоритмов сортировки.
    /// </summary>
    public class SortAlgorithms
    {
        /// <summary>
        /// Метод для вычисления координат на OY в зависимости от времени выполнения указанного алгоритма сортировки.
        /// </summary>
        public static void GetYCoors()
        {
            for (int i = 0; i < Program.MaxPoint; i++)
            {
                int[] numsVector = RandomMaker.GenerateRandomArray(Program.StepX * i);
                object[] methodParams = new object[] { numsVector };
                int repeatsCount = 1;
                CoorsYGetting.GetYCoor(methodParams, repeatsCount);
            }
        }

        /// <summary>
        /// Метод для выполнения алгоритма сортировки пузырьком.
        /// </summary>
        /// <param name="numsVector">Вектор с элементами для сортировки.</param>
        public static void BubbleSortAlg(int[] numsVector)
        {
            for (int write = 0; write < numsVector.Length; write++)
            {
                for (int sort = 0; sort < numsVector.Length - 1; sort++)
                {
                    if (numsVector[sort] > numsVector[sort + 1])
                    {
                        (numsVector[sort], numsVector[sort + 1]) = (numsVector[sort + 1], numsVector[sort]);
                    }
                }
            }
        }

        /// <summary>
        /// Метод для выполнения алгоритма быстрой сортировки.
        /// </summary>
        /// <param name="numsVector">Вектор с элементами для сортировки.</param>
        public static void QuickSortAlg(int[] numsVector)
        {
            GetTheVectorForQuickSortAlg(numsVector, 0, numsVector.Length - 1);
        }

        private static void GetTheVectorForQuickSortAlg(int[] numsVector, int left, int right)
        {
            Stack<int> stack = new();
            stack.Push(left);
            stack.Push(right);

            while (stack.Count > 0)
            {
                int end = stack.Pop();
                int start = stack.Pop();

                if (start < end)
                {
                    int pivot = Partition(numsVector, start, end);

                    if (pivot > 1)
                    {
                        stack.Push(start);
                        stack.Push(pivot - 1);
                    }

                    if (pivot + 1 < end)
                    {
                        stack.Push(pivot + 1);
                        stack.Push(end);
                    }
                }
            }
        }

        private static int Partition(int[] numsVector, int left, int right)
        {
            int pivot = numsVector[left];

            while (true)
            {
                while (numsVector[left] < pivot)
                    left++;

                while (numsVector[right] > pivot)
                    right--;

                if (left < right)
                {
                    if (numsVector[left] == numsVector[right])
                        return right;

                    (numsVector[right], numsVector[left]) = (numsVector[left], numsVector[right]);
                }

                else
                {
                    return right;
                }
            }
        }

        /// <summary>
        /// Метод для выполнения алгоритма Tim Sort.
        /// </summary>
        /// <param name="numsVector">Вектор с элементами для сортировки.</param>
        public static void TimSortAlg(int[] numsVector)
        {
            int n = numsVector.Length;
            int run = GetMinrun(n);

            for (int i = 0; i < n; i += run)
                InsertionSort(numsVector, i, Math.Min(i + run - 1, n - 1));

            for (int size = run; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min(left + 2 * size - 1, n - 1);

                    if (mid < right)
                        Merge(numsVector, left, mid, right);
                }
            }
        }

        private static void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];

            for (int x = 0; x < len1; x++)
                left[x] = arr[x + l];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + x + 1];

            int j = 0;
            int i = 0;
            int k = l;

            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < len1 && j < len2)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            while (i < len1 && j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        private static int GetMinrun(int n)
        {
            int r = 0;
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1;
            }

            return n + r;
        }

        /// <summary>
        /// Метод для выполнения алгоритма сортировки расчёской.
        /// </summary>
        /// <param name="numsVector">Вектор с элементами для сортировки.</param>
        public static void CombSortAlg(int[] numsVector)
        {
            double gap = numsVector.Length;

            bool swaps = true;

            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;

                if (gap < 1) { gap = 1; }

                int i = 0;

                swaps = false;

                while (i + gap < numsVector.Length)
                {
                    int igap = i + (int)gap;

                    if (numsVector[i] > numsVector[igap])
                    {
                        (numsVector[igap], numsVector[i]) = (numsVector[i], numsVector[igap]);
                        swaps = true;
                    }

                    i++;
                }
            }
        }

        /// <summary>
        /// Метод для выполнения алгоритма блинной сортировки.
        /// </summary>
        /// <param name="numsVector">Вектор с элементами для сортировки.</param>
        public static void PancakeSortAlg(int[] numsVector)
        {
            for (int i = numsVector.Length - 1; i > 0; i--)
            {
                int maxIndex = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (numsVector[j] > numsVector[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != i)
                {
                    Flip(numsVector, maxIndex);
                    Flip(numsVector, i);
                }
            }
        }

        private static void Flip(int[] array, int endIndex)
        {
            int startIndex = 0;
            while (startIndex < endIndex)
            {
                (array[endIndex], array[startIndex]) = (array[startIndex], array[endIndex]);
                startIndex++;
                endIndex--;
            }
        }
    }
}
