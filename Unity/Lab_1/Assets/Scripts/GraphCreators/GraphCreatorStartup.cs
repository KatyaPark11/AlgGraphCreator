using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    public class GraphCreatorStartup
    {
        public static Process Process;

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