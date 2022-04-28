using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] Image image;
    [SerializeField] Sprite pressedSprite;
    [SerializeField] Sprite releaseSprite;

    [HideInInspector] public bool isPressed;

    void Start()
    {
        if (WebGLManager.Instance != null && WebGLManager.Instance.isForWeb)
        {
            transform.localScale = Vector3.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        image.sprite = pressedSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPressed = true;
        image.sprite = pressedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPressed = false;
        image.sprite = releaseSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        image.sprite = releaseSprite;
    }
}