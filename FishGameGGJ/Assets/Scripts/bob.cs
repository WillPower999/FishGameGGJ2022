using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class bob : MonoBehaviour
{
    private float _initialYPosition;
    public float bobDistance;
    public float bobDuration;
    public Ease ease;

    void Start()
    {
        _initialYPosition = transform.position.y;
        StartCoroutine(BobCo());
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(_initialYPosition + bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        transform.DOMoveY(_initialYPosition - bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        StartCoroutine(BobCo());
    }
}
