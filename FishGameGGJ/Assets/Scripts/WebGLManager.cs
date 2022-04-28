using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLManager : MonoBehaviour
{
    public static WebGLManager Instance;

    public bool isForWeb;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
