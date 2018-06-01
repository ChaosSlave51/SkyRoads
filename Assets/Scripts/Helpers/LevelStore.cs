using System.Collections.Generic;
using UnityEngine;

public class LevelStore
{
    private readonly string _key;

    public LevelStore(string key)
    {
        _key = key;
    }
    private string GetStorageKey(int level)
    {
        return $"{_key}-{level}";
    }
    public float? GetLevelTime(int lelelNumber)
    {
        var key = GetStorageKey(lelelNumber);
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetFloat(key);
        }
        else
        {
            return null;
        }
    }
    public void  SetLevelTime(int lelelNumber,float value)
    {
        var key = GetStorageKey(lelelNumber);
        PlayerPrefs.SetFloat(key,value);
    }

    public int GetCompletedLevelsCount()
    {

        int i = 0;
        while (PlayerPrefs.HasKey(GetStorageKey(i)))
        {
            i++;
        }
        return i;
    }
}