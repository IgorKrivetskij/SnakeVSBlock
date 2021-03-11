using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : Button
{
    [SerializeField] private GameObject _pausePanel;

    public void Resume()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }
}
