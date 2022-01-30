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
    public bool creditIndex;

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
        if (creditIndex)
        {
            StartCoroutine(Credits());
        }
        else
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1);
        if (creditIndex)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private IEnumerator Credits()
    {
        yield return new WaitForSeconds(10);
        creditIndex = false;
        FadeIn();
    }
}
