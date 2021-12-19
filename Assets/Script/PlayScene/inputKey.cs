using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputKey : MonoBehaviour
{
    Judgement judgement;
    GameObject[] notes;
    SongManager songManager;
    public HitSound hSound;

    Text textSpeed;

    Transform d;
    Transform f;
    Transform j;
    Transform k;

    Touch touch;
    Vector3 touchPos;

    Player player;

    void Start()
    {
        judgement = GameObject.Find("judgement").GetComponent<Judgement>();
        textSpeed = GameObject.Find("speedText").GetComponent<Text>();
        songManager = GameObject.Find("SongSelect").GetComponent<SongManager>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        d = GameObject.Find("DBtn").GetComponent<Transform>();
        d.gameObject.SetActive(false);
        f = GameObject.Find("FBtn").GetComponent<Transform>();
        f.gameObject.SetActive(false);
        j = GameObject.Find("JBtn").GetComponent<Transform>();
        j.gameObject.SetActive(false);
        k = GameObject.Find("KBtn").GetComponent<Transform>();
        k.gameObject.SetActive(false);

        textSpeed.text = "speed: " + player.userSpeed + "x";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            d.gameObject.SetActive(true);
            judgement.JudgeNote(1);
           // hSound.hit();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            d.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            f.gameObject.SetActive(true);
            judgement.JudgeNote(2);
            //hSound.hit();
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            f.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            j.gameObject.SetActive(true);
            judgement.JudgeNote(3);
            //hSound.hit();
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            j.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            k.gameObject.SetActive(true);
            judgement.JudgeNote(4);
           // hSound.hit();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            k.gameObject.SetActive(false);
        }

        // 뒤로가기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            songManager.StopSong(true);

            GameObject sheet = GameObject.Find("Sheet");
            GameObject score = GameObject.Find("scoreManager");
            GameObject songSelect = GameObject.Find("SongSelect");
            Destroy(sheet);
            Destroy(score);
            Destroy(songSelect);
            SceneManager.LoadScene("StageMenu");
        }
    }
}