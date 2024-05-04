using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class EnemyHit : MonoBehaviour
{
    public ParticleSystem hitParticles;
    private int health = 3;
    private Rigidbody rb;
    public float speed; 
   // public Transform player;
    //public Transform centreOfEnemy;
    private NavMeshAgent enemy;

    public LocationTracker playerLocation;
    [SerializeField]
    private Vector3 enemyDestination;

    public PLayersHealth playersHealth;
    public int damageNum;

   public SFXControl sfxControl;

    private bool enemyAttacked;



    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        playerLocation = FindObjectOfType<LocationTracker>();
        enemyDestination = playerLocation.GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<NavMeshAgent>();
        //enemy.SetDestination(player.transform.position);
        enemy.SetDestination(enemyDestination);
        enemyAttacked = false;
    }

    void Update()
    {
        if (!playersHealth.isDead)
        {
            enemyDestination = playerLocation.GetComponent<Transform>().position;
            enemy.SetDestination(enemyDestination);
            Quaternion rotation = Quaternion.LookRotation(enemyDestination - transform.position);
            transform.rotation = rotation * Quaternion.Euler(0, 90, 0);
        }
        else
        {
            enemyDestination = this.transform.position;
        }

        
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Bullet")
        {
            //hitParticles.Play();
            health -= damageNum;
            playersHealth.enemyHit += 1;

            Destroy(other.gameObject);
            if (health <= 0)
            {
                hitParticles.Play();
                Destroy(this.gameObject);
                
            }
            
            
            Debug.Log("Enemy Hit" + "\nCurrent health: " + this.health);
        }

        if (other.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);
            Debug.Log("Player Hit");
            //Destroy(this.gameObject);
                                    ////  Debug.Log("Player Hit");
                                    // enemyAttacked = true;
        }
    }
}

