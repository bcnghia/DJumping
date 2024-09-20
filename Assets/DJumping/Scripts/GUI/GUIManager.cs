using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    public GameObject mainMenu;
    public GameObject gamePlay;
    public Text scoreTxt;
    public PauseDialog pauseDialog;
    public GameoverDialog gameoverDialog;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGamePlay(bool isShow)
    {
        if (gamePlay)
        {
            gamePlay.SetActive(isShow);
        }

        if (mainMenu)
        {
            mainMenu.SetActive(!isShow);
        }
    }

    public void UpdateScore(int score)
    {
        if (scoreTxt)
        {
            scoreTxt.text = "Score: " + score.ToString();
        }
    }
}
