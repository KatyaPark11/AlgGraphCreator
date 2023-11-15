namespace GraphCreator.AlgorithmsResearch
{
    /// <summary>
    /// Класс для создания массива с рандомными целыми числами.
    /// </summary>
    public class RandomMaker
    {
        /// <summary>
        /// Метод для генерации массива с рандомными целыми числами.
        /// </summary>
        /// <param name="size">Число элементов в массиве</param>
        public static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random random = new();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }

            return array;
        }
    }
}
