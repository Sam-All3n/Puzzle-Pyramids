using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPodiumBehaviour : MonoBehaviour
{
    Color colorRed = Color.red;
    Color colorBlue = Color.blue;
    Color colorGreen = Color.green;
    Light lt;
    public bool red, green, blue;
    public bool LightCorrect = false;
    public Color CorrectColor;

    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = colorRed;
        red = true;
        blue = false;
        green = false;
    }


    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            if (red)
            {
                lt.color = colorBlue;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                blue = true;
                green = false;
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
                blue = false;
            }
            else if (green)
            {
                lt.color = colorRed;
                if (lt.color == CorrectColor)
                    LightCorrect = true;
                else
                    LightCorrect = false;
                red = true;
                blue = false;
                green = false;
            }
           

        }

    }




}





