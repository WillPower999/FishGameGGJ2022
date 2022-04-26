using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{

    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
    }

    // Spawn parameters for the clouds (did not vary their sizes because they're already drawn at different sizes)
    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        startPos.y = UnityEngine.Random.Range(startPos.y - 1f, startPos.y + 1f);
        cloud.transform.position = startPos;

        float speed = UnityEngine.Random.Range(0.75f, 1.5f);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
    }

    void AttemptSpawn()
    {
        // Potentially check some criteria here (if the player is alive, if the level ended, etc)
        SpawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }

    // Spawns clouds in the level at runtime so we're not waiting for them to arrive
    void Prewarm()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 5);
            SpawnCloud(spawnPos);
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
