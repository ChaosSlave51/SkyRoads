using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseOnHit : MonoBehaviour {

    private AudioSource _audioSource;
    public float MaxImpact = 20;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
       

        _audioSource.volume= Mathf.InverseLerp(0, MaxImpact, collision.relativeVelocity.magnitude);
        _audioSource.Play();

    }
}
