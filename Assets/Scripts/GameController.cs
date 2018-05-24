using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    LevelResources _levelResources;

    public int CurrentLevel= 0;

    public List<Level> Levels;
    // Use this for initialization
    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
                      
            
            FindObjectsOfType<GameController>()[0].Start();
        }

        //}
    }

    public void Start () {
        _levelResources = FindObjectOfType<LevelResources>();

        
        _levelResources.Player.Death.AddListener(PlayerDeath);
        _levelResources.Player.LevelComplete.AddListener(LevelComplete);


        // if (Level != null && Level.gameObject.activeInHierarchy)// once we delete the first level, this will load the level. Otherwise we play the level we are working on 
        if (_levelResources.Level != null)
        {
            //Levels[0] = Instantiate<Level>(Level);

            Destroy(_levelResources.Level.gameObject);
        }
        //else
        //{
        InitLevel(CurrentLevel);
    }
    

    public UnityEvent PlayerDied;

    private void LevelComplete()
    {
        _levelResources.GetComponent<TimelineController>().PlayableDirector.Play();

        CurrentLevel++;
        if (CurrentLevel >= Levels.Count)
            CurrentLevel = 0;
        //StartCoroutine(LevelTransition());
    }
    //IEnumerator LevelTransition()
    //{

    //    //_levelResources.CompleteLevelUI.gameObject.SetActive(true);

    //    yield return new WaitForSeconds(2);

    //    //Destroy(Level.gameObject); 
    //    //InitLevel(CurrentLevel);
      
        
    //}



    private void PlayerDeath()
    {
        if (PlayerDied != null)
        {
            PlayerDied.Invoke();
        }
        Destroy(_levelResources.Level.gameObject);

        InitLevel(CurrentLevel);
        _levelResources.Player.Alive = true;
    }

    public void InitLevel(int level)
    {

        _levelResources.Level = Instantiate<Level>(Levels[level]);
        _levelResources.Player.GetComponent<Rigidbody>().position= (_levelResources.Level.Spawn.GetComponent<Transform>().position);
       
    }
    //// Update is called once per frame
    //void Update () {

    //}
}
