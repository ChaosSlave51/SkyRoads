using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningController : MonoBehaviour {
    public DemoShip Ship;
    // Use this for initialization
    public float PlayOdds = 0.001f;
    TimelineController _tlc;
     
    void Start () {
        _tlc = Ship.GetComponent<TimelineController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (_tlc.PlayableDirector.state != UnityEngine.Playables.PlayState.Playing)
        {
            if (Random.value < PlayOdds)
            {
                Ship.SetColor(Random.ColorHSV());
                _tlc.PlayableDirector.Play();
            }
        }
        
    }
}
