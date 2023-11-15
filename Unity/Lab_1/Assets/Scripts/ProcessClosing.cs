using UnityEngine;
using Assets.Scripts.GraphCreators;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс для прерывания работы консольного приложения для создания графика.
    /// </summary>
    public class ProcessClosing : MonoBehaviour
    {
        /// <summary>
        /// Метод, закрывающий прерывающий работу консольного приложения для создания графика.
        /// </summary>
        public void CloseTheProcess()
        {
            GraphCreatorStartup.Process.Kill();
        }
    }
}