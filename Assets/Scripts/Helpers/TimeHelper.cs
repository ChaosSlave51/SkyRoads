using UnityEngine;
using UnityEditor;
using System;

public static class TimeHelper 
{
    public static string FormatSeconds(float seconds)
    {
        var time = TimeSpan.FromSeconds(seconds);
        return string.Format("{0:00}:{1:00}:{2:000}", time.Minutes, time.Seconds, time.Milliseconds);
    }
   
}