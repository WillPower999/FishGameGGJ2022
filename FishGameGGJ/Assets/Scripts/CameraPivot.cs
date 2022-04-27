using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraPivot : MonoBehaviour
{
    [SerializeField] float rotateAmount;
    [SerializeField] Transform camera;
    public bool rotateParent;

    public GameObject cameraObj;
    public bool startNewShake = false;
    public float duration = 0.5f;
    public float magnitude = 0.3f;

    private float camPosx;
    private float camPosy;
    private float remainingDuration = 0f;
    private float remainingMagnitude = 0f;
    private float shakeFadeTime;

    [SerializeField] HoldButton up;
    [SerializeField] HoldButton down;
    [SerializeField] HoldButton left;
    [SerializeField] HoldButton right;

    // Update is called once per frame
    void Start()
    {
        camPosx = cameraObj.transform.localPosition.x;
        camPosy = cameraObj.transform.localPosition.y;
    }

    void Update()
    {
        if (startNewShake)
        {
            StartShake(duration, magnitude);
            startNewShake = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || left.isPressed)
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
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || right.isPressed)
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
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || up.isPressed)
        {
            transform.DORotate(new Vector3(-rotateAmount, 0, 0), .5f);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || down.isPressed)
        {
            transform.DORotate(new Vector3(rotateAmount, 0, 0), .5f);

        }

        //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        //{
        //    transform.DORotate(new Vector3(0, 0, 0), .5f);
        //    camera.transform.DORotate(new Vector3(45, 0, 0), .5f);
        //    SoundManager.Instance.PlaySound(Sound.Soft_Splash);
        //}

        if (!up.isPressed && !down.isPressed && !left.isPressed && !right.isPressed)
        {
            transform.DORotate(new Vector3(0, 0, 0), .5f);
            camera.transform.DORotate(new Vector3(45, 0, 0), .5f);
            //SoundManager.Instance.PlaySound(Sound.Soft_Splash);
        }
    }

    private void LateUpdate()
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        if (remainingDuration > 0)
        {
            remainingDuration -= Time.deltaTime;

            float x = Random.Range(-1f, 1f) * remainingMagnitude;
            float y = Random.Range(-1f, 1f) * remainingMagnitude;

            transform.localPosition = new Vector3(camPosx + x, camPosy + y, originalPos.z);

            elapsed += Time.deltaTime;

            remainingMagnitude = Mathf.MoveTowards(remainingMagnitude, 0f, shakeFadeTime * Time.deltaTime);
        }
    }

    public void StartShake(float duration, float magnitude)
    {
        remainingDuration = duration;
        remainingMagnitude = magnitude;

        shakeFadeTime = magnitude / duration;
    }
}