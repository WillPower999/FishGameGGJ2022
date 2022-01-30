using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndAnimation : MonoBehaviour
{
    public static LevelEndAnimation Instance;
    public Fish fishOne;
    public Fish fishTwo;
    private float distanceBetweenFish;
    public float levelChangeDelay;
    private bool collided = false;
    [SerializeField] private GameObject rotationPoint;
    [SerializeField] private GameObject sphere;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    
    public void FindCenterPoint()
    {
        if (!collided)
        {
            collided = true;
            Vector3 fishOnePos = fishOne.gameObject.transform.position;
            Vector3 fishTwoPos = fishTwo.gameObject.transform.position;
            Vector3 centerPoint = (fishOnePos + fishTwoPos) / 2;
            Destroy(fishOne.gameObject);
            Destroy(fishTwo.gameObject);
            //Instantiate(sphere, centerPoint, transform.rotation);
            Instantiate(rotationPoint, centerPoint, transform.rotation, null);
            StartCoroutine(LevelChange());    
        }
        else
        {

        }
    }

    private IEnumerator LevelChange()
    {
        yield return new WaitForSeconds(levelChangeDelay);
        EndGame.Instance.NextLevel();
    }
}
