using UnityEngine;

namespace Assets.Scripts
{
    public class ProcessClosing : MonoBehaviour
    {
        public void CloseTheProcess()
        {
            GraphCreatorStartup.Process.Kill();
        }
    }
}
