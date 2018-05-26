using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{


    public  GameObject Options;

    public void ResumeClick()
    {

    }

    public void OptionsClick()
    {

        Options.SetActive(true);
        gameObject.SetActive(false);

    }

}