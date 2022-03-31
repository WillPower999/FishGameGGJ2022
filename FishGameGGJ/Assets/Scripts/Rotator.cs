using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rotator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 direction;
    public bool mouseOver = false;
    public float speed;
    public float initialSpeed;
    public float nullSpeed;

    void FixedUpdate()
    {
        transform.Rotate(direction * speed);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        speed = nullSpeed;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        speed = initialSpeed;
    }
}
