using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float Accelleration = 5000;
    public float Strafe = 5000;
    public float JumpForce = 5000;
    public float VelocityMax;


    [Range(0, 1)]
    public float Throttle;
    public float ThrottleStep = .01f;

    public float DeathSpeed = 3;

    public float AccellerationDecay = 0.1f;
    //[SerializeField]
    //private float _forwardForce;
    [SerializeField]
    private float _sideForce;
    [SerializeField]
    private float _downForce;
    [SerializeField]
    private Vector3 _velocity;
    private Rigidbody _rigidBody;

    private bool _grounded = true;
    // Use this for initialization

    Player _player;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
    }
    void FixedUpdate()
    {

        _rigidBody.AddForce(new Vector3(_sideForce, _downForce, Accelleration*Throttle));

        //_forwardForce = 0;
        _sideForce = 0;
        _downForce = 0;

        // rb.AddForce(new Vector3(0, 0, ForwardForce * Time.deltaTime));

        //debug
        _velocity = _rigidBody.velocity;
    }
    // Update is called once per frame
    
    public void Left()
    {
        _sideForce += Strafe * Time.deltaTime;
    }
    public void Right()
    {
        _sideForce -= Strafe * Time.deltaTime;
    }
    public void ThrottleUo()
    {
        Throttle = Mathf.Clamp01(Throttle + ThrottleStep * Time.deltaTime);       
    }
    public void ThrottleDown()
    {
        Throttle = Mathf.Clamp01(Throttle - ThrottleStep * Time.deltaTime);
    }
    public void Jump()
    {
        if (_grounded)
        {
            _downForce += JumpForce * Time.deltaTime;
            _grounded = false;
        }
    }

    public void Destory() {
        _rigidBody.velocity = Vector3.zero;
        Throttle = 0;
        _player.Alive = false;
    }





    public void Warp()
    {
        _player.CompleteLevel();
        foreach (var ps in GetComponentsInChildren<ParticleSystem>())
        {
            ps.Play();
        }


        _rigidBody.useGravity = false;
        _rigidBody.velocity = new Vector3(0, 0, VelocityMax);
        Throttle = 1;
    }

    
    void OnCollisionEnter(Collision collision)
    {      
        _grounded = true;

        if (Mathf.Abs(collision.impulse.z) > DeathSpeed && 
       
            Mathf.Abs(collision.impulse.z) > Mathf.Abs(collision.impulse.x) && Mathf.Abs(collision.impulse.z) >Mathf.Abs(collision.impulse.y))
        {
            Destory();
        }
    }



}
    

