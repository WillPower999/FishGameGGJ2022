using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    [SerializeField] float rotateAmount;
    [SerializeField] Transform camera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            camera.transform.Rotate(0, 0, -rotateAmount);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            camera.transform.Rotate(0, 0, rotateAmount);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(-rotateAmount, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Rotate(rotateAmount, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.eulerAngles = Vector3.zero;
            camera.transform.eulerAngles = new Vector3(45, 0, 0);
        }
    }
}
