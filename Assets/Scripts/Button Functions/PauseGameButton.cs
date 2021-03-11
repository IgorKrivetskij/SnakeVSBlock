using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButton : Button
{
    [SerializeField] private GameObject _pausePanel;

    public void Pause()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }
}
