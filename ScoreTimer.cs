using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
    float overallSeconds = 0f;
    float overallMinutes = 0f;
    float colourSeconds = 0f;
    float colourMinutes = 0f;
    float memorySeconds = 0f;
    float memoryMinutes = 0f;
    float riddleSeconds = 0f;
    float riddleMinutes = 0f;
    static public bool ColourLvl;
    static public bool MemoryLvl;
    static public bool RiddleLvl;
    public Text ColourLvlTimerText;
    public Text MemoryLvlTimerText;
    public Text RiddleLvlTimerText;
    public Text OverallTimerText;
    public GameObject Manager;
    ReadWrite rw;
    public string fullInitials;
    public string initial1;
    public string initial2;

    void Awake()
    {
        ColourLvl = true;
    }


    void Start()
    {
        overallSeconds = PlayerPrefs.GetFloat("OverallSeconds");
        overallMinutes = PlayerPrefs.GetFloat("OverallMinutes");

        initial1 = PlayerPrefs.GetString("Initial1");
        initial2 = PlayerPrefs.GetString("Initial2");
        fullInitials = initial1 + initial2;
        
         rw = Manager.GetComponent<ReadWrite>();
    }

    void Update()
    {

        if (ColourLvl)
        {
            ColourLevel();
        }

        if (MemoryLvl)
        {
            MemoryLevel();
        }

        if (RiddleLvl)
        {
            RiddleLevel();
        }

     

        overallSeconds += Time.deltaTime;


        if (overallSeconds > 59)
        {
            overallSeconds = 0f;
            overallMinutes++;


        }

        OverallTimerText.text = string.Format("{0:00}:{1:00}", overallMinutes, overallSeconds); 

    }

    public void ColourLevel()
    {
        colourSeconds += Time.deltaTime;


        if (colourSeconds > 59)
        {
            colourSeconds = 0f;
            colourMinutes++;
        }

        ColourLvlTimerText.text = string.Format("{0:00}:{1:00}", colourMinutes, colourSeconds);
        MemoryLvlTimerText.text = ("00:00");
        RiddleLvlTimerText.text = ("00:00");
    }

    public void MemoryLevel()
    {
        memorySeconds += Time.deltaTime;


        if (memorySeconds > 59)
        {
            memorySeconds = 0f;
            memoryMinutes++;
        }

        MemoryLvlTimerText.text = string.Format("{0:00}:{1:00}", memoryMinutes, memorySeconds);

        colourMinutes = PlayerPrefs.GetFloat("ColourMinutes");
        colourSeconds = PlayerPrefs.GetFloat("ColourSeconds");

        ColourLvlTimerText.text = string.Format("{0:00}:{1:00}", colourMinutes, colourSeconds);

        RiddleLvlTimerText.text = ("00:00");
    }

    public void RiddleLevel()
    {

        riddleSeconds += Time.deltaTime;


        if (riddleSeconds > 59)
        {
            riddleSeconds = 0f;
            riddleMinutes++;
        }

        RiddleLvlTimerText.text = string.Format("{0:00}:{1:00}", riddleMinutes, riddleSeconds); ;

        colourMinutes = PlayerPrefs.GetFloat("ColourMinutes");
        colourSeconds = PlayerPrefs.GetFloat("ColourSeconds");
        ColourLvlTimerText.text = string.Format("{0:00}:{1:00}", colourMinutes, colourSeconds);

        memoryMinutes = PlayerPrefs.GetFloat("MemoryMinutes");
        memorySeconds = PlayerPrefs.GetFloat("MemorySeconds");
        MemoryLvlTimerText.text = string.Format("{0:00}:{1:00}", memoryMinutes, memorySeconds);

        

    }


    public void ClearScores()
    {
        PlayerPrefs.DeleteAll();
    }
    

    public void ColourLevelEnd()
    {
        ColourLvl = false;
        MemoryLvl = true;


        PlayerPrefs.SetFloat("ColourSeconds", colourSeconds);
        PlayerPrefs.SetFloat("ColourMinutes", colourMinutes);
        PlayerPrefs.SetFloat("OverallSeconds", overallSeconds);
        PlayerPrefs.SetFloat("OverallMinutes", overallMinutes);

        PlayerPrefs.Save();
    }

    public void MemoryLevelEnd()
    {
        MemoryLvl = false;
        RiddleLvl = true;

        
        PlayerPrefs.SetFloat("MemoryMinutes", memoryMinutes);
        PlayerPrefs.SetFloat("MemorySeconds", memorySeconds);
        PlayerPrefs.SetFloat("OverallMinutes", overallMinutes);
        PlayerPrefs.SetFloat("OverallSeconds", overallSeconds);
        PlayerPrefs.Save();
    }

    public void RiddleLevelEnd()
    {
        PlayerPrefs.SetFloat("RiddleMinutes", riddleMinutes);
        PlayerPrefs.SetFloat("RiddleSeconds", riddleSeconds);
        PlayerPrefs.SetFloat("OverallSeconds", overallSeconds);
        PlayerPrefs.SetFloat("OverallMinutes", overallMinutes);
        PlayerPrefs.Save();

    }


    public void ScoreSave()
    {
        colourMinutes = PlayerPrefs.GetFloat("ColourMinutes");
        colourSeconds = PlayerPrefs.GetFloat("ColourSeconds");
        memoryMinutes = PlayerPrefs.GetFloat("MemoryMinutes");
        memorySeconds = PlayerPrefs.GetFloat("MemorySeconds");
        riddleMinutes = PlayerPrefs.GetFloat("RiddleMinutes");
        riddleSeconds = PlayerPrefs.GetFloat("RiddleSeconds");
        overallMinutes = PlayerPrefs.GetFloat("OverallMinutes");
        overallSeconds = PlayerPrefs.GetFloat("OverallSeconds");


        HighScore hs = new HighScore
        {
            Name = fullInitials,
            Pyr1Time = string.Format("{0:00}:{1:00}", colourMinutes, colourSeconds),
            Pyr2Time = string.Format("{0:00}:{1:00}", memoryMinutes, memorySeconds),
            Pyr3Time = string.Format("{0:00}:{1:00}", riddleMinutes, riddleSeconds),
            TotalTime = string.Format("{0:00}:{1:00}", overallMinutes, overallSeconds)
        };

        rw.WriteFile(hs);

        PlayerPrefs.DeleteAll();
    }

}
