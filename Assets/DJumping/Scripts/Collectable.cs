using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreBonus;
    public GameObject explosionEffPb;

    public void Trigger()
    {
        if (explosionEffPb)
        {
            GameObject effect = Instantiate(explosionEffPb, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
        Destroy(gameObject);

        if (GameManager.Ins)
        {
            GameManager.Ins.AddScore(scoreBonus);
        }

        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.gotCollectable);
        }
    }
}
