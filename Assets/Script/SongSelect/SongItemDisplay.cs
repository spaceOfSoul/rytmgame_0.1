using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongItemDisplay : MonoBehaviour
{
    public Text textName;
    public Text textLevel;
    public Text textArtitst;
    public Image sprite;

    public Image rankColor;
    public Text rankText;
    public Text textHighscore;

    public delegate void SongItemDisplayDelegate(SongItem item);
    public event SongItemDisplayDelegate onClick;

    public SongItem item;

    public SongManager songManager;

    Player player;

    /* static을 사용하지 않으면 이벤트가 변수값을 전부 기억하고 있기 때문에, 전에 한번이라도 눌렀던적 있다면 
    다른것을 한번 누르고 다시 눌러도 씬이 전환되지 않기 위함.*/
    static string songCheck = "";
    static int clickCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (item != null) Prime(item);

        songManager = GameObject.Find("SongSelect").GetComponent<SongManager>();

        player = FindObjectOfType<Player>();
    }

    public void Prime(SongItem item)
    {
        this.item = item;
        if (textName != null)
            textName.text = item.songName;
        if (textLevel != null)
            textLevel.text = "level : " + item.songLevel;
        if (textArtitst != null)
            textArtitst.text = item.songArtist;
        if (sprite != null)
            sprite.sprite = item.sprite;
        if (textHighscore != null)
            if (PlayerPrefs.HasKey(item.songName + "_score"))
                textHighscore.text = "Highscore : " + PlayerPrefs.GetInt(item.songName + "_score");
            else
                textHighscore.text = "Highscore : 0";
        if (rankText != null) {
            if (PlayerPrefs.HasKey(item.songName + "_rank"))
            {
                rankText.text = PlayerPrefs.GetString(item.songName + "_rank");
                switch (rankText.text)
                {
                    case "S":
                        rankColor.color = new Color32(255, 255, 0, 255);
                        break;
                    case "A":
                        rankColor.color = new Color32(0, 255, 13, 255);
                        break;
                    case "B":
                        rankColor.color = new Color32(0, 17, 255, 255);
                        break;
                    case "C":
                        rankColor.color = new Color32(217, 0, 155, 255);
                        break;
                    case "D":
                        rankColor.color = new Color32(97, 18, 16, 255);
                        break;
                    case "F":
                        rankColor.color = new Color32(51, 9, 9, 255);
                        break;
                }
            }
            else
            {
                rankText.text = "";
                rankColor.color = Color.gray;
            }
        }
    }

    public void Click()
    {
        if (onClick != null)
            onClick.Invoke(item);
        else
        {
            if (songCheck.Equals(item.songName))
                clickCnt++;
            else
            {
                clickCnt = 0;
                songCheck = item.songName;
                clickCnt++;
            }

            Debug.Log(item.songName);
            // 노래 미리듣기
            songManager.PlayAudioPreview(item.songName, item.prePlay);
            songInfoB.songName = item.songName;
            songInfoB.level = item.songLevel;
            songInfoB.footnote = item.footnote;

            // Play씬 전환및 전달할 곡데이터
            if (clickCnt.Equals(2))
            {
                songManager.SelectSong(item.songName);
                clickCnt = 0;
                SceneManager.LoadScene("StageLoading");
            }
        }
    }
}
