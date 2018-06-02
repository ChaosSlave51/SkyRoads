using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShip : MonoBehaviour
{
    public float Accelleration = 5000;
    public float Strafe = 5000;
    public float JumpForce = 5000;
    public float VelocityMax;
    public Animator Animator;

    [Range(0, 1)]
    public float Throttle;
    public float ThrottleStep = .01f;

    public float DeathSpeed = 3;

    public float AccellerationDecay = 0.1f;
    //[SerializeField]
    //private float _forwardForce;
    
    public float SideForce;
    
    public float DownForce;
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
        Animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {


    }
    // Update is called once per frame
    
    public void Left()
    {
        SideForce += Strafe * Time.deltaTime;
    }
    public void Right()
    {
        SideForce -= Strafe * Time.deltaTime;
    }
    public void ThrottleUo()
    {
        Throttle = Mathf.Clamp01(Throttle + ThrottleStep * Time.deltaTime);
        Animator.ResetTrigger("Ready");
        Animator.SetTrigger("Ready");
    }
    public void ThrottleDown()
    {
        Throttle = Mathf.Clamp01(Throttle - ThrottleStep * Time.deltaTime);
    }
    public void Jump()
    {

        if (_grounded)
        {
            DownForce += JumpForce * Time.deltaTime;
            _grounded = false;
        }
    }

    public void Destory() {
        _player.Kill();
    }





    public void Warp()
    {
        Animator.ResetTrigger("LevelCompleted");
        Animator.SetTrigger("LevelCompleted");
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
    

