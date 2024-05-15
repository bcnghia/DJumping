using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // private static instance
    static T m_ins;

    // public static instance used to refer to Singleton (e.g. MyClass.Instance)
    public static T Ins
    {
        get
        {
            // if no instance is found, find the first GameObject of type T
            if (m_ins == null)
            {
                m_ins = GameObject.FindObjectOfType<T>();

                // if no instance exists in the Scene, create a new GameObject and add the Component T 
                if (m_ins == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    m_ins = singleton.AddComponent<T>();
                }
            }
            // return the singleton instance
            return m_ins;
        }
    }

    public virtual void Awake()
    {
        MakeSingleton(true);
    }

    public virtual void Start()
    {
        
    }


    public void MakeSingleton(bool destroyOnload)
    {
        if (m_ins == null)
        {
            m_ins = this as T;
            if (destroyOnload)
            {
                var root = transform.root;

                if (root != transform)
                {
                    DontDestroyOnLoad(root);
                }
                else
                {
                    DontDestroyOnLoad(this.gameObject);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
