using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OpeningController : MonoBehaviour {
    public DemoShip Ship;
    // Use this for initialization
    public float PlayOdds = 0.001f;
    TimelineController _tlc;
    public AudioMixer Mixer;
    void Start () {
        _tlc = Ship.GetComponent<TimelineController>();
        float music;
        if (StorageeHelper.MusicVolume.TryGetValue(out  music))
        {
            Mixer.SetFloat("music", SoundHelper.PercentToDecible(music));
        }
        float effects;
        if (StorageeHelper.EffectsVolume.TryGetValue(out effects))
        {
            Mixer.SetFloat("effects", SoundHelper.PercentToDecible(music));
        }

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
