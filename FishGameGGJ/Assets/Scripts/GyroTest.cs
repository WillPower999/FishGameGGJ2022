using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GyroTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gX;
    [SerializeField] TextMeshProUGUI gY;
    [SerializeField] TextMeshProUGUI gZ;
    [SerializeField] TextMeshProUGUI gW;
    [SerializeField] TextMeshProUGUI gyroEnabled;

    private void Start()
    {
        Input.gyro.enabled = false;
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion gyro = Input.gyro.attitude;
        gX.SetText("X: " + gyro.x.ToString("N3"));
        gY.SetText("Y: " + gyro.y.ToString("N3"));
        gZ.SetText("Z: " + gyro.z.ToString("N3"));
        gW.SetText("W: " + gyro.w.ToString("N3"));
        gW.SetText("gyroEnabled: " + gyroEnabled);
    }
}
