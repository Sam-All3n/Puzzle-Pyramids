using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardMove : MonoBehaviour
{

    public bool room1, room2, room3, room4;
    public List<bool> rooms;
    public List<Vector3> Cams;
    
    

    void Start()
    {
        room1 = true;
        room2 = false;
        room3 = false;
        room4 = false;
        
        
    }


    public void ChangeCamRoom(int index)
    {
        Cams = new List<Vector3>()
        {
             new Vector3(-2.74f, 2.10f, 9.49f),
             new Vector3(-2.74f, 2.10f, -12.34f),
             new Vector3(-2.74f, 2.10f, -36.22f),
             new Vector3(-2.74f, 2.10f, -66.65f),
             new Vector3(-2.74f, 2.10f, 9.49f)

        };
        transform.position = Cams[index];
    }

    public void ChangeRoom()
    {

        int currentIndex = rooms.IndexOf(true);
        rooms[currentIndex] = false;
        if (currentIndex < rooms.Count)
        {
            currentIndex++;
            rooms[currentIndex] = true;
        }
        
        ChangeCamRoom(currentIndex);
        print(currentIndex);



    }
}
