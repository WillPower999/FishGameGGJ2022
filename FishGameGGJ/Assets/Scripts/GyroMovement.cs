using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMovement : MonoBehaviour
{
    [SerializeField] Fish fish1;
    [SerializeField] Fish fish2;
    Quaternion gyro;

    [SerializeField] float movementSpeed;

    void Start()
    {
        Input.gyro.enabled = false;
        Input.gyro.enabled = true;
        gyro = new Quaternion(0, 0, 0, 0);
    }

    void Update()
    {
        gyro = Input.gyro.attitude;
        fish1.rb.AddForce(new Vector3(-gyro.y * movementSpeed, 0, gyro.x * movementSpeed));
        fish2.rb.AddForce(new Vector3(-gyro.y * movementSpeed, 0, gyro.x * movementSpeed));
    }
}
