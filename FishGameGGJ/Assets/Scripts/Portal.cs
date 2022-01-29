using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    bool canEnter;

    private void Awake()
    {
        canEnter = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fish>() && other.GetComponent<Fish>().canGoThruPortal && canEnter)
        {
            linkedPortal.canEnter = false;
            other.GetComponent<Fish>().canGoThruPortal = false;
            other.transform.position = linkedPortal.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Fish>())
        {
            other.GetComponent<Fish>().canGoThruPortal = true;
            canEnter = true;
        }
    }


}
