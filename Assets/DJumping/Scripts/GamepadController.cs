using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadController : Singleton<GamepadController>
{
    public bool isOnMobile;
    private bool m_canMoveLeft;
    private bool m_canMoveRight;

    public bool CanMoveLeft { get => m_canMoveLeft; set => m_canMoveLeft = value; }
    public bool CanMoveRight { get => m_canMoveRight; set => m_canMoveRight = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    private void Update()
    {
        if (isOnMobile) return;

        m_canMoveLeft = Input.GetAxisRaw("Horizontal") < 0 ? true : false;
        m_canMoveRight = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
    }
}
