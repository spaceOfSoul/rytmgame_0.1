using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SongList : MonoBehaviour
{
    public List<SongItem> items = new List<SongItem>();
    public SongDisplay songDisplayPrefab;

    public SongItem songItem;
    public List<NewSongItem> newItems = new List<NewSongItem>();
    public GameObject template;

    public TextAsset[] _songDatalist;

    int dirCnt;
    private void Awake()
    {
        AddItem();
    }

    void Start()
    {
        template.AddComponent<SongItem>();

        for (int i = 0; i < dirCnt; i++)
        {
            GameObject obj = Instantiate(template);
            SongItem sItem = obj.GetComponent<SongItem>();

            sItem.songName = newItems[i].songName;
            sItem.songArtist = newItems[i].songArtist;
            sItem.songLevel = newItems[i].songLevel;
            sItem.sprite = newItems[i].sprite;
            sItem.footnote = newItems[i].footnote;
            sItem.prePlay = newItems[i].prePlay;

            items.Add(obj.GetComponent<SongItem>());
        }


        SongDisplay song = (SongDisplay)Instantiate(songDisplayPrefab);
        song.Prime(items);
    }

    void AddItem()
    {
        string data = "";
        foreach (TextAsset txt in _songDatalist)
        {
            dirCnt++;
            using (StringReader reader = new StringReader(txt.text))
            {
                while ((data = reader.ReadLine()) != null)
                {
                    // parse
                    string[] splitedData = new string[2];
                    splitedData = data.Split('=');

                    if (splitedData[0] == "Title")
                        songItem.songName = splitedData[1];
                    else if (splitedData[0] == "Artist")
                        songItem.songArtist = splitedData[1];
                    else if (splitedData[0] == "Difficult")
                        songItem.songLevel = splitedData[1];
                    else if (splitedData[0] == "ImageFileName")
                        songItem.sprite = Resources.Load<Sprite>(splitedData[1].Remove(splitedData[1].Length-4) + "/" + splitedData[1]);
                    else if (splitedData[0] == "FootNote")
                        songItem.footnote = splitedData[1];
                    else if (splitedData[0] == "prePlay")
                        songItem.prePlay = int.Parse(splitedData[1]);
                    int highScore;
                    string highRank;
                    if (PlayerPrefs.HasKey(songItem.songName + "_score"))
                        highScore = PlayerPrefs.GetInt(songItem.songName + "_score");
                    else
                        highScore = 0;

                    if (PlayerPrefs.HasKey(songItem.songName + "_rank"))
                        highRank = PlayerPrefs.GetString(songItem.songName + "_rank");
                    else
                        highRank = "";
                }
            }
            newItems.Add(new NewSongItem(songItem.songName, songItem.songLevel, songItem.songArtist
                       , songItem.sprite, songItem.footnote, songItem.prePlay));
        }
    }
}
