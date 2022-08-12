using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    float timeUntilGeneration;
    [SerializeField] private gamePlayManager playerManager;

     Vector2 direction;
    [SerializeField] int movementDirection;
    int platformLength = 0;



    void Start()
    {
        timeUntilGeneration = Random.Range(0f, 6f);
        if (movementDirection == 0)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (timeUntilGeneration <= Time.timeSinceLevelLoad)
        {
            if (platformLength == 0)
            {
                timeUntilGeneration += Random.Range(5f, 9f + playerManager.DIFFICULTY) / playerManager.DIFFICULTY;

                int length = 7 - playerManager.DIFFICULTY;
                if (length < 1)
                { length = 1; }

                platformLength += Random.Range(0, length);
            }
            else
            {
                timeUntilGeneration = Time.timeSinceLevelLoad + 1f/playerManager.DIFFICULTY;
                platformLength -= 1;
            }


            //int indexValue = Random.Range(0, 2);
            int indexValue = 0;
            FloatingPlatform newPlatform = Instantiate(playerManager.platformLib[indexValue], transform.position, Quaternion.identity, transform);      
            newPlatform.Init(playerManager,direction);
        }



    }
}
