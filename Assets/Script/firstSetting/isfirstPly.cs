using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isfirstPly : MonoBehaviour
{
    public GameObject settingWhether;
    private void Start()
    {
        settingWhether.SetActive(false);
        if (PlayerPrefs.HasKey("isPlayed"))
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt("isPlayed", 1);
            PlayerPrefs.Save();

            settingWhether.SetActive(true);
        }
    }
}
