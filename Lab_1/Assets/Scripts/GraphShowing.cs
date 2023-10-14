using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GraphShowing : MonoBehaviour
{
    public Image Image;

    void Start()
    {
        Texture2D texture = LoadTextureFromFile();
        Image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }

    Texture2D LoadTextureFromFile()
    {
        byte[] fileData = File.
            ReadAllBytes("C:\\Users\\User\\Desktop\\Моё\\Программы\\GraphCreator" +
            $"\\Graphs_Png\\graph_{VarsHolder.AlgorithmName}.png");

        Texture2D texture = new(2, 2);
        texture.LoadImage(fileData);

        return texture;
    }
}
