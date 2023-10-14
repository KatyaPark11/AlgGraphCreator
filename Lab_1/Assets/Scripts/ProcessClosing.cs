using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessClosing : MonoBehaviour
{
    public Button BackButton;

    private void Start()
    {
        BackButton.onClick.AddListener(CloseTheProcess);
    }

    private void CloseTheProcess()
    {
        GraphCreatorStartup.Process.Kill();
    }
}
