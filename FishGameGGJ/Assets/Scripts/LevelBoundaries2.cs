using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBoundaries2 : MonoBehaviour
{
    public Fish fishOne;
    public Fish fishTwo;
    public float deathDelay;
    public GameObject FishBody1;
    public GameObject FishBody2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fishOne.gameObject)
        {
            fishOne.rb.constraints = RigidbodyConstraints.None;
        }
        else if (other.gameObject == fishTwo.gameObject)
        {
            fishTwo.rb.constraints = RigidbodyConstraints.None;
        }
        StartCoroutine(Retry());
    }

    private IEnumerator Retry()
    {
        print("test");
        yield return new WaitForSeconds(deathDelay);
        EndGame.Instance.FadeOut();
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
