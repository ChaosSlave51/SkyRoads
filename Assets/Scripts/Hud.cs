using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    public float VelocityPercent;
    public Image VelocityDisplay;
    

    public Image ThrottleDisplay;
    public float Throttle;


    public float StopWatch;
    public TMP_Text StopWatchDisplay;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        VelocityDisplay.fillAmount = VelocityPercent;
        ThrottleDisplay.fillAmount = Throttle;
        var time = TimeSpan.FromSeconds((double)StopWatch);
        StopWatchDisplay.text =  string.Format("{0:00}:{1:00}:{2:000}", time.Minutes,time.Seconds,time.Milliseconds);
        
    }
}
