using UnityEngine;
using UnityEditor;

//[CreateAssetMenu(menuName = "SkyRoads/Level", fileName ="Level")]
[System.Serializable]
public class LevelModel 
{

    public Sprite Thumbnail;
    public string Title;
    [TextArea]
    public string Description;
    public string LevelScenePath;
    public AudioClip Song;


}