using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddlePodiumBehaviour : MonoBehaviour {

    Color colorRed = Color.red;
    Color colorBlue = Color.blue;
    Color colorGreen = Color.green;
    Color colorMagenta = Color.magenta;
    Color colorYellow = Color.yellow;
    Color colorCyan = Color.cyan;
    Color colorBlack = Color.black;
    Light lt;
    public bool red, blue, green, magenta, yellow, cyan, black;
    public bool LightCorrect = false;
    public Color CorrectColor;






    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = colorRed;
        red = true;
        blue = false;
        green = false;
        magenta = false;
        yellow = false;
        cyan = false;
        black = false;
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            print("podium collision");

            if (red)
            {
                lt.color = colorBlue;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                blue = true;
                green = false;
                magenta = false;
                yellow = false;
                cyan = false;
                black = false;
                red = false;
            }
            else if (blue)
            {
                lt.color = colorGreen;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                red = false;
                green = true;
                magenta = false;
                yellow = false;
                cyan = false;
                black = false;
                blue = false;
            }
            else if (green)
            {
                lt.color = colorMagenta;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                red = false;
                blue = false;
                magenta = true;
                yellow = false;
                cyan = false;
                black = false;
                green = false;
            }
            else if (magenta)
            {
                lt.color = colorYellow;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                yellow = true;
                cyan = false;
                red = false;
                blue = false;
                green = false;
                black = false;
                magenta = false;
            }
            else if (yellow)
            {
                lt.color = colorCyan;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                magenta = false;
                cyan = true;
                red = false;
                blue = false;
                green = false;
                black = false;
                yellow = false;
            }
            else if (cyan)
            {
                lt.color = colorBlack;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                magenta = false;
                yellow = false;
                red = false;
                blue = false;
                green = false;
                black = true;
                cyan = false;
            }
            else if (black)
            {
                lt.color = colorRed;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                magenta = false;
                yellow = false;
                red = true;
                blue = false;
                green = false;
                cyan = false;
                black = false;


            }


        }

    }





}

