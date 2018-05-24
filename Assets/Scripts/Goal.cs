using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private bool _warped = false;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (!_warped)
            {
                _warped = true;
                var ship = collider.GetComponent<PlayerShip>();
                Destroy(gameObject);
                ship.Warp();
            }
        }
    }
}
