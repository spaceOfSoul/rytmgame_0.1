using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameSystemAmnager : MonoBehaviour
{
    public GameObject deadPanel;
    public AudioClip deadSound;
    AudioSource stateSpeaker;

    SongManager songManager;

    float health;

    void Start()
    {
        songManager = GameObject.Find("SongSelect").GetComponent<SongManager>();
        stateSpeaker = GetComponent<AudioSource>();
    }
    
    public void dead()
    {
        stateSpeaker.clip = deadSound;
        stateSpeaker.Play();
        StartCoroutine("deadFunction");
    }

    IEnumerator deadFunction()
    {
        deadPanel.SetActive(true);
        songManager.StopSong(true);

        yield return new WaitForSeconds(1.2f);
        GameObject sheet = GameObject.Find("Sheet");
        GameObject score = GameObject.Find("scoreManager");
        GameObject songSelect = GameObject.Find("SongSelect");
        Destroy(sheet);
        Destroy(score);
        Destroy(songSelect);
        SceneManager.LoadScene("StageMenu");
        yield return null;
    }
}
