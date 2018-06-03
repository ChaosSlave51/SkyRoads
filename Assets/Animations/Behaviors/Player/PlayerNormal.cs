using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormal : BasePlayerState
{
    public float BoostFullPower = 25;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    Rigidbody _rigidBody;
    float minVelocity;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _rigidBody = Player.GetComponent<Rigidbody>();
        Player.StartTime = Time.time;
        minVelocity = 0;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

        _rigidBody.AddForce(new Vector3(Ship.SideForce, Ship.DownForce, Ship.Accelleration * Ship.Throttle));
        foreach (var ps in Ship.EngineThrusts)
        {
            var m = ps.main;
            m.startSize = MathHelper.ConvertRange(0f, 1f, 0f, 0.3f, Ship.Throttle);
        }
        var fl = Mathf.Clamp(Ship.SideForce, -BoostFullPower, 0);
        foreach (var ps in Ship.RightThrusts)
        {
            var m = ps.main;
            m.startSize = MathHelper.ConvertRange(0f, BoostFullPower, 0f, 0.3f, -fl);
        }
        var fr = Mathf.Clamp(Ship.SideForce, 0, BoostFullPower);
        foreach (var ps in Ship.LeftThrusts )
        {
            var m = ps.main;
            m.startSize = MathHelper.ConvertRange(0f, BoostFullPower, 0f, 0.3f, fr);
        }
        //_forwardForce = 0;
        Ship.SideForce = 0;
        Ship.DownForce = 0;

        // rb.AddForce(new Vector3(0, 0, ForwardForce * Time.deltaTime));

        minVelocity = Mathf.Max(_rigidBody.velocity.z, minVelocity);

        if (minVelocity>0 && _rigidBody.velocity.z <= 0f)
        {
            animator.ResetTrigger("Death");
            animator.SetTrigger("Death");
        }

 
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
