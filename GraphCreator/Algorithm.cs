namespace GraphCreator
{
    /// <summary>
    /// Класс для создания алгоритма и получения списка уже существующих.
    /// </summary>
    public class Algorithm
    {
        public readonly string AlgName;
        public readonly string AlgNamespace;
        public readonly string AlgClass;
        public readonly string AlgMethod;
        public readonly string AlgComplexity;
        public readonly int ElemsCount;

        public Algorithm(string algName, string algNamespace, string algClass, string algMethod, string algComplexity, int elemsCount)
        {
            AlgName = algName;
            AlgNamespace = algNamespace;
            AlgClass = algClass;
            AlgMethod = algMethod;
            AlgComplexity = algComplexity;
            ElemsCount = elemsCount;
        }

        private static readonly List<Algorithm> algorithms = new()
        {
            new Algorithm("Постоянная_функция", "GraphCreator", "SimpleAlgorithms", "ConstFunctionAlg", "Const", 100000000),
            new Algorithm("Сумма_элементов", "GraphCreator", "SimpleAlgorithms", "ElemsSumAlg", "Line", 100000000),
            new Algorithm("Произведение_элементов", "GraphCreator", "SimpleAlgorithms", "NumsProductAlg", "Line", 100000000),
            new Algorithm("Простое_представление_полинома", "GraphCreator", "SimpleAlgorithms", "NaivePolRepresAlg", "Line", 100000000),
            new Algorithm("Метод_Горнера", "GraphCreator", "SimpleAlgorithms", "GornersMethodAlg", "Line", 100000000),
            new Algorithm("Алгоритм_Кадана", "GraphCreator", "SimpleAlgorithms", "FindMaxSubarraySumAlg", "Line", 100000000),
            new Algorithm("Произведение_матриц", "GraphCreator", "Matrix", "MatricesProductAlg", "Quadratic", 300),
            new Algorithm("Bubble_Sort", "GraphCreator", "SortAlgorithms", "BubbleSortAlg", "Quadratic", 20000),
            new Algorithm("Quick_Sort", "GraphCreator", "SortAlgorithms", "QuickSortAlg", "LineLog", 10000000),
            new Algorithm("Tim_Sort", "GraphCreator", "SortAlgorithms", "TimSortAlg", "LineLog", 10000000),
            new Algorithm("Comb_Sort", "GraphCreator", "SortAlgorithms", "CombSortAlg", "LineLog", 10000000),
            new Algorithm("Pancake_Sort", "GraphCreator", "SortAlgorithms", "PancakeSortAlg", "Quadratic", 20000),
            new Algorithm("Простое_возведение_в_степень", "GraphCreator", "PowAlgorithms", "GetOpersCountSimplePowAlg", "Line", 10000),
            new Algorithm("Рекурсивное_возведение_в_степень", "GraphCreator", "PowAlgorithms", "GetOpersCountRecPowAlg", "Line", 10000),
            new Algorithm("Быстрое_возведение_в_степень", "GraphCreator", "PowAlgorithms", "GetOpersCountQuickPowAlg", "Log", 10000),
            new Algorithm("Классическое_быстрое_возведение_в_степень", "GraphCreator", "PowAlgorithms", "GetOpersCountClassicQuickPowAlg", "Log", 10000)
        };

        /// <summary>
        /// Метод для получения списка всех существующих алгоритмов.
        /// </summary>
        public static List<Algorithm> GetAlgorithms() => algorithms;
    }
}
