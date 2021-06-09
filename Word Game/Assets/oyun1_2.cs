using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyun1_2 : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Puan;
    List<GameObject> butonlar;
    string kelime = null;
    public bool tiklandi = false;
    public GameObject atext;
    public GameObject y1text;
    public GameObject y2text;
    public GameObject itext;
    public GameObject overpanel;
    public GameObject winpanel;
    public Text zaman;
    public float gerisayim = 60;
    public int incorrect = 0;
    int puan = 0;


    void Start()
    {
        butonlar = new List<GameObject>();
    }


    public void isaretli_buton_olustur(GameObject buton)
    {
        butonlar.Add(buton);
        kelime = null;
        foreach (GameObject buttoni in butonlar)
        {
            kelime = kelime + buttoni.name;
            Puan.text = kelime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tiklandi = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            tiklandi = false;
            yazi_olustur();
            if (puan >= 0)
            {
                Puan.text = puan.ToString();
            }
            else
            {
                Puan.text = "0";
            }

        }
        gerisayim -= Time.deltaTime;

        if (gerisayim >= 0)
        {
            zaman.text = ((int)gerisayim).ToString();
        }
        else
        {
            zaman.text = "0";
            overpanel.SetActive(true);
        }
    }


    void yazi_olustur()
    {
        if (kelime == "ayı" && itext.activeSelf == false)
        {
            atext.SetActive(true);
            y2text.SetActive(true);
            itext.SetActive(true);
            puan = puan + (int)gerisayim * 5;
        }
        else if (kelime == "ay" && y1text.activeSelf == false)
        {
            atext.SetActive(true);
            y1text.SetActive(true);
            puan = puan + (int)gerisayim * 5;
        }
        else
        {
            incorrect = 1;
            puan = puan - (incorrect * 5);
        }
        if(itext.activeSelf == true && y1text.activeSelf == true)
        {
            winpanel.SetActive(true);
        }
        butonlar.Clear();
    }
}