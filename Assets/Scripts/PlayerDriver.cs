using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDriver : MonoBehaviour {

    private PlayerShip _playerShip;
	// Use this for initialization
	void Start () {
        _playerShip = GetComponent<PlayerShip>();
	}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Strafe") > 0)
        {
            _playerShip.Left();
        }
        if (Input.GetAxis("Strafe") < 0)
        {
            _playerShip.Right();
        }
        if (Input.GetAxis("Accelerate") > 0)
        {
            _playerShip.ThrottleUo();
        }
        if (Input.GetAxis("Accelerate") < 0)
        {
            _playerShip.ThrottleDown();
        }
        if (Input.GetAxis("Jump") != 0)
        {
            _playerShip.Jump();
        }
    }
}
