using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.EndlessGame
{
    public class UnFollowCam : MonoBehaviour
    {
        private Vector3 m_startingPos;

        private void Awake()
        {
            m_startingPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = m_startingPos;
        }
    }
}
