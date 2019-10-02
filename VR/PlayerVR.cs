using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVR : MonoBehaviour
{
    
    public bool lvlDone;
    public Manager manager;
    public bool buttonDown = false, Waiting = false; // buttonDownRight = false, WaitingRight = false;
    AudioSource source;
    public static bool musicOn = true;

    void Start()
    {
        
        PositionManager currentlvl = manager.GetCurrentLvl();
        transform.position = currentlvl.NextSpawnPoint();
        source = GetComponent<AudioSource>();
       

        if (musicOn)
        {
            source.Play();
        }
        


    }


    IEnumerator Timer()
    {
        Waiting = true;
        yield return new WaitForSeconds(1f);
        // print("Timer Finished");
        buttonDown = false;
        Waiting = false;
    }


    void Update()
    {

        OVRInput.Update();

        if (buttonDown)
        {
            if (!Waiting)
                StartCoroutine("Timer");
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            buttonDown = true;
            //  print("Trigger Pressed");
            GoToNextSpawnPoint();
        }


        if (buttonDown)
        {
            if (!Waiting)
                StartCoroutine("Timer");
        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            buttonDown = true;
            // print("Trigger Pressed");
            GoToPreviousSpawnPoint();
        }


      

       

        if (lvlDone)
        {
            lvlDone = false;
            PositionManager currentlvl = manager.GotoNextLvl();
            transform.position = currentlvl.NextSpawnPoint();
        }


       

    }


    public void Music()
    {
        print(musicOn);
        
        if(musicOn == false)
        {
            source.Stop();
        }
        
        if(musicOn == true)
        {
            source.Play();
        }
    }


    void GoToNextSpawnPoint()
    {
        PositionManager currentlvl = manager.GetCurrentLvl();
        transform.position = currentlvl.NextSpawnPoint();
    }

    void GoToPreviousSpawnPoint()
    {
        PositionManager currentlvl = manager.GetCurrentLvl();
        transform.position = currentlvl.PreviousSpawnPoint();
    }
}


