using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;
    Image fadeImage;

    void Awake()
    {
        Instance = this;
        fadeImage = GetComponent<Image>();
    }

    public void Fade()
    {
        fadeImage.DOFade(1, 1);
    }
}
