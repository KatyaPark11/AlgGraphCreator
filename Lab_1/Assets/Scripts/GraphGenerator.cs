using Assets.Scripts;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GraphGenerator : MonoBehaviour
{
    public GameObject EmptyObject;
    public Image[] Points = new Image[5];
    private readonly string imagePath = "C:\\Users\\User\\Desktop\\Моё\\Программы\\GraphCreator" +
            $"\\Graphs_Png\\graph_{VarsHolder.AlgorithmName}.png";
    private readonly float speed = 0.8f;
    private int cycleStep;
    private int currentCycle = 0;

    void Start()
    {
        if (File.Exists(imagePath))
            File.Delete(imagePath);

        cycleStep = (int)(speed / 0.2);
        GraphCreatorStartup.GoToTheGraphCreator(VarsHolder.AlgorithmName);
    }

    private void FixedUpdate()
    {
        if (File.Exists(imagePath))
        {
            Thread.Sleep(200);
            SceneChanger.ChangeTheScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if (currentCycle % cycleStep == 0)
                BrightnessChanging.ChangePointsBrigness(Points);
            currentCycle++;
        }
    }
}