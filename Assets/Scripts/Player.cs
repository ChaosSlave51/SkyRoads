using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent Death;
    public UnityEvent LevelComplete;
    public UnityEvent Started;
    
    private float _startTime=0;
    private float _endTime = 0;
    private bool hasStarted;

    public bool GetHasStarted()
    {
        return hasStarted;
    }

    public float GetSecondsRacing()
    {
        if(_endTime!=0)
        {
            return _endTime-_startTime;
        }

        if (_startTime == 0)
        {
            return 0;
        }
        else
        {
            return Time.time- _startTime;
        }
    }

    public void SetHasStarted(bool value)
    {
        hasStarted = value;
        if (hasStarted == true)
        {
            if (Started != null)
            {
                Started.Invoke();
            }
            _startTime = Time.time;
        }
        else
        {
            _startTime = 0;
        }
    }

    [SerializeField]
    private bool _alive = true;
    //private Rigidbody _rigidBody;

    //private void Start()
    //{
    //    _rigidBody = GetComponent<Rigidbody>();
    //}

    public bool Alive
    {
        get
        {
            return _alive;
        }
        set
        {
            _alive = value;
            //#if UNITY_EDITOR
            //            alive = _alive;
            //#endif

            if (_alive == false)
            {
                if (Death != null)
                {
                    Death.Invoke();
                }
            }
        }
    }

    public void CompleteLevel()
    {
        if (_alive == true)
        {
            _endTime = Time.time;
            if (LevelComplete != null)
            {
                LevelComplete.Invoke();
            }
        }
    }

}




