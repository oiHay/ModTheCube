using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadSceneByIndex(0);
        }
    }

    private void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
