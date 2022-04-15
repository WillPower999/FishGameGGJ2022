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
    private const float DEAD_ZONE_VALUE = 0.05f;
    Vector2 movementInput;
    Vector2 savedMousePosition;

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

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if (Input.touches.Length > 0)
        {
            Touch t = Input.touches[0];
            if (t.phase == TouchPhase.Began)
            {
                savedMousePosition = t.position;
            }
            Vector2 input = t.position - savedMousePosition;
            Vector2 inputNormalized = input.normalized; 
            if (input.magnitude > DEAD_ZONE_VALUE)
            {
                movementInput = (Mathf.Abs(inputNormalized.x) > Mathf.Abs(inputNormalized.y))? new Vector2(Mathf.Sign(inputNormalized.x), 0): new Vector2(0, Mathf.Sign(inputNormalized.y));
            }
        }
        /*
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movementInput.x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1;
        }
        else
        {

        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movementInput.y = 1;
        }   

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movementInput.y = -1;
        }*/
    }

    void FixedUpdate()
    {
        float rotation = transform.eulerAngles.y;
        float prevSpeed = rb.velocity.magnitude;
        if (movementInput.x != 0)
        {
            rb.AddForce(new Vector3(movementInput.x, 0, 0) * movementForce);
            rotation = (movementInput.x > 0)? 90f: 270f;
        }
        else if (movementInput.y != 0)
        {
            rb.AddForce(new Vector3(0, 0, movementInput.y) * movementForce);
            rotation = (movementInput.y > 0)? 0f: 180f;
        }
        transform.eulerAngles = new Vector3(0, rotation, 0);

        if (rb.velocity.magnitude > 0)
        {
            if (prevSpeed == 0)
            {
                SoundManager.Instance.PlaySound(Sound.Deep_Splash);
                fishStill = false;
            }
            animationClip.speed = moveSpeed;
        }
        else
        {
            animationClip.speed = idleSpeed;
            fishStill = true;
        }
        /*
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
        }*/
    }
}
