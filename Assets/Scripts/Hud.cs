using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    public float VelocityPercent;
    public Image VelocityDisplay;
    

    public Image ThrottleDisplay;
    public float Throttle;

 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        VelocityDisplay.fillAmount = VelocityPercent;
        ThrottleDisplay.fillAmount = Throttle;
    }
}
