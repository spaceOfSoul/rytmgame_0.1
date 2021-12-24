using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    Sheet sheet;
    Score score;
    SongManager songManager;
    Player player;
    NoteGenerotor noteGenerator;
    inGameSystemAmnager manager;

    float currentTime;      // 현재 음악샘플값

    // 숏
    float currentNoteTime1;
    float currentNoteTime2;
    float currentNoteTime3;
    float currentNoteTime4;

    float greatRate = 2205f;//50ms
    float goodRate = 4410f;//100ms
    float missRate = 8820f;

    int laneNum;

    bool alive;

    Queue<float> judgeLane1 = new Queue<float>();
    Queue<float> judgeLane2 = new Queue<float>();
    Queue<float> judgeLane3 = new Queue<float>();
    Queue<float> judgeLane4 = new Queue<float>();

    Queue<GameObject> noteList = new Queue<GameObject>();

    public int maxhealth = 100;
    public int currentHealth;

    public hpBar hp;

    void Awake()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        songManager = GameObject.Find("SongSelect").GetComponent<SongManager>();
        score = GameObject.Find("scoreManager").GetComponent<Score>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        noteGenerator = GameObject.Find("NoteGenerator").GetComponent<NoteGenerotor>();
        manager = GameObject.Find("systemManager").GetComponent<inGameSystemAmnager>();
    }
    private void Start()
    {
        SetQueue();
        currentHealth = maxhealth;
        hp.setMaxHealth(maxhealth);
        alive = true;
    }

    void Update()
    {
        currentTime = songManager.music.timeSamples + (float)player.offset;

        if (judgeLane1.Count > 0)
        {
            currentNoteTime1 = judgeLane1.Peek();
            currentNoteTime1 = currentNoteTime1 * 0.001f * songManager.music.clip.frequency;

            if (currentNoteTime1 + missRate <= currentTime)
            {
                judgeLane1.Dequeue();
                noteGenerator.notelane1.Peek().gameObject.SetActive(false);
                noteGenerator.notelane1.Dequeue();
                score.ProcessScore(0);
                takeDamage();
            }
        }

        // 2
        if (judgeLane2.Count > 0)
        {
            currentNoteTime2 = judgeLane2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * songManager.music.clip.frequency;

            if (currentNoteTime2 + missRate <= currentTime)
            {
                judgeLane2.Dequeue();
                noteGenerator.notelane2.Peek().gameObject.SetActive(false);
                noteGenerator.notelane2.Dequeue();
                score.ProcessScore(0);
                takeDamage();
            }
        }

        // 3
        if (judgeLane3.Count > 0)
        {
            currentNoteTime3 = judgeLane3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * songManager.music.clip.frequency;

            if (currentNoteTime3 + missRate <= currentTime)
            {
                judgeLane3.Dequeue();
                noteGenerator.notelane3.Peek().gameObject.SetActive(false);
                noteGenerator.notelane3.Dequeue();
                score.ProcessScore(0);
                takeDamage();
            }
        }

        // 4
        if (judgeLane4.Count > 0)
        {
            currentNoteTime4 = judgeLane4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * songManager.music.clip.frequency;

            if (currentNoteTime4 + missRate <= currentTime)
            {
                judgeLane4.Dequeue();
                noteGenerator.notelane4.Peek().gameObject.SetActive(false);
                noteGenerator.notelane4.Dequeue();
                score.ProcessScore(0);
                takeDamage();
            }
        }

        if (currentHealth <= 0 && alive)
        {
            manager.dead();
            alive = false;
        }
    }
    public void JudgeNote(int laneNum)
    {
        this.laneNum = laneNum;
        //일단 첫번째값을 제거하지않고 반환받고, 조건에 맞으면 데큐
        if (laneNum.Equals(1))
        {
            // 노트 체킹 범위
            if (currentNoteTime1 > currentTime - missRate && currentNoteTime1 < currentTime + missRate)
            {
                if (currentNoteTime1 > currentTime - goodRate && currentNoteTime1 < currentTime + goodRate)
                {
                    // 그레잇판정
                    if (currentNoteTime1 > currentTime - greatRate && currentNoteTime1 < currentTime + greatRate)
                    {
                        judgeLane1.Dequeue();
                        noteGenerator.notelane1.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane1.Dequeue();
                        score.ProcessScore(2);
                        takeHelth();
                    }
                    // 굿판정
                    else
                    {
                        judgeLane1.Dequeue();
                        noteGenerator.notelane1.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane1.Dequeue();
                        score.ProcessScore(1);
                        takeHelth();
                    }
                }
                // 너무 빨리 입력했을때 미스처리
                else
                {
                    judgeLane1.Dequeue();
                    noteGenerator.notelane1.Peek().gameObject.SetActive(false);
                    noteGenerator.notelane1.Dequeue();
                    score.ProcessScore(0);
                    takeDamage();
                }
            }
        }
        if (laneNum.Equals(2))
        {
            if (currentNoteTime2 > currentTime - missRate && currentNoteTime2 < currentTime + missRate)
            {
                if (currentNoteTime2 > currentTime - goodRate && currentNoteTime2 < currentTime + goodRate)
                {
                    // 그레잇판정
                    if (currentNoteTime2 > currentTime - greatRate && currentNoteTime2 < currentTime + greatRate)
                    {
                        judgeLane2.Dequeue();
                        noteGenerator.notelane2.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane2.Dequeue();
                        score.ProcessScore(2);
                        takeHelth();
                    }
                    // 굿판정
                    else
                    {
                        judgeLane2.Dequeue();
                        noteGenerator.notelane2.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane2.Dequeue();
                        score.ProcessScore(1);
                        takeHelth();
                    }
                }
                // 너무 빨리 입력했을때 미스처리
                else
                {
                    judgeLane2.Dequeue();
                    noteGenerator.notelane2.Peek().gameObject.SetActive(false);
                    noteGenerator.notelane2.Dequeue();
                    score.ProcessScore(0);
                    takeDamage();
                }
            }
        }
        if (laneNum.Equals(3))
        {
            if (currentNoteTime3 > currentTime - missRate && currentNoteTime3 < currentTime + missRate)
            {
                if (currentNoteTime3 > currentTime - goodRate && currentNoteTime3 < currentTime + goodRate)
                {
                    // 그레잇판정
                    if (currentNoteTime3 > currentTime - greatRate && currentNoteTime3 < currentTime + greatRate)
                    {
                        judgeLane3.Dequeue();
                        noteGenerator.notelane3.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane3.Dequeue();
                        score.ProcessScore(2);
                        takeHelth();
                    }
                    // 굿판정
                    else
                    {
                        judgeLane3.Dequeue();
                        noteGenerator.notelane3.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane3.Dequeue();
                        score.ProcessScore(1);
                        takeHelth();
                    }
                }
                // 너무 빨리 입력했을때 미스처리
                else
                {
                    judgeLane3.Dequeue();
                    noteGenerator.notelane3.Peek().gameObject.SetActive(false);
                    noteGenerator.notelane3.Dequeue();
                    score.ProcessScore(0);
                    takeDamage();
                }
            }
        }
        if (laneNum.Equals(4))
        {
            if (currentNoteTime4 > currentTime - missRate && currentNoteTime4 < currentTime + missRate)
            {
                if (currentNoteTime4 > currentTime - goodRate && currentNoteTime4 < currentTime + goodRate)
                {
                    // 그레잇판정
                    if (currentNoteTime4 > currentTime - greatRate && currentNoteTime4 < currentTime + greatRate)
                    {
                        judgeLane4.Dequeue();
                        noteGenerator.notelane4.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane4.Dequeue();
                        score.ProcessScore(2);
                        takeHelth();
                    }
                    // 굿판정
                    else
                    {
                        judgeLane4.Dequeue();
                        noteGenerator.notelane4.Peek().gameObject.SetActive(false);
                        noteGenerator.notelane4.Dequeue();
                        score.ProcessScore(1);
                        takeHelth();
                    }
                }
                // 너무 빨리 입력했을때 미스처리
                else
                {
                    judgeLane4.Dequeue();
                    noteGenerator.notelane4.Peek().gameObject.SetActive(false);
                    noteGenerator.notelane4.Dequeue();
                    score.ProcessScore(0);
                    takeDamage();
                }
            }
        }
    }

    // 각 레인의 노트 시간들을 큐에 저장
    void SetQueue()
    {
        foreach (float noteTime in sheet.noteList1)
            judgeLane1.Enqueue(noteTime);
        foreach (float noteTime in sheet.noteList2)
            judgeLane2.Enqueue(noteTime);
        foreach (float noteTime in sheet.noteList3)
            judgeLane3.Enqueue(noteTime);
        foreach (float noteTime in sheet.noteList4)
            judgeLane4.Enqueue(noteTime);
    }

    //플레이어 체력
    public void takeDamage()
    {
        currentHealth -= 10;
        hp.setHelth(currentHealth);
    }
    public void takeHelth()
    {
        if(currentHealth < maxhealth)
            currentHealth++;
        hp.setHelth(currentHealth);
    }
    
}
