using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeBonus : MonoBehaviour
{
    public PoggersHome[] homes;
    
    protected SpriteRenderer thisSprite;

    public float timeUntilUpdate = 0f;
    public float timeUntilDespawn = 0f;

    protected int type;

    public bool active = false;
    public bool set = false;

    public int Placement;


    // Start is called before the first frame update
    void Start()
    {
        thisSprite = this.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

       //if not active and not set, we set up the new spawn time
        if (!active && !set)
        {
            if (timeUntilUpdate < Time.timeSinceLevelLoad)
            {
                timeUntilUpdate = Time.timeSinceLevelLoad + Random.RandomRange(3f,6f);
                set = true;                       
            }
        
        }


        //when set we check for if its time to spaawn
        if (!active && set)
        {
            if (timeUntilUpdate < Time.timeSinceLevelLoad)
            {
                int count = 0;
                do {
                    int random = Random.Range(0, homes.Length);
                    bool newPlace = homes[random].flyAndGator(type);
                    //we check if we can find a home for the fly
                    //once found, we set active, position, etc.
                    if (newPlace)
                    {
                        active = true;
                        this.transform.position = homes[random].transform.position;
                        thisSprite.enabled = true;
                        active = true;
                        Placement = random;
                        timeUntilDespawn = Time.timeSinceLevelLoad + Random.RandomRange(3f, 6f); ;
                    }
                    //maximum of 12 attempts to find a home, if the last home is occupied then its not possible to find one
                    // in this case we want to break this loop and set a new timer for set. 
                    if (count == 12)
                    {
                        set = false;
                        active = false;
                        break;                    
                    }
                    count++;
                }
                while (!active);


            }
        }


        //we check for player collision with the home, and despawn timer
        //if either conditions met, we de-spawn.
        if (active && (homes[Placement].playerCollision(type)|| timeUntilDespawn < Time.timeSinceLevelLoad))
        {
            active = false;
            set = false;
            thisSprite.enabled = false;
            if (timeUntilDespawn < Time.timeSinceLevelLoad)
            {//if it was the despawn trigger, we need to notifiy the home. 
                homes[Placement].despawnFlyAndGator();
            }

        }
        







    }
}
