using UnityEngine;
using UnityEditor;

public static class MathHelper
{
    public static int ConvertRange(int originalStart, int originalEnd,int newStart, int newEnd,int value) // value to convert
    {
        double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
        return (int)(newStart + ((value - originalStart) * scale));
    }

    public static float ConvertRange(float originalStart, float originalEnd,float newStart, float newEnd, float value) // value to convert
    {
        var scale = (newEnd - newStart) / (originalEnd - originalStart);
        return (newStart + ((value - originalStart) * scale));
    }
}