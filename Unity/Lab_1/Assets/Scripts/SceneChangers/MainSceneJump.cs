using UnityEngine;

namespace Assets.Scripts
{
    public class MainSceneJump : MonoBehaviour
    {
        public void GoToMainScene()
        {
            SceneChanger.ChangeTheScene(0);
        }
    }

}