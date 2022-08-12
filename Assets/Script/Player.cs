using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = ""; //The players name for the purpose of storing the high score
    Vector3 startingPosition;

    public int playerTotalLives; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.

    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = false; //Can the player currently move?

    public gamePlayManager playManager;

    bool playerOverWater = false;
    public bool playerOnLog = false;

    int timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {//grabs movement input and moves player in increments
        if (Input.GetKeyDown("w"))
        {
            leaveLog();
            playManager.scoreManager.addScore();
            transform.position += (Vector3)Vector2.up;            
        }
        if (Input.GetKeyDown("a"))
        {
            leaveLog();
            transform.position += (Vector3)Vector2.left;            
        }
        if (Input.GetKeyDown("s"))
        {
            leaveLog();
            transform.position += (Vector3)Vector2.down;            
        }
        if (Input.GetKeyDown("d"))
        {
            leaveLog();
            transform.position += (Vector3)Vector2.right;           
        }

        


    }


    void FixedUpdate()
    {
        //bounddary checking
        bool xBoundary = gameObject.transform.position.x <= 9.5 && gameObject.transform.position.x >= -9.5;
        bool yBoundary = gameObject.transform.position.y <= 7.5 && gameObject.transform.position.y >= -7.5;
        if (!xBoundary || !yBoundary)
        {
            froggyDeath();

        }
        playerOverWater = gameObject.transform.position.y <= 5.5 && gameObject.transform.position.y >= 1.5;
        //checking if frog is over water, if over water check if the frog is on a log. (frong not on log = death)
        if (playerOverWater && !logCheck() && timeCount > 0)
        {
            froggyDeath();
        }
        else if (playerOverWater)
        {
            timeCount++;
        }
        else
        { 
            timeCount = 0;
        }

        if (playerLivesRemaining == 0 || playManager.totalTimeRemaining <= 0)
        {
            playManager.GAMEOVER = true;
        }

    }


    public void froggyDeath()
    {//remove a life, respawn
        playerLivesRemaining--;
        froggyRespawn();

    }
    public void froggyRespawn()
    {
       //make sure we detach from and floating platforms, and go to start position
        transform.position = startingPosition;
        leaveLog();

    }

    private void leaveLog()
    {
        //detach from log
        if (gameObject.GetComponentInParent<FloatingPlatform>())
        {
            gameObject.transform.parent.DetachChildren();
            playerOnLog = false;
        }
        //check to see if we are on a new log
        logCheck();

    }

    private bool logCheck()
    {
        //check parents
        if (gameObject.GetComponentInParent<FloatingPlatform>())        
        {
            playerOnLog = true;
            return true;
        }
        else 
        {//check array of logs (only the logs on the same Y access, or we would be checking all logs)
            foreach (FloatingPlatform fp in playManager.listOfPlatforms)
            {

                if (fp.transform.position.y == this.transform.position.y)
                {//some tolerance checks
                    bool LHS = this.transform.position.x <= fp.transform.position.x + 0.8f;
                    bool RHS = this.transform.position.x >= fp.transform.position.x - 0.8f;

                    if (LHS && RHS)
                    {
                        playerOnLog = true;
                        return true;
                    }

                }
            }
        
        }


        //if we arent on a log, we return false
        
        return false;
    
    }
}
