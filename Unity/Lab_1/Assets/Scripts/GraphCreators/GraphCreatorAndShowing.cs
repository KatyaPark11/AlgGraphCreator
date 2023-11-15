using TMPro;
using UnityEngine;

namespace Assets.Scripts.GraphCreators
{
    /// <summary>
    /// ����� ��� �������� � �������� ������� � ��� ������������ �����������.
    /// </summary>
    public class GraphCreatorAndShowing : MonoBehaviour
    {
        /// <summary>
        /// ������ ��� �������� �������� ���������� ���������.
        /// </summary>
        public TMP_Dropdown AlgorithmName;

        /// <summary>
        /// ����� ��� �������� � ��������� ����� � ������� ��������.
        /// </summary>
        public void ShowTheGraphic()
        {
            VarsHolder.AlgorithmName = AlgorithmName.options[AlgorithmName.value].text.Replace(" ", "_");
            SceneManager.ChangeTheScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}