using static GraphCreator.Program;

namespace GraphCreator.AlgorithmsExecution
{
    /// <summary>
    /// Класс для подсчёта числа операций степенных алгоритмов и прогона самих алгоритмов.
    /// </summary>
    public class PowAlgorithms
    {
        /// <summary>
        /// Метод для вычисления координат на OY в зависимости от числа элементарных операций указанного степенного алгоритма.
        /// </summary>
        public static void GetYCoors()
        {
            Random random = new();
            int[] numsVector = new int[2];
            numsVector[0] = random.Next();
            int maxExt = StepX * (int)MaxPoint;
            for (int i = 0; i < maxExt; i += StepX)
            {
                numsVector[1] = i;
                object[] methodParams = new object[] { numsVector };
                CoorsY.Add(Convert.ToDouble(AlgMethodInfo.Invoke(AlgClassInstance, methodParams)));
            }
            MaxElem = CoorsY[^1];
        }

        /// <summary>
        /// Метод для подсчёта элементарных операций алгоритма простого возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long GetOpersCountSimplePowAlg(int[] numsVector)
        {
            int ext = numsVector[1];
            int counter = 0;
            int opersCount = 4;

            while (counter < ext)
            {
                opersCount += 3;
                counter++;
            }

            opersCount++;

            return opersCount;
        }

        /// <summary>
        /// Метод для выполнения алгоритма простого возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long SimplePowAlg(int[] numsVector)
        {
            int num = numsVector[0];
            int ext = numsVector[1];
            int result = 1;
            int counter = 0;
            while (counter < ext)
            {
                result *= num;
                counter++;
            }
            return result;
        }

        /// <summary>
        /// Метод для подсчёта элементарных операций алгоритма рекурсивного возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long GetOpersCountRecPowAlg(int[] numsVector)
        {
            int ext = numsVector[1];
            int opersCount = 1;

            opersCount += ext + 1;
            return opersCount;
        }

        /// <summary>
        /// Метод для выполнения алгоритма рекурсивного возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long RecPowAlg(int num, int ext)
        {
            if (ext == 0)
                return 1;
            else
                return num * RecPowAlg(num, ext - 1);
        }

        /// <summary>
        /// Метод для подсчёта элементарных операций алгоритма быстрого возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long GetOpersCountQuickPowAlg(int[] numsVector)
        {
            int ext = numsVector[1];
            int opersCount = 4;

            if (ext % 2 == 1) opersCount++;
            else opersCount++;

            do
            {
                opersCount += 2;

                if (ext % 2 == 1)
                {
                    opersCount++;
                }

                opersCount++;
                ext /= 2;
            } while (ext != 0);

            opersCount++;
            return opersCount;
        }

        /// <summary>
        /// Метод для выполнения алгоритма быстрого возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long QuickPowAlg(int number, int extent)
        {
            int num = number;
            int ext = extent;
            int result;
            if (ext % 2 == 1) result = num;
            else result = 1;

            do
            {
                ext /= 2;
                num *= num;
                if (ext % 2 == 1)
                    result *= num;
            } while (ext != 0);

            return result;
        }

        /// <summary>
        /// Метод для подсчёта элементарных операций алгоритма классического быстрого возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long GetOpersCountClassicQuickPowAlg(int[] numsVector)
        {
            int ext = numsVector[1];
            int opersCount = 4;

            while (ext != 0)
            {
                opersCount += 2;

                if (ext % 2 == 0)
                {
                    opersCount += 2;
                    ext /= 2;
                }
                else
                {
                    opersCount += 2;
                    ext--;
                }
                opersCount++;
            }

            opersCount++;
            return opersCount;
        }

        /// <summary>
        /// Метод для выполнения алгоритма классического быстрого возведения в степень.
        /// </summary>
        /// <param name="numsVector">Вектор, состоящий из числа и степени, в которую его надо возвести.</param>
        public static long ClassicQuickPowAlg(int number, int extent)
        {
            int num = number;
            int result = 1;
            int ext = extent;

            while (ext != 0)
            {
                if (ext % 2 == 0)
                {
                    num *= num;
                    ext /= 2;
                }
                else
                {
                    result *= num;
                    ext--;
                }
            }

            return result;
        }
    }
}
