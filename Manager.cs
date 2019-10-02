using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    PositionManager[] Levels;
    int CurrentLvl = 0;
    
    void Start()
    {
        CurrentLvl = 0;
    }
    
    public PositionManager GetCurrentLvl()
    {
        return Levels[CurrentLvl];
    }

    public PositionManager GotoNextLvl()
    {
        CurrentLvl++;
        if (CurrentLvl >= Levels.Length)
            CurrentLvl = 0;
        return GetCurrentLvl();
    }
}
