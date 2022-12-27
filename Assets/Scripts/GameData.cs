using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static void AddDay()
    {
        if (PlayerPrefs.GetInt("day") == 0)
        {
            PlayerPrefs.SetInt("day", 68);
        }
        PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day") + 1);
    }

    public static void Track()
    {
        PlayerPrefs.SetInt("JustLoaded", 1);
    }

    public static void doReset()
    {
        PlayerPrefs.SetInt("reset", 1);
    }

    public static void ResetTrack()
    {
        PlayerPrefs.SetInt("JustLoaded", 0);
    }

    public static void SaveCoord(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static void SaveCoords(float x, float y, float z)
    {
        SaveCoord("x", x);
        SaveCoord("y", y);
        SaveCoord("z", z);
    }

    public static int GetIntValue(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static float GetFloatValue(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }
}
