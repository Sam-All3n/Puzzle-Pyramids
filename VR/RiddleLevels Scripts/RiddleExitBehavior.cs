using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RiddleExitBehavior : MonoBehaviour {
    List<RiddlePodiumBehaviour> RPBs = new List<RiddlePodiumBehaviour>();
    PlayerVR plyr;
    ScoreTimer st;
    ScoreBoardMove sbm;
    RiddleMasterScript rms;
    public List<GameObject> Lights;
    public GameObject Player;
    public GameObject ScoreManager;
    public GameObject ScoreBoard;
    public GameObject CurrentDoor;
    public GameObject RiddleMaster;
    Color colorBlack = Color.black;
    Color colorWhite = Color.white;
    Light light;
    List<bool> roomPodCorrs = new List<bool>();
    bool RoomResult = false;

    void Start()
    {
        foreach (GameObject l in Lights)
        {
            RPBs.Add(l.GetComponent<RiddlePodiumBehaviour>());
            roomPodCorrs.Add(false);
        }
        plyr = Player.GetComponent<PlayerVR>();
        st = ScoreManager.GetComponent<ScoreTimer>();
        sbm = ScoreBoard.GetComponent<ScoreBoardMove>();
        rms = RiddleMaster.GetComponent<RiddleMasterScript>();
        light = GetComponent<Light>();
        light.color = colorBlack;
    }

    public void DoorOpen()
    {
        Destroy(CurrentDoor);
    }


    void Update()
    {
        RoomResult = true;
        foreach (RiddlePodiumBehaviour r in RPBs)
            RoomResult = RoomResult && r.LightCorrect;
       // print("Res: " + RoomResult);
        if (RoomResult)
        {
            light.color = colorWhite;
        }
        else
        {
            light.color = colorBlack;
        }

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            int i = 4;
            if (RoomResult)
            {
                plyr.lvlDone = true;
                sbm.ChangeRoom();
                rms.ChangeLevel2();
            }

            if (sbm.rooms[i])
            {
                SceneManager.LoadScene("LeaderBoards");
                st.RiddleLevelEnd();
                st.ScoreSave();
            }
        }
    }


}
