using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Vehicle : MonoBehaviour
{
    
    [SerializeField]public float speed; //This variable is to be used to control the speed of the vehicle.
    public gamePlayManager playManager;
    public Sprite[] sprites;

    private void FixedUpdate()
    { //use of movement
        transform.position += (Vector3)Vector2.left * speed * Time.deltaTime * playManager.DIFFICULTY;
    }
    public void Init(gamePlayManager gpm)
    {        //initializes play manager into the object.
        playManager = gpm;
        SpriteRenderer thisSpriterender = transform.GetComponent<SpriteRenderer>();
        //int index = 0;
        int size = sprites.Length - 1;

        int index = Random.Range(0, size);
        thisSpriterender.sprite = sprites[index];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //despawn vehicle when hits despawner. 
        if (collision.GetComponent<vehicleDespawner>())
        {
            Destroy(this.gameObject);
        }
        //trigger player death. 
        if (collision.GetComponent<Player>())
        {
            Player refPlayer = collision.GetComponent<Player>();
            refPlayer.froggyDeath();
        }

    }
}
