using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;

    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
