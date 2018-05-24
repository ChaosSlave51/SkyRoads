using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TimelineController : MonoBehaviour {

    public PlayableDirector PlayableDirector;
	// Use this for initialization
	void Play () {
        PlayableDirector.Play();

    }
	
}
