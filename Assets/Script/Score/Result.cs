using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    Score score;
    Sheet sheet;

    [SerializeField]Image spriteSongImg;
    [SerializeField]Text textSongName;
    [SerializeField]Text textSongSheet;
    [SerializeField]Text textSongLevel;
    [SerializeField]Text textSongJudge;
    [SerializeField]Text textSongCombo;
    [SerializeField]Text textSongScore;
    [SerializeField]Text textRank;
    [SerializeField]Text textAC;

    float accuracy;
    void Start()
    {
        score = GameObject.Find("scoreManager").GetComponent<Score>();
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();

        spriteSongImg.sprite = Resources.Load<Sprite>(sheet.Title + "/" + sheet.ImageFileName) as Sprite;
        

        textSongName.text = sheet.Title;
        textSongSheet.text = "aritst by " + sheet.Artist;
        textSongLevel.text = "level : "+ sheet.Difficult;

        StringBuilder judge = new StringBuilder();

        judge.Append("GREAT   ");
        judge.Append(score.GreatCnt.ToString());
        judge.Append("\n");
        judge.Append("GOOD    ");
        judge.Append(score.GoodCnt.ToString());
        judge.Append("\n");
        judge.Append("MISS       ");
        judge.Append(score.MissCnt.ToString());
        textSongJudge.text = judge.ToString();

        textSongCombo.text = "MAX Combo  " + score.MaxCombo.ToString();
        textSongScore.text = "Score   " + score.SongScore.ToString();

        int maxScore = (score.GreatCnt + score.GoodCnt + score.MissCnt) * 100;
        accuracy = ((float)score.SongScore / (float)maxScore) * 100f;
        textAC.text = String.Format("AC: {0:0.00}%",accuracy); ;
        Debug.Log(accuracy);

        if (accuracy >= 94f)
        {
            textRank.text = "S";
            textRank.color = new Color32(255,255,0,255);
        }
        else if (accuracy >= 90f)
        {
            textRank.text = "A";
            textRank.color = new Color32(0, 255, 13, 255);
        }
        else if (accuracy >= 86f)
        {
            textRank.text = "B";
            textRank.color = new Color32(0, 17, 255, 255);
        }
        else if (accuracy >= 82f)
        {
            textRank.text = "C";
            textRank.color = new Color32(217, 0, 155, 255);
        }
        else if(accuracy >= 78f)
        {
            textRank.text = "D";
            textRank.color = new Color32(97, 18, 16, 255);
        }
        else
        {
            textRank.text = "F";
            textRank.color = new Color32(51, 9, 9, 255);
        }

        SaveResult();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SelectSong();
        }
    }


    public void SelectSong()
    {
        GameObject sheet = GameObject.Find("Sheet");
        GameObject score = GameObject.Find("scoreManager");
        GameObject songSelect = GameObject.Find("SongSelect");
        Destroy(sheet);
        Destroy(score);
        Destroy(songSelect);

        SceneManager.LoadScene("StageMenu");
    }

    public void SaveResult()
    {
        if (PlayerPrefs.HasKey(sheet.Title + "_score"))
        {
            if (score.SongScore > PlayerPrefs.GetInt(sheet.Title + "_score"))
            {
                PlayerPrefs.SetInt(sheet.Title + "_score", score.SongScore);
                PlayerPrefs.SetString(sheet.Title + "_rank", textRank.text);
            }
        }
        else
        {
            PlayerPrefs.SetInt(sheet.Title + "_score", score.SongScore);
            PlayerPrefs.SetString(sheet.Title + "_rank", textRank.text);
        }
        PlayerPrefs.Save();
    }
}
