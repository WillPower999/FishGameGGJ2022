using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBoundaries : MonoBehaviour
{
    public Fish fishOne;
    public Fish fishTwo;
    public float deathDelay;
    public GameObject FishBody1;
    public GameObject FishBody2;
   

    void Start()
    {
        //FishBody1.GetComp onent<Renderer>().enabled = false;
        //FishBody2.GetComponent<Renderer>().enabled = false;

    }

    private void OnTriggerExit(Collider other)
    {
        print("hello");
        if (other.gameObject == fishOne.gameObject)
        {
            fishOne.rb.constraints = RigidbodyConstraints.None;
        }
        else if (other.gameObject == fishTwo.gameObject)
        {
            fishTwo.rb.constraints = RigidbodyConstraints.None;
        }
        SoundManager.Instance.PlaySound(Sound.Over_Edge_Splash);
        StartCoroutine(Retry());
    }

    private IEnumerator Retry()
    {
        yield return new WaitForSeconds(deathDelay);
        EndGame.Instance.FadeOut();
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
