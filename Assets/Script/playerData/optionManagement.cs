using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class optionManagement : MonoBehaviour
{
    Player p;
    public GameObject saved;

    [Header("volume")]
    public Slider vol_slider;
    public Text vol_inutText;

    [Header("noteSpeed")]
    public Slider ns_slider;
    public Text ns_inutText;
    

    [Header("Offset")]
    public Slider ofs_slider;
    public Text ofs_text;

    [Header("hitSound")]
    public Button soundToggle;
    public Text hitSoundText;

    private void Awake()
    {
        p = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        vol_slider.value = p.volume;
        vol_inutText.text = vol_slider.value.ToString();

        ns_slider.value = p.userSpeed;
        ns_inutText.text = ns_slider.value.ToString();

        ofs_slider.value = p.offset;
        ofs_text.text = p.offset.ToString() + "hz";

        if (p.hitSound == 1)
            hitSoundText.text = "켬";
        else
            hitSoundText.text = "끔";
    }

    //UI
    public void BackToHome()
    {
        GameObject pl = GameObject.FindWithTag("Player");
        Destroy(pl);
        SceneManager.LoadSceneAsync("StartMenu");
    }
    public void SaveButton()
    {
        saved.SetActive(true);
        PlayerPrefs.Save();
        p.volume = PlayerPrefs.GetInt("__volume");
        p.userSpeed = PlayerPrefs.GetInt("__userSpeed");
        p.offset = PlayerPrefs.GetInt("__offSet");
        p.hitSound = PlayerPrefs.GetInt("__hitSound");
        saved.SetActive(false);
    }
    public void changeVolume()
    {
        PlayerPrefs.SetInt("__volume", (int)vol_slider.value);
        vol_inutText.text = PlayerPrefs.GetInt("__volume").ToString();
    }
    public void changeNS()
    {
        PlayerPrefs.SetInt("__userSpeed", (int)ns_slider.value);
        ns_inutText.text = PlayerPrefs.GetInt("__userSpeed").ToString();
    }

    public void ChangeOffset()
    {
        PlayerPrefs.SetInt("__offSet", (int)ofs_slider.value);
        ofs_text.text = PlayerPrefs.GetInt("__offSet").ToString() + "hz";
    }
    public void hitSoundStatus()
    {
        if (PlayerPrefs.GetInt("__hitSound") == 1)
        {
            hitSoundText.text = "끔";
            PlayerPrefs.SetInt("__hitSound", 0);
        }
        else {
            hitSoundText.text = "켬";
            PlayerPrefs.SetInt("__hitSound", 1);
        }
    }
}
