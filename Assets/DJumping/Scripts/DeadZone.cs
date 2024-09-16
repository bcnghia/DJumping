using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Player.ToString()))
        {
            Destroy(collision.gameObject);
            Debug.Log("Gameover!!!");
        }

        if (collision.CompareTag(GameTag.Platform.ToString()))
        {
            Destroy(collision.gameObject);
        }
    }
}
