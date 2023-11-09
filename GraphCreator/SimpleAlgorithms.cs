namespace GraphCreator
{
    /// <summary>
    /// Класс для выполнения простых алгоритмов.
    /// </summary>
    public class SimpleAlgorithms
    {
        /// <summary>
        /// Метод для вычисления координат на OY в зависимости от времени выполнения указанного простого алгоритма.
        /// </summary>
        public static void GetYCoors()
        {
            for (int i = 14; i < Program.MaxPoint; i++)
            {
                int[] numsVector = RandomMaker.GenerateRandomArray(Program.StepX * i);
                object[] methodParams = new object[] { numsVector };
                int repeatsCount = 1;
                CoorsYGetting.GetYCoor(methodParams, repeatsCount);
            }
        }

        /// <summary>
        /// Метод для выполнения алгоритма постоянной функции.
        /// </summary>
        /// <param name="numsVector">Вектор, от которого не должно зависеть время выполнения алгоритма.</param>
        /// <returns></returns>
        public static int ConstFunctionAlg(int[] numsVector)
        {
            int sum = 0;
            for (int i = 1; i <= 10000000; i++)
            {
                sum += i;
            }
            return 1;
        }

        /// <summary>
        /// Метод для выполнения алгоритма суммы элементов.
        /// </summary>
        /// <param name="numsVector">Вектор для нахождения суммы его элементов.</param>
        /// <returns></returns>
        public static int ElemsSumAlg(int[] numsVector)
        {
            int sum = 0;

            foreach (int num in numsVector)
            {
                sum += num;
            }
            return sum;
        }

        /// <summary>
        /// Метод для выполнения алгоритма произведения элементов.
        /// </summary>
        /// <param name="numsVector">Вектор для нахождения произведения его элементов.</param>
        /// <returns></returns>
        public static int NumsProductAlg(int[] numsVector)
        {
            int product = 1;

            foreach (int num in numsVector)
            {
                product *= num;
            }
            return product;
        }

        /// <summary>
        /// Метод для выполнения алгоритма простого представления полинома.
        /// </summary>
        /// <param name="numsVector">Вектор для вычисления простого представления полинома.</param>
        /// <returns></returns>
        public static double NaivePolRepresAlg(int[] numsVector)
        {
            double result = 0;
            double x = 1.5;

            for (int i = 0; i < numsVector.Length; i++)
            {
                result += numsVector[i] * Math.Pow(x, i - 1);
            }

            return result;
        }

        /// <summary>
        /// Метод для выполнения алгоритма метода Горнера.
        /// </summary>
        /// <param name="numsVector">Вектор для вычисления представления полинома методом Горнера.</param>
        /// <returns></returns>
        public static double GornersMethodAlg(int[] numsVector)
        {
            if (numsVector.Length == 0) return 0;
            double x = 1.5;
            double result = numsVector[0];

            for (int i = 1; i < numsVector.Length; i++)
            {
                result = result * x + numsVector[i];
            }

            return result;
        }

        /// <summary>
        /// Метод для выполнения алгоритма Кадана.
        /// </summary>
        /// <param name="numsVector">Вектор для вычисления максимальной суммы подмассива.</param>
        /// <returns></returns>
        public static int FindMaxSubarraySumAlg(int[] numsVector)
        {
            if (numsVector.Length == 0) return 0;
            int maxSoFar = numsVector[0];
            int maxEndingHere = numsVector[0];

            for (int i = 1; i < numsVector.Length; i++)
            {
                maxEndingHere = Math.Max(numsVector[i], maxEndingHere + numsVector[i]);

                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }
    }
}
