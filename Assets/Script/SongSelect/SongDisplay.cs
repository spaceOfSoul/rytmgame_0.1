using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongDisplay : MonoBehaviour
{
    public Transform targetTransform;
    public SongItemDisplay itemDisplayPrefab;

    public void Prime(List<SongItem> items)
    {
        foreach(SongItem item in items)
        {
            SongItemDisplay display = (SongItemDisplay)Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform, false);
            display.Prime(item);
        }
    }

    public void backToHome()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject songSelect = GameObject.Find("SongSelect");
        Destroy(songSelect);
        Destroy(player);

        SceneManager.LoadScene("StartMenu");
    }
}
