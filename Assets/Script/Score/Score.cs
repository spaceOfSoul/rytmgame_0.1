using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text textScore;
    Text textJudge;
    Text textCombo;
    Text greatNumber;
    Text goodNumber;
    Text missNumber;
    Text maxCmb;

    public int SongScore { private set; get; }
    public int MissCnt { private set; get; }
    public int GoodCnt { private set; get; }
    public int GreatCnt { private set; get; }
    public int Combo { private set; get; }
    public int MaxCombo { private set; get; }

    string strJudge;

    Animator comboAnim;
    Animator judgeAnim;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        textScore = GameObject.Find("scoreText").GetComponent<Text>();
        textJudge = GameObject.Find("judgeText").GetComponent<Text>();
        textCombo = GameObject.Find("comboText").GetComponent<Text>();
        greatNumber = GameObject.Find("greatNumber").GetComponent<Text>();
        goodNumber = GameObject.Find("goodNumber").GetComponent<Text>();
        missNumber = GameObject.Find("missNumber").GetComponent<Text>();
        maxCmb = GameObject.FindWithTag("maxCmbText").GetComponent<Text>();

        comboAnim = textCombo.gameObject.GetComponent<Animator>();
        judgeAnim = textJudge.gameObject.GetComponent<Animator>();
        textCombo.gameObject.SetActive(false);

        SongScore = 0;
        Combo = 0;
        MissCnt = 0;
        GoodCnt = 0;
        GreatCnt = 0;
        MaxCombo = 0;

        strJudge = "";
    }

    public void ProcessScore(int judge)
    {
        if (judge.Equals(0))
        {
            strJudge = "MISS";
            Combo = 0;
            MissCnt++;
            textJudge.color = Color.gray;
            judgeAnim.SetTrigger("hit");
            textCombo.gameObject.SetActive(false);
        }
        else
        {
            Combo++;
            if (Combo > 2)
            {
                textCombo.gameObject.SetActive(true);
                comboAnim.SetTrigger("comboUp");
            }
            if (judge.Equals(1))
            {
                SongScore += 50;
                strJudge = "GOOD";
                GoodCnt++;
                textJudge.color = Color.yellow;
                judgeAnim.SetTrigger("hit");
            }
            else if (judge.Equals(2))
            {
                SongScore += 100;
                strJudge = "GREAT";
                GreatCnt++;
                textJudge.color = Color.blue;
                judgeAnim.SetTrigger("hit");
            }
        }

        SetMaxCombo();
        SetTextScore();
    }

    void SetMaxCombo()
    {
        if (Combo > MaxCombo)
            MaxCombo = Combo;
        maxCmb.text = MaxCombo.ToString();
    }

    void SetTextScore()
    {
        textScore.text = SongScore.ToString();
        textJudge.text = strJudge;
        textCombo.text = Combo.ToString();
        greatNumber.text = GreatCnt.ToString();
        goodNumber.text = GoodCnt.ToString();
        missNumber.text = MissCnt.ToString();
    }
}
