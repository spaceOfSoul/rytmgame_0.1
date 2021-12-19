using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    AudioSource me;
    Player player;
    private void Start()
    {
        me = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if(player.hitSound == 1)
        {
            me.mute = true;
        }
        else
        {
            me.mute = false;
        }
    }
    public void hit() => me.Play();
}
