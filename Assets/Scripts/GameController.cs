using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    LevelResources _levelResources;

    public int CurrentLevel= 0;

    public List<string> Levels;
    public AudioMixer Mixer;
    // Use this for initialization
    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
                      
            
            FindObjectsOfType<GameController>()[0].Start();
        }
    
    }

    public void Start () {
        if(PlayerPrefs.HasKey("music"))
            Mixer.SetFloat("music", PlayerPrefs.GetFloat("music"));

        if (PlayerPrefs.HasKey("effects"))
            Mixer.SetFloat("effects", PlayerPrefs.GetFloat("effects"));

        _levelResources = FindObjectOfType<LevelResources>();       
        _levelResources.Player.Death.AddListener(PlayerDeath);
        _levelResources.Player.LevelComplete.AddListener(LevelComplete);

        if (_levelResources.Level != null)
        {


            Destroy(_levelResources.Level.gameObject);
        }

        Time.timeScale = 0;
        StartCoroutine(InitLevel(CurrentLevel));
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


    private void PlayerDeath()
    {
        if (PlayerDied != null)
        {
            PlayerDied.Invoke();
        }
        //Destroy(_levelResources.Level.gameObject);

        _levelResources.Player.GetComponent<Rigidbody>().position = (_levelResources.Level.Spawn.GetComponent<Transform>().position);
        _levelResources.Player.Alive = true;
    }

    IEnumerator InitLevel(int level)
    {
        ;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Levels[level], LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        _levelResources.Level = FindObjectOfType<Level>();
        //_levelResources.Level = Instantiate<Level>(Levels[level]);
        _levelResources.Player.GetComponent<Rigidbody>().position= (_levelResources.Level.Spawn.GetComponent<Transform>().position);
        Time.timeScale = 1;
    }
    //// Update is called once per frame
    //void Update () {

    //}
}
