using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("NameSet");
    }

    public void Leaderboards()
    {
        SceneManager.LoadScene("Leaderboards");
    }
}
