using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public GameObject OptionsMenu;
    public GameObject LevelSelect;
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
    public void LevelSelectClick()
    {
        LevelSelect.SetActive(true);
        gameObject.SetActive(false);
    }
}
