using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleMasterScript : MonoBehaviour
{
    public Text lvlText;
    public Text lvlText2;
    public GameObject lvlCanvas;
    public GameObject lvlCanvas2;
    public bool lvl1;
    public bool lvl2;
    public bool lvl3;
    public bool lvl4;
    public List<bool> levels;
    public List<Vector3> Cams;

    void Start()
    {
        
        lvlCanvas.gameObject.SetActive(false);
        lvlCanvas2.gameObject.SetActive(true);
        lvl1 = true;
        lvl2 = false;
        lvl3 = false;
        lvl4 = false;


    }



    public void ChangeLevel()
    {
        if (lvl1)
        {
            transform.position = new Vector3(11.81f, 0f, -1.78f);
        }
        else if (lvl2)
        {
            transform.position = new Vector3(11.81f, 0f, -25.63f);
        }
        else if (lvl3)
        {
            transform.position = new Vector3(11.81f, 0f, -54.35f);
        }
        else if (lvl4)
        {
            transform.position = new Vector3(11.81f, 0f, -85.12f);
        }
    }


    public void ChangeCamLevel(int index)
    {
        Cams = new List<Vector3>()
        {
             new Vector3(11.81f, 0f, -1.78f),
             new Vector3(11.81f, 0f, -25.63f),
             new Vector3(11.81f, 0f, -54.35f),
             new Vector3(11.81f, 0f, -85.12f),
             new Vector3(11.81f, 0f, -1.78f)
        };
        transform.position = Cams[index];
    }



    public void ChangeLevel2()
    {
        int currentIndex = levels.IndexOf(true);
        levels[currentIndex] = false;
        if (currentIndex < levels.Count)
        {
            currentIndex++;
            levels[currentIndex] = true;
        }
        ChangeCamLevel(currentIndex);
        lvlCanvas.gameObject.SetActive(false);
        lvlCanvas2.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("Collison");
        if (levels[0])
        {

            lvlText2.text = "In need of a clue?" + "\n" + "let me help you out, if you wish to hear the clue touch the orb ";

            if (collision.gameObject.tag == "Hand")
            {
                lvlCanvas2.gameObject.SetActive(false);
                lvlCanvas.gameObject.SetActive(true);

                lvlText.text = "You may see me if you look at the sea or the sky," + "\n" + "now go solve the puzzle!";
                
            }

            
        }

        if (levels[1])
        {
            
            lvlText2.text = "This ones tricky want a clue?" + "\n" + "if you want to hear it touch the orb";

            if (collision.gameObject.tag == "Hand")

            {
                lvlCanvas2.gameObject.SetActive(false);
                lvlCanvas.gameObject.SetActive(true);
                lvlText.text = "Neither of these colours are in the rainbow";
                
            }
            




        }

        if (levels[2])
        {
           
            lvlText2.text = "You made it to the final room do you require one last clue?" + "\n" + "If you want to hear it touch the orb";

            if (collision.gameObject.tag == "Hand")

            {
                lvlCanvas2.gameObject.SetActive(false);
                lvlCanvas.gameObject.SetActive(true);
                lvlText.text = "These colours combined make white";
                
            }
           


        }

        if (levels[3])
        {
           
            lvlText2.text = "You made it to the final room do you require one last clue?" + "\n" + "If you want to hear it touch the orb";

            if (collision.gameObject.tag == "Hand")

            {
                lvlCanvas2.gameObject.SetActive(false);
                lvlCanvas.gameObject.SetActive(true);
                lvlText.text = "Use the light from each podium to represent its corresponding element in the order:" + "\n" + "Earth, Air, Fire and Water";
                
            }
           

        }
    }

  

}
