using System.Diagnostics;

namespace Assets.Scripts.GraphCreators
{
    /// <summary>
    /// ����� ��� ������� ����������� ���������� ��� �������� �������.
    /// </summary>
    public class GraphCreatorStartup
    {
        /// <summary>
        /// ������� ������ ����������� ���������� ��� �������� �������.
        /// </summary>
        public static Process Process;

        /// <summary>
        /// ����� ��� �������� � ����������� ���������� ��� �������� �������.
        /// </summary>
        /// <param name="algorithmName">�������� ���������.</param>
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