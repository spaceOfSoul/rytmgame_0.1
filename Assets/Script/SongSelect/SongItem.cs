using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SongItem : MonoBehaviour
{
    public string songName;
    public string songLevel;
    public string songArtist;
    public Sprite sprite;
    public string footnote;
    public int prePlay;
}

[System.Serializable]
public class NewSongItem
{
    public string songName;
    public string songLevel;
    public string songArtist;
    public Sprite sprite;
    public string footnote;
    public int prePlay;

    public NewSongItem(string name, string level, string artist, Sprite sprite, string fotn, int pre)
    {
        songName = name;
        songLevel = level;
        songArtist = artist;
        this.sprite = sprite;
        footnote = fotn;
        prePlay = pre;
    }
}