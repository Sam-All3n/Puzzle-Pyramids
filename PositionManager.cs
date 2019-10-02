using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionManager : MonoBehaviour
{
    [SerializeField]
    Transform[] SpawnPoints;
    //Transform[] Reverse;
    int Position = 0; 
   
    void Start()
    {
        //Reverse = SpawnPoints.Reverse().ToArray();
    }

    public Vector3 NextSpawnPoint()
    {
        Vector3 res = SpawnPoints[Position].position;
        Position++;

        if (Position >= SpawnPoints.Length)
            Position = 0;

        return res + new Vector3(0, 1, 0) ;
    }

    public Vector3 PreviousSpawnPoint()
    {
        //SpawnPoints.Reverse().ToArray();
        Vector3 res = SpawnPoints[Position].position;//Reverse[Position].position;

        Position--;

        if(Position < 0)
        {
            Position = SpawnPoints.Length - 1;
        }

        return res + new Vector3(0, 1, 0);
    }

}
