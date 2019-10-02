using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameSet : MonoBehaviour
{

    public Text firstInitial;
    public Text FullInitial1;
    public string initial1 = " ";
    public int i = 0;
    List<string> alphabet1 = new List<string>();


    void Start()
    {
        alphabet1.Add("A");
        alphabet1.Add("B");
        alphabet1.Add("C");
        alphabet1.Add("D");
        alphabet1.Add("E");
        alphabet1.Add("F");
        alphabet1.Add("G");
        alphabet1.Add("H");
        alphabet1.Add("I");
        alphabet1.Add("J");
        alphabet1.Add("K");
        alphabet1.Add("L");
        alphabet1.Add("M");
        alphabet1.Add("N");
        alphabet1.Add("O");
        alphabet1.Add("P");
        alphabet1.Add("Q");
        alphabet1.Add("R");
        alphabet1.Add("S");
        alphabet1.Add("T");
        alphabet1.Add("U");
        alphabet1.Add("V");
        alphabet1.Add("W");
        alphabet1.Add("X");
        alphabet1.Add("Y");
        alphabet1.Add("Z");
        alphabet1.Add(" ");



        initial1 = alphabet1[i];

        firstInitial.text = initial1;
        FullInitial1.text = initial1;


    }


    void Update()
    {
        print(alphabet1[4]);

        initial1 = alphabet1[i];
        firstInitial.text = initial1;
        FullInitial1.text = initial1;

        if (i == alphabet1.Count - 1)
        {
            i = 0;
        }
    }




    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            i++;
        }

    }


    public void Initial1Save()
    {
        PlayerPrefs.SetString("Initial1", initial1);
    }
}