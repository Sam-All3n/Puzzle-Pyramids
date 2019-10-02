using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    public string sceneName;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            SceneManager.LoadScene(sceneName);
        }

    }

    public void Change()
    {
        SceneManager.LoadScene(sceneName);
    }
}