using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObserver : MonoBehaviour {

    private PlayerShip _playerShip;
    public AudioSource EngineNoise;
    private Rigidbody _playerRigidBody;

    public float BaseVolue;
    void Start()
    {
        BaseVolue = EngineNoise.volume;
        _playerRigidBody = GetComponent<Rigidbody>();
        _playerShip = GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update () {
        EngineNoise.volume = _playerShip.Throttle* BaseVolue;
        EngineNoise.pitch =Mathf.Clamp(1+_playerRigidBody.velocity.z / _playerShip.VelocityMax * 2,1,3);

    }
}
