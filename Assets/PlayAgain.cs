using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {// returns to game scene when enter is presed. 
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(1);
            SceneManager.UnloadScene(thisScene);

        }


    }
}
