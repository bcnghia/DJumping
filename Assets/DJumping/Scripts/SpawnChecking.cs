using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChecking : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Platform.ToString()))
        {
            var platform = collision.GetComponent<Platform>();

            if (!platform || !GameManager.Ins || !GameManager.Ins.LastPlatformSpawned) return;
            
            if (platform.Id == GameManager.Ins.LastPlatformSpawned.Id)
            {
                GameManager.Ins.SpawnPlatform();
            }
        }
    }
}
