using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroller : MonoBehaviour
{
    public int creditScroll;

    private void Awake()
    {
        SoundManager.Instance.PlayMusic(Music.UI_Game_Audio);
    }

    //public void OnTriggerEnter()
    void Start()
    {
        StartCoroutine(Credits());
    } 
    private IEnumerator Credits()
    {
        yield return new WaitForSeconds(creditScroll);
        SceneManager.LoadScene("MainMenu");
    }

}
