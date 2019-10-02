using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nameset2 : MonoBehaviour {

    public Text secondInitial;
    public Text FullInitial2;
    public string initial2 = " ";
    public int i = 0;
    List<string> alphabet2 = new List<string>();


    void Start()
    {
        alphabet2.Add("A");
        alphabet2.Add("B");
        alphabet2.Add("C");
        alphabet2.Add("D");
        alphabet2.Add("E");
        alphabet2.Add("F");
        alphabet2.Add("G");
        alphabet2.Add("H");
        alphabet2.Add("I");
        alphabet2.Add("J");
        alphabet2.Add("K");
        alphabet2.Add("L");
        alphabet2.Add("M");
        alphabet2.Add("N");
        alphabet2.Add("O");
        alphabet2.Add("P");
        alphabet2.Add("Q");
        alphabet2.Add("R");
        alphabet2.Add("S");
        alphabet2.Add("T");
        alphabet2.Add("U");
        alphabet2.Add("V");
        alphabet2.Add("W");
        alphabet2.Add("X");
        alphabet2.Add("Y");
        alphabet2.Add("Z");
        alphabet2.Add(" ");

    

        initial2 = alphabet2[i];
        
        secondInitial.text = initial2;
        FullInitial2.text = initial2;
        

    }


    void Update()
    {
        print(alphabet2[4]);
   
        initial2 = alphabet2[i];
        secondInitial.text = initial2;
        FullInitial2.text = initial2;

        if (i == alphabet2.Count - 1)
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

    public void Initial2Save()
    {
        PlayerPrefs.SetString("Initial2", initial2);
    }
}
