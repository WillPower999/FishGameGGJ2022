using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody rb;
    public float movementForce;
    public GameObject gameCamera;
    public Transform hi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fish>())
        {
            EndGame.Instance.Fade();
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            rb.AddForce(new Vector3 (-1,0,0) * movementForce);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            rb.AddForce(new Vector3(1, 0, 0) * movementForce);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0, 0, 1) * movementForce);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.AddForce(new Vector3(0, 0, -1) * movementForce);
        }
    }
}
