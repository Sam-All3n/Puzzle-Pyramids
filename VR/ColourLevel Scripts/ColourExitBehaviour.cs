using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColourExitBehaviour : MonoBehaviour
{
    List<ColourPodiumBehaviour> CPBs = new List<ColourPodiumBehaviour>();
    PlayerVR plyr;
    ScoreTimer st;
    ScoreBoardMove sbm;
    public List<GameObject> Lights;
    public GameObject Player;
    public GameObject ScoreManager;
    public GameObject ScoreBoard;
    public GameObject CurrentDoor;
    Color colorBlack = Color.black;
    Color colorWhite = Color.white;
    Light light;
    List<bool> roomPodCorrs = new List<bool>();
    bool RoomResult = false;

    void Start()
    {
        foreach (GameObject l in Lights)
        {
            CPBs.Add(l.GetComponent<ColourPodiumBehaviour>());
            roomPodCorrs.Add(false);
        }
        plyr = Player.GetComponent<PlayerVR>();
        st = ScoreManager.GetComponent<ScoreTimer>();
        sbm = ScoreBoard.GetComponent<ScoreBoardMove>();
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
        foreach (ColourPodiumBehaviour c in CPBs)
            RoomResult = RoomResult && c.LightCorrect;
        print("Res: " + RoomResult);
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
            }

            if (sbm.rooms[i])
            {
                SceneManager.LoadScene("MemoryVR");
                st.ColourLevelEnd();
            }
        }
    }


}
