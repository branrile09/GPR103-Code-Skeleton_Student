using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PM : MonoBehaviour
{
    public static inputManager InputManager;
    // Start is called before the first frame update
    Scene currentscene;
    void Start()
    {
        DontDestroyOnLoad(this);
        InputManager = GetComponent<inputManager>();

        SceneManager.LoadScene(1);
        currentscene = SceneManager.GetActiveScene();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene() != currentscene)
        {
           

        
        }

    }

}
