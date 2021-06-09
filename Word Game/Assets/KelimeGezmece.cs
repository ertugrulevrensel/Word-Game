using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;

public class KelimeGezmece : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Puan;
    public Text score;
    List<GameObject> butonlar;
    public List<GameObject> cevaplar;
    public GameObject[] buttons;
    public string[] sozluk;
    string kelime = null;
    public bool tiklandi = false;
    public GameObject overpanel;
    public GameObject winpanel;
    public GameObject pausepanel;
    public Text zaman;
    public float gerisayim = 60;
    public int incorrect = 0;
    int puan = 0, dogrucvp = 0;
    int syc = 0;
    public string oyun;
    int highscore;
    public GameObject names;

    void Start()
    {
        butonlar = new List<GameObject>();
        highscore = PlayerPrefs.GetInt(oyun+"a", 0);
        PlayerPrefs.SetString("load", oyun);
    }


    public void isaretli_buton_olustur(GameObject buton)
    {
        butonlar.Add(buton);
        kelime = null;
        foreach (GameObject buttoni in butonlar)
        {
            kelime = kelime + buttoni.name;
            Puan.text = kelime.ToUpper();
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

        if (pausepanel.activeSelf || winpanel.activeSelf)
        {
            gerisayim += Time.deltaTime;
        }
        
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
        foreach (GameObject objeler in cevaplar)
        {
            if (objeler.name == kelime && objeler.activeSelf == false)
            {
                objeler.SetActive(true);
                puan = puan + (int)gerisayim * 5;
                dogrucvp++;
            }
            else
            {
                syc++;
            }
            if (syc == 1 && (!pausepanel.activeSelf && !winpanel.activeSelf))
            {
                incorrect = 1;
                puan = puan - (incorrect * 5);
            }
        }
        syc = 0;
        if (sozluk.Length == dogrucvp)
        {
            winpanel.SetActive(true);
            if (puan > highscore)
            {
                names.SetActive(true);
            }
            score.text = "Your Score = " + puan;
        }

        butonlar.Clear();
    }
    public void karistir()
    {
        Random rasgele = new Random();
        int sayi = rasgele.Next(0, (buttons.Length));
        int sayi2 = rasgele.Next(0, (buttons.Length));
        Vector2 x;
        x = buttons[sayi].transform.position;
        buttons[sayi].transform.position = buttons[sayi2].transform.position;
        buttons[sayi2].transform.position=x;
    }
    public void submit()
    {
        PlayerPrefs.SetInt(oyun+"a", puan);
        PlayerPrefs.SetString(oyun+"b", names.GetComponent<InputField>().text);
        PlayerPrefs.Save();
        MonoBehaviour.print(puan + "bu");
        
    }
}
