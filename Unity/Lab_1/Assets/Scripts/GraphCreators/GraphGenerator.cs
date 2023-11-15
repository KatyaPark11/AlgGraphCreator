using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.VarsHolder;

namespace Assets.Scripts.GraphCreators
{
    /// <summary>
    ///  ласс дл€ генерации изображени€ с графиком выбранного алгоритма.
    /// </summary>
    public class GraphGenerator : MonoBehaviour
    {
        /// <summary>
        /// “очки, имитирующие загрузку.
        /// </summary>
        public Image[] Points = new Image[5];
        /// <summary>
        /// —корость изменени€ свойств точек, имитирующих загрузку.
        /// </summary>
        private readonly float speed = 0.8f;
        /// <summary>
        /// „астота изменений свойств точек, имитирующих загрузку, относительно фиксированных обновлений.
        /// </summary>
        private int frequency;
        /// <summary>
        /// “екущий шаг дл€ отслеживани€ изменений свойств точек, имитирующих загрузку, относительно фиксированных обновлений.
        /// </summary>
        private int currentStep = 0;

        /// <summary>
        /// ћетод, запускающий генерацию изображений с графиком выбранного алгоритма.
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
        /// ћетод, провер€ющий наличие нужного изображени€ дл€ дальнейшего перехода к следующей сцене, отображающей созданный график, в случае успеха.
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