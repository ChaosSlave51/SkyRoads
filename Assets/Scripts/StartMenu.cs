using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public GameObject OptionsMenu;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Continue()
    { }

    public void Options()
    {
        OptionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
