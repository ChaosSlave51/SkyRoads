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

    private float _bestTime;
    public float BestTime {
        get { return _bestTime; }
        set { _bestTime = value;
            
            BestTimeDisplay.text = TimeHelper.FormatSeconds(value);
        }
    }
    public TMP_Text BestTimeDisplay;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        VelocityDisplay.fillAmount = VelocityPercent;
        ThrottleDisplay.fillAmount = Throttle;
        
        StopWatchDisplay.text = TimeHelper.FormatSeconds(StopWatch);
        
    }
}

