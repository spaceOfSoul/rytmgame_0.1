using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;
    Player player;

    public string songName;
    public bool isGameFin;
    public bool isInputESC;
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        music = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        music.volume = (float)player.volume/100;
    }

    // 게임 시작시 (3초 지나고 재생)
    public void PlayAudioForPlayScene()
    {
        // 시작점 원위치
        music.timeSamples = 0;
        music.PlayDelayed(3.0f);
    }

    // 게임 완료시 결과창
    public void FinishSong()
    {
        isGameFin = music.isPlaying;

        // 노래가 끝이나고 ESC를 누르지 않아야함
        if (isGameFin.Equals(false) && isInputESC.Equals(false))
            SceneManager.LoadScene("PlayResult");
    }

    // 플레이씬으로 넘어갈때
    public void SelectSong(string songName)
    {
        this.songName = songName;
        music.Stop();
    }

    public void StopSong(bool isInputESC)
    {
        this.isInputESC = isInputESC;

        music.Stop();

    }

    public void PlayAudioPreview(string songName, int startPoint)
    {
        clip = Resources.Load(songName+"/"+songName) as AudioClip;
        music.clip = clip;

        music.timeSamples = 0;
        //프리뷰 타임 조정
        music.timeSamples += music.clip.frequency * startPoint;

        music.Play();
    }
    
}
