using System.Diagnostics;

public class GraphCreatorStartup
{
    public static Process Process;

    public static void GoToTheGraphCreator(string algorithmName)
    {
        string applicationPath = "C:\\Users\\User\\Desktop\\��\\���������\\GraphCreator\\bin\\Debug\\net6.0\\GraphCreator.exe";

        // ������������ ���������� ��������� ������
        string arguments = algorithmName;

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = applicationPath;
        startInfo.Arguments = arguments;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;

        Process = new()
        {
            StartInfo = startInfo
        };
        Process.Start();
    }
}
