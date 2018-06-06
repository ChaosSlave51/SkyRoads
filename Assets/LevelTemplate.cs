using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTemplate : MonoBehaviour
{

    public bool Enabled;

    public Image ThumbnailImage;
    public TMP_Text TitleText;
    public TMP_Text DescriptionText;
    public Button Button;
    [SerializeField]
    private int _levelId;
    // Use this for initialization

    public void Init(LevelModel levleModel, int levelId)
    {
        ThumbnailImage.sprite = levleModel.Thumbnail;
        TitleText.text = levleModel.Title;
        DescriptionText.text = levleModel.Description;
        _levelId = levelId;
        //to do: store levelScenePath
    }

    public void LoadLevel()
    {
        GameController.CurrentLevel = _levelId;
        SceneManager.LoadSceneAsync("Scenes/Game");
    }

}
