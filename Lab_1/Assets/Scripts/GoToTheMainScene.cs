using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GoToTheMainScene : MonoBehaviour
{
    public Button BackButton;

    public void OnEnable()
    {
        BackButton.onClick.AddListener(() => ShowTheGraphic());
    }

    public void OnDisable()
    {
        BackButton.onClick.RemoveAllListeners();
    }
    public void ShowTheGraphic()
    {
        SceneChanger.ChangeTheScene(0);
    }
}
