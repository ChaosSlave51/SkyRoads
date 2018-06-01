using UnityEngine;

public class StringStore
{
    private readonly string _key;

    public StringStore(string key)
    {
        _key = key;
    }

    public  bool TryGetValue(out string ret)
    {
        if (PlayerPrefs.HasKey(_key))
        {
            ret = PlayerPrefs.GetString(_key);
            return true;
        }
        else
        {
            ret = default(string);
            return false;
        }
    }

    public string Value
    {
        get
        {
            return PlayerPrefs.GetString(_key);
        }
        set
        {
            PlayerPrefs.SetString(_key, value);
        }
    }
}