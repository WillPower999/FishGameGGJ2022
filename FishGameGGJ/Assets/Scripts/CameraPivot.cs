using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    [SerializeField] float rotateAmount;
    [SerializeField] Transform camera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            camera.transform.Rotate(0, 0, -rotateAmount);
            SoundManager.Instance.PlaySound(Sound.Deep_Splash);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            camera.transform.Rotate(0, 0, rotateAmount);
            SoundManager.Instance.PlaySound(Sound.Deep_Splash);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(-rotateAmount, 0, 0);
            SoundManager.Instance.PlaySound(Sound.Deep_Splash);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(rotateAmount, 0, 0);
            SoundManager.Instance.PlaySound(Sound.Deep_Splash);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
            camera.transform.eulerAngles = new Vector3(45, 0, 0);
            SoundManager.Instance.PlaySound(Sound.Soft_Splash);

        }
    }
}
