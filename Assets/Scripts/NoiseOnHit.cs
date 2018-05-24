using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseOnHit : MonoBehaviour {

    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        _audioSource.Play();

    }
}
