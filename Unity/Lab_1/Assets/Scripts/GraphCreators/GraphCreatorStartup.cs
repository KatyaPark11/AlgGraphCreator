using System.Diagnostics;

namespace Assets.Scripts.GraphCreators
{
    /// <summary>
    /// Класс для запуска консольного приложения для создания графика.
    /// </summary>
    public class GraphCreatorStartup
    {
        /// <summary>
        /// Процесс работы консольного приложения для создания графика.
        /// </summary>
        public static Process Process;

        /// <summary>
        /// Метод для перехода к консольному приложению для создания графика.
        /// </summary>
        /// <param name="algorithmName">Название алгоритма.</param>
        public static void GoToTheGraphCreator(string algorithmName)
        {
            string applicationPath = "..\\..\\GraphCreator\\bin\\Debug\\net6.0\\GraphCreator.exe";
            string arguments = algorithmName;

            ProcessStartInfo startInfo = new()
            {
                FileName = applicationPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process = new()
            {
                StartInfo = startInfo
            };
            Process.Start();
        }
    }
}
