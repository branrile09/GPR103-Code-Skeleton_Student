using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class vehicleSpawner : MonoBehaviour
{
    float timeUntilGeneration;
    [SerializeField] private gamePlayManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilGeneration = Random.Range(0f,6f);        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilGeneration <= Time.timeSinceLevelLoad) //chcek for if time to generate
        {//spawn gen based on difficulty
            timeUntilGeneration += (Random.Range(5f, 9f)/playerManager.DIFFICULTY); 
            int indexValue = Random.Range(0, 2); 
            Vehicle newVehicle = Instantiate(playerManager.vehicleLib[indexValue], transform.position,Quaternion.identity,transform);
            newVehicle.Init(playerManager);
            //initializes the self managing game object
        }
        

    }
}
