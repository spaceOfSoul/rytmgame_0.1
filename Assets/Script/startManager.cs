using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startManager : MonoBehaviour
{
    public GameObject loadingPanel;
    public void GameStart()
    {
        SceneManager.LoadScene("StageMenu");
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        SceneManager.LoadScene("optionScene");
    }
}
