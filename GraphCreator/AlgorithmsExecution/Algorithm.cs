namespace GraphCreator.AlgorithmsExecution
{
    /// <summary>
    /// Класс для создания алгоритма и получения списка уже существующих.
    /// </summary>
    public class Algorithm
    {
        /// <summary>
        /// Название алгоритма.
        /// </summary>
        public readonly string AlgName;
        /// <summary>
        /// Пространство класса метода алгоритма.
        /// </summary>
        public readonly string AlgNamespace;
        /// <summary>
        /// Класс метода алгоритма.
        /// </summary>
        public readonly string AlgClass;
        /// <summary>
        /// Метод алгоритма.
        /// </summary>
        public readonly string AlgMethod;
        /// <summary>
        /// Сложность алгоритма.
        /// </summary>
        public readonly string AlgComplexity;
        /// <summary>
        /// Число элементов в массиве, достаточное для показательности графика алгоритма.
        /// </summary>
        public readonly int ElemsCount;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="algName">Название алгоритма.</param>
        /// <param name="algNamespace">Пространство класса метода алгоритма.</param>
        /// <param name="algClass">Класс метода алгоритма.</param>
        /// <param name="algMethod">Метод алгоритма</param>
        /// <param name="algComplexity">Сложность алгоритма</param>
        /// <param name="elemsCount">Число элементов в массиве, достаточное для показательности графика алгоритма.</param>
        public Algorithm(string algName, string algNamespace, string algClass, string algMethod, string algComplexity, int elemsCount)
        {
            AlgName = algName;
            AlgNamespace = algNamespace;
            AlgClass = algClass;
            AlgMethod = algMethod;
            AlgComplexity = algComplexity;
            ElemsCount = elemsCount;
        }

        /// <summary>
        /// Список всех существующих по умолчанию алгоритмов.
        /// </summary>
        private static readonly List<Algorithm> algorithms = new()
        {
            new Algorithm("Постоянная_функция", "GraphCreator.AlgorithmsExecution", "SimpleAlgorithms", "ConstFunctionAlg", "Const", 100000000),
            new Algorithm("Сумма_элементов", "GraphCreator.AlgorithmsExecution", "SimpleAlgorithms", "ElemsSumAlg", "Line", 100000000),
            new Algorithm("Произведение_элементов", "GraphCreator.AlgorithmsExecution", "SimpleAlgorithms", "NumsProductAlg", "Line", 100000000),
            new Algorithm("Простое_представление_полинома", "GraphCreator.AlgorithmsExecution", "SimpleAlgorithms", "NaivePolRepresAlg", "Line", 100000000),
            new Algorithm("Метод_Горнера", "GraphCreator.AlgorithmsExecution", "SimpleAlgorithms", "GornersMethodAlg", "Line", 100000000),
            new Algorithm("Алгоритм_Кадана", "GraphCreator.AlgorithmsExecution", "SimpleAlgorithms", "FindMaxSubarraySumAlg", "Line", 100000000),
            new Algorithm("Произведение_матриц", "GraphCreator.AlgorithmsExecution", "Matrix", "MatricesProductAlg", "Quadratic", 300),
            new Algorithm("Bubble_Sort", "GraphCreator.AlgorithmsExecution", "SortAlgorithms", "BubbleSortAlg", "Quadratic", 20000),
            new Algorithm("Quick_Sort", "GraphCreator.AlgorithmsExecution", "SortAlgorithms", "QuickSortAlg", "LineLog", 10000000),
            new Algorithm("Tim_Sort", "GraphCreator.AlgorithmsExecution", "SortAlgorithms", "TimSortAlg", "LineLog", 10000000),
            new Algorithm("Comb_Sort", "GraphCreator.AlgorithmsExecution", "SortAlgorithms", "CombSortAlg", "LineLog", 10000000),
            new Algorithm("Pancake_Sort", "GraphCreator.AlgorithmsExecution", "SortAlgorithms", "PancakeSortAlg", "Quadratic", 20000),
            new Algorithm("Простое_возведение_в_степень", "GraphCreator.AlgorithmsExecution", "PowAlgorithms", "GetOpersCountSimplePowAlg", "Line", 10000),
            new Algorithm("Рекурсивное_возведение_в_степень", "GraphCreator.AlgorithmsExecution", "PowAlgorithms", "GetOpersCountRecPowAlg", "Line", 10000),
            new Algorithm("Быстрое_возведение_в_степень", "GraphCreator.AlgorithmsExecution", "PowAlgorithms", "GetOpersCountQuickPowAlg", "Log", 10000),
            new Algorithm("Классическое_быстрое_возведение_в_степень", "GraphCreator.AlgorithmsExecution", "PowAlgorithms", "GetOpersCountClassicQuickPowAlg", "Log", 10000)
        };

        /// <summary>
        /// Метод для получения списка всех существующих алгоритмов.
        /// </summary>
        public static List<Algorithm> GetAlgorithms() => algorithms;
    }
}
