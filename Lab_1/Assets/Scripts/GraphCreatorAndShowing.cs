using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class GraphCreatorAndShowing : MonoBehaviour
{
    public Button GraphBuildingButton;
    public TMP_Dropdown AlgorithmName;

    public void OnEnable()
    {
        GraphBuildingButton.onClick.AddListener(() => ShowTheGraphic());
    }

    public void OnDisable()
    {
        GraphBuildingButton.onClick.RemoveAllListeners();
    }
    public void ShowTheGraphic()
    {
        VarsHolder.AlgorithmName = AlgorithmName.options[AlgorithmName.value].text.Replace(" ", "_");
        SceneChanger.ChangeTheScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
