using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudObserver : MonoBehaviour {
    public Hud Hud;


    // Use this for initialization
    private PlayerShip _playerShip;

    private Player _player;
    private Rigidbody _playerRigidBody;
	void Start () {
        _playerRigidBody = GetComponent<Rigidbody>();
        _playerShip= GetComponent<PlayerShip>();

        _player = GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        Hud.VelocityPercent =Mathf.Clamp01(_playerRigidBody.velocity.z/_playerShip.VelocityMax);
        Hud.Throttle = _playerShip.Throttle;
        Hud.StopWatch = _player.GetSecondsRacing();

    }
}
