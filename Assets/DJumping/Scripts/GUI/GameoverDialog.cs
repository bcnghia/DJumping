using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverDialog : Dialog
{
    public Text totalScoreTxt;
    public Text bestScoreTxt;

    public override void Show(bool isShow)
    {
        base.Show(isShow);
        
        if (totalScoreTxt && GameManager.Ins)
            totalScoreTxt.text = GameManager.Ins.Score.ToString();

        if (bestScoreTxt)
            bestScoreTxt.text = Pref.bestScore.ToString();
    }

    public void Replay()
    {
        SceneManager.sceneLoaded += OnSceneLoadedEvent;
        SceneController.Ins.LoadCurrentScene();
    }

    private void OnSceneLoadedEvent(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.Ins)
            GameManager.Ins.PlayGame();

        SceneManager.sceneLoaded -= OnSceneLoadedEvent;
    }
}
