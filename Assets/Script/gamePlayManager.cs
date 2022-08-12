using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePlayManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Vehicle[] vehicleLib;
    public FloatingPlatform[] platformLib;
    public List<FloatingPlatform> listOfPlatforms;
    
    public GameObject preSpawn;
    public HighScoreList scoreListRef;

    public PM persistantManager;
    public int DIFFICULTY = 1;
    public bool GAMEOVER = false;
    public int HighScore = 0;
    
    private float ftimeRemaining = 75;
    public int totalTimeRemaining = 75;

    public ScoreManager scoreManager;
    public Player player;   

    [SerializeField] PoggersHome[] allhomes;


    bool diffUpdate = false;

    void Start()
    {
        //cache all logs to an array (use this for checking if players are on logs

        foreach (Log loggy in preSpawn.GetComponentsInChildren<Log>())
        {
            listOfPlatforms.Add(loggy);
        }

        persistantManager = GetComponent<PM>();
    }

    // Update is called once per frame
    void Update()
    {

        //handdles mostly game over logic, along with difficulty stuff. 
        totalTimeRemaining = (int)(ftimeRemaining - Time.timeSinceLevelLoad);



        if (DIFFICULTY%5 == 1 && diffUpdate)
        {//if all homes filled, we clear them all andd go onto next level. 
            foreach (PoggersHome i in allhomes)
            {
                i.Reset();            
            }
            int multiplier = (DIFFICULTY - 1) / 5;
            scoreManager.addScore(1000 * multiplier);
            scoreManager.addScore(totalTimeRemaining*20 * multiplier);
            ftimeRemaining += 60;
            diffUpdate = false;
        
        }else if (DIFFICULTY % 5 == 2)
        {
            diffUpdate = true;
        }
        //moves to game over screens / highscore stuff

        if (GAMEOVER)
        {
            int finalScore = scoreManager.getScore();
            scoreListRef.currentScore = finalScore;

            if (scoreListRef.scoreList[9].score < finalScore)
            {
                scoreListRef.addScore(finalScore, "NULL");


                Scene thisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(3);
                SceneManager.UnloadScene(thisScene);
            }
            else
            {
                Scene thisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(2);
                SceneManager.UnloadScene(thisScene);

            }            
        }


    }
}
