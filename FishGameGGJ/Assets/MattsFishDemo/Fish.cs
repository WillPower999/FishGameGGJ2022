using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody rb;
    public float movementForce;
    public GameObject gameCamera;
    [SerializeField] public int leftRotate;
    [SerializeField] public int rightRotate;
    [SerializeField] public int upRotate;
    [SerializeField] public int downRotate;

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
            gameCamera.transform.Rotate(0, 0, leftRotate);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            rb.AddForce(new Vector3(1, 0, 0) * movementForce);
            gameCamera.transform.Rotate(0, 0, rightRotate);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0, 0, 1) * movementForce);
            gameCamera.transform.Rotate(upRotate, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.AddForce(new Vector3(0, 0, -1) * movementForce);
            gameCamera.transform.Rotate(downRotate, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            gameCamera.transform.eulerAngles = new Vector3 (45, 0, 0);
        }
    }
}
