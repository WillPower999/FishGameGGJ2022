using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    public float movementForce;
    public GameObject gameCamera;
    [HideInInspector] public bool canGoThruPortal;
    public Animator animationClip;
    public float idleSpeed;
    public float moveSpeed;
    public bool LateralMoveAllowed = true;
    private bool fishStill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fish>())
        {
            LevelEndAnimation.Instance.FindCenterPoint();
        }
        else if (other.GetComponent<LevelBoundaries>())
        {

        }
        else
        {
            LateralMoveAllowed = false;
        }
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        LateralMoveAllowed = true;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        canGoThruPortal = true;
        fishStill = true;
    }

    void Start()
    {
        SoundManager.Instance.PlayMusic(Music.Level_Music);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (rb.velocity == Vector3.zero && fishStill)
            {
                SoundManager.Instance.PlaySound(Sound.Deep_Splash);
                fishStill = false;
            }
            transform.eulerAngles = new Vector3(0, 270, 0);
            rb.AddForce(new Vector3 (-1, 0, 0) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (rb.velocity == Vector3.zero && fishStill)
            {
                SoundManager.Instance.PlaySound(Sound.Deep_Splash);
                fishStill = false;
            }
            transform.eulerAngles = new Vector3(0, 90, 0);
            rb.AddForce(new Vector3(1, 0, 0) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (rb.velocity == Vector3.zero && fishStill)
            {
                SoundManager.Instance.PlaySound(Sound.Deep_Splash);
                fishStill = false;
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0, 0, 1) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (rb.velocity == Vector3.zero && fishStill)
            {
                SoundManager.Instance.PlaySound(Sound.Deep_Splash);
                fishStill = false;
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.AddForce(new Vector3(0, 0, -1) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else
        {
            animationClip.speed = idleSpeed;
            if (rb.velocity == Vector3.zero)
            {
                fishStill = true;
            }
        }
    }
}
