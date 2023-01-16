using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenewithButton : MonoBehaviour
{
    bool ReturnToMenu;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        ReturnToMenu = Input.GetKeyDown(KeyCode.E);
        if (ReturnToMenu)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }

}
