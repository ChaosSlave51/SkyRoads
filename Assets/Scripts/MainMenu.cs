using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public  GameObject Options;

    public void ResumeClick()
    {
        var scene=SceneManager.GetSceneByName("Menu");
               
        SceneManager.UnloadScene(scene);
        Time.timeScale = 1;
    }


    public void OptionsClick()
    {

        Options.SetActive(true);
        gameObject.SetActive(false);

    }

}