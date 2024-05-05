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
        //Debug.Log(player.gameON);
        if (player.gameON)
        {
            SpawnEnemies(spawnRate);
 
              
        }

        if(player.isCollected || player.isDead)
        {
            Destroy(this);
            
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
