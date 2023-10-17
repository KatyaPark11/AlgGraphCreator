using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GraphCreatorAndShowing : MonoBehaviour
    {
        public TMP_Dropdown AlgorithmName;

        public void ShowTheGraphic()
        {
            VarsHolder.AlgorithmName = AlgorithmName.options[AlgorithmName.value].text.Replace(" ", "_");
            SceneChanger.ChangeTheScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}