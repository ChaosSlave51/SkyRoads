using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour {
    public GameObject Content;
    public LevelList Levels;
	// Use this for initialization
	void Start () {
        var templateResource= Resources.Load("Level Template") as GameObject;
        int id = 0;
        foreach (var level in Levels.Levels)
        {
            var template = Instantiate(templateResource,Content.transform);
            var levelTemplate = template.GetComponent<LevelTemplate>();
            levelTemplate.Init(level,id++);


        }
	}
	

}
