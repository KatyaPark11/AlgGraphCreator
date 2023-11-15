using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.VarsHolder;

namespace Assets.Scripts
{
    /// <summary>
    ///  ласс дл€ отображени€ изображени€ с графиком выбранного алгоритма.
    /// </summary>
    public class GraphShowing : MonoBehaviour
    {
        /// <summary>
        /// ћетод, выполн€ющий загрузку изображени€ с графиком выбранного алгоритма из файла в объект.
        /// </summary>
        private void Start()
        {
            Texture2D texture = LoadTextureFromFile();
            GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        }

        /// <summary>
        /// ћетод, возвращающий изображение с графиком выбранного алгоритма из файла.
        /// </summary>
        private Texture2D LoadTextureFromFile()
        {
            byte[] fileData = File.
                ReadAllBytes(ImagePath);

            Texture2D texture = new(2, 2);
            texture.LoadImage(fileData);

            return texture;
        }
    }
}
