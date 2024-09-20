using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    private Platform m_platformLanded;
    private float m_movingLimitX;

    private Rigidbody2D m_rb;

    public Platform PlatformLanded { get => m_platformLanded; set => m_platformLanded = value; }
    public float MovingLimitX { get => m_movingLimitX; }

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovingHandle();
    }

    public void Jump()
    {
        if (!GameManager.Ins || GameManager.Ins.state != GameState.Playing) return;

        if (!m_rb || m_rb.velocity.y > 0.01 || !m_platformLanded) return;

        if (m_platformLanded is BreakablePlatform)
        {
            m_platformLanded.PlatformAction();
        }

        m_rb.velocity = new Vector2(m_rb.velocity.x, jumpForce);

        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.jump);
        }
    }

    private void MovingHandle()
    {
        if (!GamepadController.Ins || !m_rb || !GameManager.Ins || GameManager.Ins.state != GameState.Playing) return;

        if (GamepadController.Ins.CanMoveLeft)
        {
            m_rb.velocity = new Vector2(-moveSpeed, m_rb.velocity.y);
        }
        else if (GamepadController.Ins.CanMoveRight)
        {
            m_rb.velocity = new Vector2(moveSpeed, m_rb.velocity.y);
        }
        else
        {
            m_rb.velocity = new Vector2(0,m_rb.velocity.y);
        }

        m_movingLimitX = Helper.Get2DCamSize().x / 2;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -m_movingLimitX, m_movingLimitX),
            transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Collectable.ToString()))
        {
            var collectable = collision.GetComponent<Collectable>();
            if (collectable)
            {
                collectable.Trigger();
            }
        }
    }
}
