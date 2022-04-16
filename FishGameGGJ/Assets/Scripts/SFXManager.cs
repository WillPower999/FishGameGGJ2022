using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    [SerializeField] AudioSource collectibleSound;

    void Awake()
    {
        Instance = this;
    }

    public void PlayCollectibleSound()
    {
        collectibleSound.Play();
    }
}
