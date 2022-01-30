using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
/// /////////Avengers
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
    }

    public void NextLevel()
    {
        FadeOut();
        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
