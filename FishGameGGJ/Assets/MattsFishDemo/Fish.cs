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
    private bool fishStill;

    [SerializeField] HoldButton up;
    [SerializeField] HoldButton down;
    [SerializeField] HoldButton left;
    [SerializeField] HoldButton right;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fish>())
        {
                LevelEndAnimation.Instance.FindCenterPoint();
        }
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || left.isPressed)
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
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || right.isPressed)
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
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || up.isPressed)
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
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || down.isPressed)
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
