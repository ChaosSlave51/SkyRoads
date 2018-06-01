using UnityEngine;

public class FloatStore
{
    private readonly string _key;

    public FloatStore(string key)
    {
        _key = key;
    }

    public  bool TryGetValue(out float ret)
    {
        if (PlayerPrefs.HasKey(_key))
        {
            ret = PlayerPrefs.GetFloat(_key);
            return true;
        }
        else
        {
            ret = default(float);
            return false;
        }
    }

    public  float Value
    {
        get
        {
            return PlayerPrefs.GetFloat(_key);
        }
        set
        {
            PlayerPrefs.SetFloat(_key, value);
        }
    }
}