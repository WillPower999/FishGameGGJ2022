using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CameraSizeManager : MonoBehaviour
{
    [SerializeField] float LandscapeCameraSize;
    [SerializeField] float PortraitCameraSize;

    private void Start()
    {
        if (PlayerPrefs.GetInt("IsPortrait") == 1)
        {
            Camera.main.orthographicSize = PortraitCameraSize;
        }
        else
        {
            Camera.main.orthographicSize = LandscapeCameraSize;
        }
    }

    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            Camera.main.orthographicSize = PortraitCameraSize;
            PlayerPrefs.SetInt("IsPortrait", 1);
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Camera.main.orthographicSize = LandscapeCameraSize;
            PlayerPrefs.SetInt("IsPortrait", 0);
        }
    }
}
