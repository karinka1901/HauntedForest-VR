using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{

    public bool isCollected;
    private PLayersHealth player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PLayersHealth>();
        isCollected = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            Destroy(this.gameObject);
        }
    }

   
}
