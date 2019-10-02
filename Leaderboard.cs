using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Leaderboard : MonoBehaviour
{
    public Text Line1Text;
    public Text Line2Text;
    public Text Line3Text;
    public Text Line4Text;
    ReadWrite rw;
    public GameObject Manager;


    void Start()
    {
        rw = Manager.GetComponent<ReadWrite>();
       // Line1Text.text = "Name" + "  " + "LVL1" + "  " + "LVL2" + "  " + "LVL3" + "  " + "TotalTime";

    }


    void Update()
    {
        LoadLeaderboard();
    }

    void LoadLeaderboard()
    {
        List<HighScore> scores = rw.ReadFiles();

        //scores = rw.OrderLVL1Time(scores);
        //scores = rw.OrderLVL2Time(scores);
        //scores = rw.OrderLVL3Time(scores);
        scores = rw.OrderTotalTime(scores);



        Line2Text.text = scores[0].Name + "            " + scores[0].Pyr1Time + "              " + scores[0].Pyr2Time + "             " + scores[0].Pyr3Time + "             " + scores[0].TotalTime;
        Line3Text.text = scores[1].Name + "            " + scores[1].Pyr1Time + "              " + scores[1].Pyr2Time + "             " + scores[1].Pyr3Time + "             " + scores[1].TotalTime;
        Line4Text.text = scores[2].Name + "            " + scores[2].Pyr1Time + "              " + scores[2].Pyr2Time + "             " + scores[2].Pyr3Time + "             " + scores[2].TotalTime;
    }
}
