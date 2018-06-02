using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public UnityEvent LevelComplete;
    public Animator Animator;
    
    public float StartTime=0;
    public float EndTime = 0;



    private void Start()
    {
        Animator = GetComponent<Animator>();
    }


    public float GetSecondsRacing()
    {
        if(EndTime!=0)
        {
            return EndTime-StartTime;
        }

        if (StartTime == 0)
        {
            return 0;
        }
        else
        {
            return Time.time- StartTime;
        }
    }

    public void StartLevel()
    {

    }

    public void Kill()
    {
        Animator.ResetTrigger("Death");
        Animator.SetTrigger("Death");

    }

    public void CompleteLevel()
    {

            EndTime = Time.time;
            if (LevelComplete != null)
            {
                LevelComplete.Invoke();
            }

    }

}




