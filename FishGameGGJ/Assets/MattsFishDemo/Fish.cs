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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fish>())
        {
            EndGame.Instance.NextLevel();
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        canGoThruPortal = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            rb.AddForce(new Vector3 (-1,0,0) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            rb.AddForce(new Vector3(1, 0, 0) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0, 0, 1) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.AddForce(new Vector3(0, 0, -1) * movementForce);
            animationClip.speed = moveSpeed;
        }
        else
        {
            animationClip.speed = idleSpeed;
        }
    }
}
