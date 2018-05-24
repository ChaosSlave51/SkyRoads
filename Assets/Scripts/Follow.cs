using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform Target;
    public bool X=true;
    public bool Y=true;
    public bool Z=true;
    // Use this for initialization
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - Target.position;
    }

    // Update is called once per frame
    void Update()
    {
 

        float x;
        if (X)
        {
            x = Target.position.x + offset.x;
        }
        else
        {
            x = transform.position.x;
        }
        float y;
        if (Y)
        {
            y = Target.position.y + offset.y;
        }
        else
        {
            y = transform.position.y;
        }
        float z;
        if (Z)
        {
            z = Target.position.z + offset.z;
        }
        else
        {
            z = transform.position.z;
        }
        transform.position = new Vector3(x, y, z);

    }
}
