using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class OrientationManager : MonoBehaviour
{
    [SerializeField] GameObject landscapeContainer;
    [SerializeField] GameObject portraitContainer;

    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            landscapeContainer.transform.localScale = Vector3.zero;
            portraitContainer.transform.localScale = Vector3.one;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            landscapeContainer.transform.localScale = Vector3.one;
            portraitContainer.transform.localScale = Vector3.zero;
        }
    }
}
