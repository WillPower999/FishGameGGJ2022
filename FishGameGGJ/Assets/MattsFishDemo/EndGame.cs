using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;
    Image fadeImage;

    void Awake()
    {
        Instance = this;
        fadeImage = GetComponent<Image>();
        FadeIn();
    }

    public void FadeIn()
    {
        fadeImage.DOFade(1, 0);
        fadeImage.DOFade(0, 1);
    }

    public void FadeOut()
    {
        fadeImage.DOFade(1, 1);
        StartCoroutine(SwitchLevel());
    }

    private IEnumerator SwitchLevel ()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
