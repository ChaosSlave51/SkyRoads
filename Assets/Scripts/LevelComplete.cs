﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelComplete : MonoBehaviour {

    public TMP_Text YourTIme;
    public TMP_Text BestTime;
    public TMP_Text BestTimeAchived;

    public void SetupScoreBoard(float yourTime, float bestTime)
    {

        YourTIme.text = TimeHelper.FormatSeconds(yourTime);



        if (bestTime == 0)
        {
            BestTime.text = TimeHelper.FormatSeconds(yourTime);
            BestTimeAchived.gameObject.SetActive(true);
        }
        else
        {
            BestTime.text = TimeHelper.FormatSeconds(bestTime);
            BestTimeAchived.gameObject.SetActive(yourTime < bestTime);
        }
        

    }

}
