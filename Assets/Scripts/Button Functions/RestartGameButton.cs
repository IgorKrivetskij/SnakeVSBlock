using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameButton : Button
{
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
    }
}
