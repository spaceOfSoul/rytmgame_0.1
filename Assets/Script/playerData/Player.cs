using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Player : MonoBehaviour
{
    public bool isEditMode = false;
    //save
    public int volume;
    public int userSpeed;
    public int offset;
    public int hitSound;

    public GameObject LoadingPanel;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("__volume"))
            volume = PlayerPrefs.GetInt("__volume");
        else
        {
            PlayerPrefs.SetInt("__volume", 40);
            volume = PlayerPrefs.GetInt("__volume");
        }

        if (PlayerPrefs.HasKey("__userSpeed"))
            userSpeed = PlayerPrefs.GetInt("__userSpeed");
        else
        {
            PlayerPrefs.SetInt("__userSpeed", 2);
            userSpeed = PlayerPrefs.GetInt("__userSpeed");
        }

        if (PlayerPrefs.HasKey("__offSet"))
            offset = PlayerPrefs.GetInt("__offSet");
        else
        {
            PlayerPrefs.SetInt("__offSet", -7900);
            offset = PlayerPrefs.GetInt("__offSet");
        }

        if (PlayerPrefs.HasKey("__hitSound"))
            hitSound = PlayerPrefs.GetInt("__hitSound");
        else
        {
            PlayerPrefs.SetInt("__hitSound", 0);
            hitSound = PlayerPrefs.GetInt("__hitSound");
        }

        PlayerPrefs.Save();
        LoadingPanel.SetActive(false);
    }
}