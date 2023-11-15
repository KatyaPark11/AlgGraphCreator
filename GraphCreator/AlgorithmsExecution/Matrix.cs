using GraphCreator.AlgorithmsResearch;
using static GraphCreator.Program;

namespace GraphCreator.AlgorithmsExecution
{
    /// <summary>
    /// Класс для работы с матрицей.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Свойство для хранения зубчатого массива значений матрицы.
        /// </summary>
        public int[][] Values { get; set; }

        /// <summary>
        /// Метод генерации случайных неотрицательных значений матрицы.
        /// </summary>
        /// <param name="dimension">Размерность матрицы.</param>
        public void GenerateAMatrix(int dimension)
        {
            Random randomElems = new();

            Values = new int[dimension][];

            for (int i = 0; i < dimension; i++)
            {
                Values[i] = new int[dimension];

                for (int j = 0; j < dimension; j++)
                {
                    Values[i][j] = randomElems.Next(0, 99);
                }
            }
        }

        /// <summary>
        /// Метод для вычисления координат на OY в зависимости от времени выполнения произведения матриц.
        /// </summary>
        public static void GetYCoors()
        {
            int maxDimension = StepX * (int)MaxPoint;
            for (int i = 2; i < maxDimension; i += StepX)
            {
                Matrix matrix1 = new();
                Matrix matrix2 = new();
                matrix1.GenerateAMatrix(i);
                matrix2.GenerateAMatrix(i);
                Matrix[] matrices = new[] { matrix1, matrix2 };
                object[] methodParams = matrices;
                int repeatsCount = 5;
                CoorsYGetting.GetYCoor(methodParams, repeatsCount);
            }
        }

        /// <summary>
        /// Метод для нахождения матрицы произведения двух квадратных матриц.
        /// </summary>
        /// <param name="a">Первая матрица.</param>
        /// <param name="b">Вторая матрица.</param>
        public static Matrix MatricesProductAlg(Matrix a, Matrix b)
        {
            Matrix result = new()
            {
                Values = new int[a.Values.Length][]
            };

            for (int i = 0; i < a.Values.Length; i++)
            {
                result.Values[i] = new int[a.Values.Length];

                for (int j = 0; j < a.Values.Length; j++)
                {
                    result.Values[i][j] = 0;

                    for (int k = 0; k < a.Values.Length; k++)
                    {
                        result.Values[i][j] += a.Values[i][k] * b.Values[k][j];
                    }
                }
            }

            return result;
        }
    }
}
