using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResources : MonoBehaviour {
    public Player Player;
    public Level Level;
    public LevelCompletePanel CompleteLevelUI;

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
