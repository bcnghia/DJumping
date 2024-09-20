using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pref
{
    public static int bestScore
    {
        set
        {
            int oldScore = PlayerPrefs.GetInt(PrefKey.BestScore.ToString(), 0);

            if (value > oldScore || oldScore == 0)
            {
                PlayerPrefs.SetInt(PrefKey.BestScore.ToString(), value);
            }
        }
        get => PlayerPrefs.GetInt(PrefKey.BestScore.ToString(), 0);
    }
}
