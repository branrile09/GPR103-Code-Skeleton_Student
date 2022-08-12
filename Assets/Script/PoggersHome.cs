using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoggersHome : MonoBehaviour

{
    [SerializeField] gamePlayManager playManager;
    public Player thisPLayer;
    SpriteRenderer poggerHome;

    bool gator = false;
    bool fly = false;

    // Start is called before the first frame update
    void Start()
    {//grabs sprite render
        poggerHome = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tells the player if they die or hit home
        //if player already been there, it cant go there again
        // if theres a croc, player dies
        // if theres a fly, bonus points

        if (poggerHome.enabled == false && collision.GetComponent<Player>() && !gator)
        {
            if (fly)
            {
                playManager.scoreManager.addScore(100);
                fly = false;
            }
            poggerHome.enabled = true;
            thisPLayer.froggyRespawn();
            playManager.DIFFICULTY++;
            playManager.scoreManager.frogGotHome();
        }
        else if (collision.GetComponent<Player>())
        {
            thisPLayer.froggyDeath();
            if (gator)
            {
                playManager.scoreManager.addScore(-100);
                gator = false;
            }
        
        }
    }


    public void Reset()
    {
        //reset
        poggerHome.enabled = false;
        
    }

    public bool flyAndGator(int Type)
    {
        //type 1 = gator
        //type 2 = fly
        // allows the fly and gator to check if they can spawn there, if not,
        //function returns and fly/gator attempt to spawn else where
        if (poggerHome.enabled)
        {
            return false;
        }


        if (Type == 1)
        {
            if (fly)
            {
                return false;
            }
            gator = true;
            return true;

        }
        else if (Type == 2)
        {

            if (gator)
            {
                return false;
            }
            fly = true;
            return true;
        }

        return false;
    
    }

    public bool playerCollision(int Type)
    {
        //allows the fly or gator to check if they have been despawned
        if (poggerHome.enabled)
        {
            return true;
        }

        if (Type == 1)
        {

            if (!gator)
            {
                return true;
            }
            
            return false;
        }


        return false;
    
    }



    public void despawnFlyAndGator()
    {//lets the hoome know that there is no longer a fly or gator
        gator = false;
        fly = false;
    }

}
