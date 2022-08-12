using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FloatingPlatform : MonoBehaviour
{
    [SerializeField] public float speed; //This variable is to be used to control the speed of the vehicle.
    [SerializeField] public Vector2 direction;
    public gamePlayManager playManager;
    public int ID;

    public void Init(gamePlayManager gpm,Vector2 platformDirection)
    {
        direction = platformDirection;
        playManager = gpm;
        playManager.listOfPlatforms.Add(this);
        ID = Random.Range(0, 999999);        
    }

    private void FixedUpdate()
    {   // constant movement 
        // different spawners have different directions, (platforms can go either left or right)
        transform.position += (Vector3)direction * speed * Time.deltaTime * playManager.DIFFICULTY;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this is how we despawn the platform andd remove from a global array
        if (collision.GetComponent<PlatformDespawner>())
        {
            int iterator = 0;
            int indexValue = 0;
            foreach (FloatingPlatform i in playManager.listOfPlatforms)
            {
                if (i == this)
                {
                    indexValue = iterator;
                }
                else
                {
                    iterator++;
                }    
            }
            playManager.listOfPlatforms.RemoveAt(indexValue);
            Destroy(this.gameObject);
        }

        //this is how we parent the player to the log
        if (collision.GetComponent<Player>())
        {            
            Player refPlayer = collision.GetComponent<Player>();
            refPlayer.transform.SetParent(gameObject.transform);
            refPlayer.playerOnLog = true;            
        }

    }
}
