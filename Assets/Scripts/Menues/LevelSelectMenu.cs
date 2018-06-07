using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour {
    public GameObject Content;
    public LevelList Levels;
	// Use this for initialization
	void Start () {
        var templateResource= Resources.Load("Level Template") as GameObject;
        var completedLevels = StorageeHelper.LevelStore.GetCompletedLevelsCount();
        for (int i = 0; i < completedLevels; i++)
        {
            LevelModel level = Levels.Levels[i];
            var template = Instantiate(templateResource,Content.transform);
            var levelTemplate = template.GetComponent<LevelTemplate>();
            levelTemplate.Init(level,i);


        }
	}
	

}
