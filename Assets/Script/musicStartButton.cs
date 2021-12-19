using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicStartButton : MonoBehaviour
{
    public AudioClip music;
    public TextAsset chart;
    public void SceneMove()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
