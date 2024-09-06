using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public override void Awake()
    {
        MakeSingleton(false);
    }
}
