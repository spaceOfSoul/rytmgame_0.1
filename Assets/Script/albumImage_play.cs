using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class albumImage_play : MonoBehaviour
{
    Sheet sheet;
    Image background;

    void LateUpdate()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        background = gameObject.GetComponent<Image>();

        background.sprite = Resources.Load<Sprite>(sheet.Title + "/" + sheet.ImageFileName);

    }
}
