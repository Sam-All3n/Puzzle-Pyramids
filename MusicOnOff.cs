using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    PlayerVR plyr;
    public GameObject player;


    void Start()
    {
        plyr = player.GetComponent<PlayerVR>();
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            PlayerVR.musicOn = !PlayerVR.musicOn;
            plyr.Music();
        }
    }
}


