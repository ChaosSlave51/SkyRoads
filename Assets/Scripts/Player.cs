using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent Death;
    public UnityEvent LevelComplete;
    [SerializeField]
    private bool _alive = true;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

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
            if (LevelComplete != null)
            {
                LevelComplete.Invoke();
            }
        }
    }

}




