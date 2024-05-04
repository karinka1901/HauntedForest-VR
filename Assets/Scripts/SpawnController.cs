using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class SpawnController : MonoBehaviour
{
    PLayersHealth player;
    public Transform[] spawnLocations;
    public GameObject[] enemies;
    private float spawnRate = 1.5f;
    float Timer = 0f;
    void Start()
    {
        player = FindObjectOfType<PLayersHealth>();
       // StartCoroutine(spawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            SpawnEnemies(spawnRate);
        }
    }


    private void SpawnEnemies(float spawnInterval)
    {
        Timer += Time.deltaTime;

        if (Timer >= spawnInterval)
        {
            GameObject spawnedEnemy = Instantiate(enemies[Random.Range(0,3)], spawnLocations[Random.Range(0, 12)].position, spawnLocations[Random.Range(0, 12)].rotation);
        
            Timer = 0f;
     
        }
    }
    //IEnumerator spawnRoutine()
    //{
    //    GameObject spawnedEnemy = Instantiate(enemies[0], spawnLocations.position, spawnLocations.rotation);
    //    yield return new WaitForSeconds(spawnRate);
    //}
}
