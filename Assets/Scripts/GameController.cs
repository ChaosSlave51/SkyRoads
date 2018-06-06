using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    LevelResources _levelResources;

    public static int CurrentLevel= 0;

    public List<string> Levels;

    //public static GameController GetInstance()
    //{
    //    var ret = FindObjectOfType<GameController>();
    //    if (ret != null)
    //    {
    //        return ret;
    //    }
    //    else
    //    {
    //        ret = Instantiate<GameController>(;
    //    }

    //}

    // Use this for initialization
    public void Awake()
    {


        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);


            foreach (var obj in FindObjectsOfType<GameController>())
            {
                if (obj != this)//run start on the main game object. This is important if it's being restarted. If this is the first time it will run on it's own
                {
                    obj.Start();
                    break;
                }
            }
            


            
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    
    }

    public void Start () {
        
        _levelResources = FindObjectOfType<LevelResources>();

        if (Levels.Count == 0)//levels have not been loaded yet
        {
            foreach (var level in _levelResources.Levels.Levels)
            {
                Levels.Add(level.LevelScenePath);
            }
        }


        _levelResources.Player.LevelComplete.AddListener(LevelComplete);

        if (_levelResources.Level != null)
        {


            Destroy(_levelResources.Level.gameObject);
        }

        Time.timeScale = 0;
        StartCoroutine(InitLevel(CurrentLevel));

        Debug.Log(StorageeHelper.LevelStore.GetLevelTime(CurrentLevel));
    }
    



    private void LevelComplete()
    {
      

        _levelResources.GetComponent<TimelineController>().PlayableDirector.Play();

        var bestLevelTime = StorageeHelper.LevelStore.GetLevelTime(CurrentLevel);
        var levelTime = _levelResources.Player.GetSecondsRacing();
        if (bestLevelTime==null || levelTime < bestLevelTime)
        {
            StorageeHelper.LevelStore.SetLevelTime(CurrentLevel, levelTime);
        }
        _levelResources.LevelComplete.SetupScoreBoard(levelTime, bestLevelTime??0);
        CurrentLevel++;
        if (CurrentLevel >= Levels.Count)
            CurrentLevel = 0;
        //StartCoroutine(LevelTransition());
    }



    IEnumerator InitLevel(int level)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Levels[level], LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        _levelResources.Level = FindObjectOfType<Level>();
        //_levelResources.Level = Instantiate<Level>(Levels[level]);
        _levelResources.Player.GetComponent<Rigidbody>().position= (_levelResources.Level.Spawn.GetComponent<Transform>().position);

        _levelResources.Hud.BestTime = StorageeHelper.LevelStore.GetLevelTime(CurrentLevel)??0;

        Time.timeScale = 1;
    }
    //// Update is called once per frame
    //void Update () {

    //}
}
