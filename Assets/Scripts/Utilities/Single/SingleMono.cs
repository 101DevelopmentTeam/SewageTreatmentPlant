using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMono<T> : MonoBehaviour where T : SingleMono<T>
{
    protected static T instance;
    private static GameObject go;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                if (!go)
                {
                    go = GameObject.Find("SingletonMono");
                    if (!go)
                    {
                        go = new GameObject("SingletonMono");
                    }
                }
                DontDestroyOnLoad(go);
                instance = go.GetComponent<T>();
                if (!instance)
                {
                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}
