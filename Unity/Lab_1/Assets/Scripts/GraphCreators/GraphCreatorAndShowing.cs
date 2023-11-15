using TMPro;
using UnityEngine;

namespace Assets.Scripts.GraphCreators
{
    /// <summary>
    /// Класс для перехода к созданию графика и его последующему отображению.
    /// </summary>
    public class GraphCreatorAndShowing : MonoBehaviour
    {
        /// <summary>
        /// Объект для передачи названия выбранного алгоритма.
        /// </summary>
        public TMP_Dropdown AlgorithmName;

        /// <summary>
        /// Метод для перехода к следующей сцене с экраном загрузки.
        /// </summary>
        public void ShowTheGraphic()
        {
            VarsHolder.AlgorithmName = AlgorithmName.options[AlgorithmName.value].text.Replace(" ", "_");
            SceneManager.ChangeTheScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
