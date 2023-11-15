using UnityEngine;
using Assets.Scripts.GraphCreators;

namespace Assets.Scripts
{
    /// <summary>
    /// ����� ��� ���������� ������ ����������� ���������� ��� �������� �������.
    /// </summary>
    public class ProcessClosing : MonoBehaviour
    {
        /// <summary>
        /// �����, ����������� ����������� ������ ����������� ���������� ��� �������� �������.
        /// </summary>
        public void CloseTheProcess()
        {
            GraphCreatorStartup.Process.Kill();
        }
    }
}