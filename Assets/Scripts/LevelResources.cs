using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResources : MonoBehaviour {
    public Player Player;
    public Level Level;

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool _loadingMenu=false;
    public void Update()
    {
        if (Input.GetButton("Cancel") )
        {
            
            var foo=SceneManager.GetSceneByName("Menu");
            
            if (!_loadingMenu&& !foo.isLoaded)
            {
                _loadingMenu = true;
                Time.timeScale = 0;

                StartCoroutine(LoadMenu());
                
            }
        }
    }
    IEnumerator LoadMenu()
    {
       var asyncLoad= SceneManager.LoadSceneAsync("Scenes/Menu", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        _loadingMenu = false;
    }
}
