using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoShip : MonoBehaviour {
    public Material Material;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetColor(Color color)
    {
        Material.SetColor("Color_D027E98", color);
    }
}
