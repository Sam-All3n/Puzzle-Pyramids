using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject laserPointer;
    public GameObject leftHand;
    public GameObject rightHand;
    bool paused = false;
    ScoreTimer st;
    public GameObject ScoreManager;
    PlayerVR plyr;
    public GameObject player;


    void Start ()
    { 
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        laserPointer.gameObject.SetActive(false);
        leftHand.gameObject.SetActive(true);
        rightHand.gameObject.SetActive(true);
        st = ScoreManager.GetComponent<ScoreTimer>();
        plyr = player.GetComponent<PlayerVR>();
    }
	
	
	void Update () {

        OVRInput.Update();

        if (OVRInput.Get(OVRInput.Button.Start))
        {
            if (paused == true)
            {
                pauseMenu.gameObject.SetActive(false);
                laserPointer.gameObject.SetActive(false);
                leftHand.gameObject.SetActive(true);
                rightHand.gameObject.SetActive(true);
                paused = false;
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                laserPointer.gameObject.SetActive(true);
                leftHand.gameObject.SetActive(false);
                rightHand.gameObject.SetActive(false);
                paused = true;
                Time.timeScale = 0;
            }
        }
    }


    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        laserPointer.gameObject.SetActive(false);
        leftHand.gameObject.SetActive(true);
        rightHand.gameObject.SetActive(true);
        paused = false;
        Time.timeScale = 1;
    }


    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuVR");
        ScoreTimer.ColourLvl = true;
        ScoreTimer.MemoryLvl = false;
        ScoreTimer.RiddleLvl = false;
        st.ClearScores();
    }

    public void MusicOnOff()
    {
        PlayerVR.musicOn = !PlayerVR.musicOn;
        plyr.Music();
    }

}
