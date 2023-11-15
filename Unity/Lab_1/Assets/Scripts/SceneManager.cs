using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс для управления переходами между сценами внутри приложения.
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        /// <summary>
        /// Метод для перехода к другой сцене по её номеру.
        /// </summary>
        /// <param name="scene">Номер сцены для перехода к ней.</param>
        public static void ChangeTheScene(int scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }

        /// <summary>
        /// Метод для выхода из приложения.
        /// </summary>
        public static void QuitTheApp()
        {
            Application.Quit();
        }
    }
}
