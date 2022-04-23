using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CameraSizeManager : MonoBehaviour
{
    [SerializeField] float LandscapeCameraSize;
    [SerializeField] float PortraitCameraSize;

    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            Camera.main.orthographicSize = PortraitCameraSize;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Camera.main.orthographicSize = LandscapeCameraSize;
        }
    }
}
