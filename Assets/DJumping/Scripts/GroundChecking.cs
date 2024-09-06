using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(GameTag.Platform.ToString())) return;

        var platfomrLanded = collision.gameObject.GetComponent<Platform>();

        if (!GameManager.Ins || !GameManager.Ins.player || !platfomrLanded) return;

        GameManager.Ins.player.PlatformLanded = platfomrLanded;
        GameManager.Ins.player.Jump();
    }
}
