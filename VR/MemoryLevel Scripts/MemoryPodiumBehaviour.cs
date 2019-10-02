using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPodiumBehaviour : MonoBehaviour
{

    Color colorMagenta = Color.magenta;
    Color colorYellow = Color.yellow;
    Color colorCyan = Color.cyan;
    Color colorBlack = Color.black;
    Light lt;
    public bool magenta, yellow, cyan, black;
    public bool LightCorrect = false;
    public Color CorrectColor;



    void Start()
    {


        lt = GetComponent<Light>();
        lt.color = colorMagenta;
        magenta = true;
        yellow = false;
        cyan = false;
        black = false;
    }



    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            if (magenta)
            {
                lt.color = colorYellow;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                yellow = true;
                cyan = false;
                magenta = false;
                black = false;
            }
            else if (yellow)
            {
                lt.color = colorCyan;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                cyan = true;
                yellow = false;
                magenta = false;
                black = false;
            }
            else if (cyan)
            {
                lt.color = colorBlack;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                black = true;
                cyan = false;
                yellow = false;
                magenta = false;
            }
            else if (black)
            {
                lt.color = colorMagenta;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                magenta = true;
                black = false;
                yellow = false;
                cyan = false;
            }


        }

    }






}