using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public void baslat(string oyun)
    {
        SceneManager.LoadScene(oyun);
        PlayerPrefs.DeleteKey("load");
    }
    public void loading()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("load", "menu").ToString());
    }
    public void cikis()
    {
        Application.Quit();
    }
}
