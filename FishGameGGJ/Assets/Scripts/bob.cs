using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class bob : MonoBehaviour
{
    private Vector3 _initialPosition;
    private float _initialYPosition;
    public float bobDistance;
    public float bobDuration;
    public Ease ease;

    void Start()
    {
        //_initialYPosition = transform.position.y;
        _initialPosition = transform.position;
        StartCoroutine(BobCo());
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(_initialPosition.y + bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        transform.DOMove(_initialPosition, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        StartCoroutine(BobCo());
    }
}
