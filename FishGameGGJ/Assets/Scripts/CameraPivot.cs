using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraPivot : MonoBehaviour
{
    [SerializeField] float rotateAmount;
    [SerializeField] Transform camera;
    public bool rotateParent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (rotateParent)
            {
                transform.DORotate(new Vector3(0, 0, -rotateAmount), .5f);
            }
            else
            {
                camera.transform.DORotate(new Vector3(0, 0, -rotateAmount), .5f);
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (rotateParent)
            {
                transform.DORotate(new Vector3(0, 0, rotateAmount), .5f);
            }
            else
            {
                camera.transform.DORotate(new Vector3(0, 0, rotateAmount), .5f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.DORotate(new Vector3(-rotateAmount, 0, 0), .5f);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            transform.DORotate(new Vector3(rotateAmount, 0, 0), .5f);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            transform.DORotate(new Vector3(0, 0, 0), .5f);
            camera.transform.DORotate(new Vector3(45, 0, 0), .5f);
            SoundManager.Instance.PlaySound(Sound.Soft_Splash);

        }
    }
}
