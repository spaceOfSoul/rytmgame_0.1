using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPushed : MonoBehaviour
{
    private SpriteRenderer spr;

    public KeyCode keyToPress;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            spr.color = new Color(0.6f,0.58f,0.4f,1);
        }

        if (Input.GetKeyUp(keyToPress))
        {
            spr.color = new Color(1, 1, 1, 1);
        }
    }
}
