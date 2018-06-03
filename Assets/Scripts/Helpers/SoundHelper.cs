using UnityEngine;
using UnityEditor;

public static class SoundHelper 
{
    public static  float PercentToDecible(float percent)
    {
        //return Mathf.Lerp(-80,0,Mathf.InverseLerp(0,2,Mathf.Log10(percent)));

        return MathHelper.ConvertRange(0f, 2f, -80f, 0f,  Mathf.Log10(percent));
    }

    public static float DecibeToPercent(float decible)
    {
        // return Mathf.Pow(10,Mathf.Lerp(0, 2, Mathf.InverseLerp(-80, 0, decible)));       
        return Mathf.Pow(10, MathHelper.ConvertRange(-80f, 0f, 0f, 2f, decible));
    }
   
}