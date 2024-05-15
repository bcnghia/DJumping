using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Camera m_cam;

    private void Awake()
    {
        m_cam = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(m_cam.transform.position.x, m_cam.transform.position.y, 0f);
    }
}
