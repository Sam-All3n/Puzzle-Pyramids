using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSave : MonoBehaviour {
    public GameObject light1;
    public GameObject light2;
    NameSet ns1;
    Nameset2 ns2;


    void Start()
    {
        ns1 = light1.GetComponent<NameSet>();
        ns2 = light2.GetComponent<Nameset2>();

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            ns1.Initial1Save();
            ns2.Initial2Save();
        }

    }

}
