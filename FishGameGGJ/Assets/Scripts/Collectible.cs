using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SFXManager.Instance.PlayCollectibleSound();
        Destroy(gameObject);
    }
}
