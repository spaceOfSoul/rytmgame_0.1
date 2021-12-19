using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class songInfoB : MonoBehaviour
{
    public static string songName;
    public static string level;
    public static string footnote;

    public Image songImg;
    public Text sName;
    public Text levelText;
    public Text foot;

    private void LateUpdate()
    {
        sName.text = songName;
        levelText.text = level;
        foot.text = footnote;
        this.songImg.sprite = Resources.Load<Sprite>(sName.text + "/" + sName.text + "_Img") as Sprite;
    }
}
