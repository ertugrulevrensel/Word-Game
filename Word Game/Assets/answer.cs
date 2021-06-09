using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answer : MonoBehaviour
{
    // Start is called before the first frame update

    KelimeGezmece kg;
    string harf;
    bool select=false;


    void Start()
    {
        kg = GameObject.Find("KelimeGezmece").GetComponent<KelimeGezmece>();
        harf = gameObject.name;
    }

    // Update is called once per frame
    private void Update()
    {
        if (kg.tiklandi == false)
        {
            select = false;
        }

    }
    public void yesil_ol()
    {
        if (kg.tiklandi == true)
        {
            if (select == false)
            {
                kg.isaretli_buton_olustur(gameObject);
                select = true;
            }
        }
    }
}
