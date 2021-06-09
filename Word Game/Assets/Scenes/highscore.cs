using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class highscore : MonoBehaviour
{
    public string[] oyuns;
    public Text isimler;
    public Text skorlar;
    void Start()
    {
        foreach (string x in oyuns)
        {
            isimler.text += PlayerPrefs.GetString(x+"b", "-") + "\n";
            skorlar.text += PlayerPrefs.GetInt(x+"a", 0).ToString() + "\n";
        }
    }
    public void delete()
    {
        foreach (string x in oyuns)
        {
            PlayerPrefs.DeleteKey(x+"b");
            PlayerPrefs.DeleteKey(x + "a");
        }
        isimler.text = "";
        skorlar.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
