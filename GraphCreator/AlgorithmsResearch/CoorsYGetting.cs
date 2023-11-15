using System.Diagnostics;
using static GraphCreator.Program;

namespace GraphCreator.AlgorithmsResearch
{
    /// <summary>
    /// Класс для получения координаты на OY с помощью замера времени.
    /// </summary>
    public class CoorsYGetting
    {
        /// <summary>
        /// Метод для получения координаты на OY с помощью замера времени работы алгоритма.
        /// </summary>
        /// <param name="methodParams">Параметры, передаваемые в метод выполнения самого алгоритма.</param>
        /// <param name="repeatsCount">Число замеров времени для вычисления среднего значения.</param>
        public static void GetYCoor(object[] methodParams, int repeatsCount)
        {
            double timesSum = 0;
            for (int j = 0; j < repeatsCount; j++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                AlgMethodInfo.Invoke(AlgClassInstance, methodParams);
                stopwatch.Stop();
                timesSum += stopwatch.ElapsedMilliseconds;
            }

            double elapsedMilliseconds = timesSum / repeatsCount;
            if (elapsedMilliseconds > MaxElem)
                MaxElem = elapsedMilliseconds;
            CoorsY.Add(elapsedMilliseconds);
        }
    }
}
