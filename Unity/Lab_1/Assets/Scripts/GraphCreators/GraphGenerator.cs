using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.VarsHolder;

namespace Assets.Scripts.GraphCreators
{
    /// <summary>
    /// ����� ��� ��������� ����������� � �������� ���������� ���������.
    /// </summary>
    public class GraphGenerator : MonoBehaviour
    {
        /// <summary>
        /// �����, ����������� ��������.
        /// </summary>
        public Image[] Points = new Image[5];
        /// <summary>
        /// �������� ��������� ������� �����, ����������� ��������.
        /// </summary>
        private readonly float speed = 0.8f;
        /// <summary>
        /// ������� ��������� ������� �����, ����������� ��������, ������������ ������������� ����������.
        /// </summary>
        private int frequency;
        /// <summary>
        /// ������� ��� ��� ������������ ��������� ������� �����, ����������� ��������, ������������ ������������� ����������.
        /// </summary>
        private int currentStep = 0;

        /// <summary>
        /// �����, ����������� ��������� ����������� � �������� ���������� ���������.
        /// </summary>
        private void Start()
        {
            ImagePath = $"..\\..\\Graphs_Png\\graph_{AlgorithmName}.png";
            if (File.Exists(ImagePath))
                File.Delete(ImagePath);
         
            frequency = (int)(speed / 0.2);
            GraphCreatorStartup.GoToTheGraphCreator(AlgorithmName);
        }

        /// <summary>
        /// �����, ����������� ������� ������� ����������� ��� ����������� �������� � ��������� �����, ������������ ��������� ������, � ������ ������.
        /// </summary>
        private void FixedUpdate()
        {
            if (File.Exists(ImagePath))
            {
                Thread.Sleep(200);
                SceneManager.ChangeTheScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                if (currentStep % frequency == 0)
                {
                    currentStep = 0;
                    BrightnessChanging.ChangePointsBrigness(Points);
                }
                currentStep++;
            }
        }
    }
}