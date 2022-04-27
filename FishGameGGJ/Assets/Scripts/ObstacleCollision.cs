using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollision(Collider other)
    {
        SoundManager.Instance.PlaySound(Sound.Dragon_Huff);
    }
}
