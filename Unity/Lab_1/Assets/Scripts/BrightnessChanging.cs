using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс для изменения яркости точек, имитирующих загрузку.
    /// </summary>
    public class BrightnessChanging : MonoBehaviour
    {
        /// <summary>
        /// Метод для изменения яркости точек, имитирующих загрузку.
        /// </summary>
        /// <param name="points">Точки, имитирующие загрузку.</param>
        public static void ChangePointsBrigness(Image[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Color color = points[i].color;
                if (color.a == 1)
                    color.a = 55f / 255f;
                else
                    color.a += 50f / 255f;
                points[i].color = color;
            }
        }
    }
}
