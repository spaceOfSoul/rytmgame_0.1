using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class NoteGenerotor : MonoBehaviour
{
    Sync sync;
    Transform startPos;
    Sheet sheet;

    public GameObject notePrefab;

    public Queue<GameObject> notelane1 = new Queue<GameObject>();
    public Queue<GameObject> notelane2 = new Queue<GameObject>();
    public Queue<GameObject> notelane3 = new Queue<GameObject>();
    public Queue<GameObject> notelane4 = new Queue<GameObject>();

    // 노트간격
    float noteCorrectRate = 0.001f;

    // 노트 및 바 미리 연산
    float notePosY;
    float noteStartPosY;
    float offset;

    public bool isGenFin = false;

    void Start()
    {
        sync = GameObject.Find("Sync").GetComponent<Sync>();
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        startPos = GameObject.Find("StartPos").GetComponent<Transform>();
        notePosY = sync.scrollSpeed;
        noteStartPosY = sync.scrollSpeed * 3.0f;
        offset = sync.offset;
    }

    void Update()
    {
        if (isGenFin.Equals(false))
        {
            GenNote();
            isGenFin = true;
        }
    }

    // 노트생성
    void GenNote()
    {
        foreach (float noteTime in sheet.noteList1) {
            GameObject i = Instantiate(notePrefab, new Vector3(-2.1f, noteStartPosY + offset + notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
            notelane1.Enqueue(i);
        }
        foreach (float noteTime in sheet.noteList2)
        {
            GameObject i = Instantiate(notePrefab, new Vector3(-0.7f, noteStartPosY + offset + notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
            notelane2.Enqueue(i);
        }
        foreach (float noteTime in sheet.noteList3)
        {
            GameObject i = Instantiate(notePrefab, new Vector3(0.7f, noteStartPosY + offset + notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
            notelane3.Enqueue(i);
        }
        foreach (float noteTime in sheet.noteList4)
        {
            GameObject i = Instantiate(notePrefab, new Vector3(2.1f, noteStartPosY + offset + notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
            notelane4.Enqueue(i);
        }
    }
}

