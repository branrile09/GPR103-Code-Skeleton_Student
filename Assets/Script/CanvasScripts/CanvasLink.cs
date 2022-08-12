using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLink : MonoBehaviour
{
    [SerializeField] gamePlayManager playManager;
    public int Score;
    public int TopScore = 0;
    public int Difficulty;
    public int timeRemaining;
    public int livesRemaining;
    public HighScoreList scoreListRef;
    //we store all the info needed for the UI in our canvas link
    private void Start()
    {
        TopScore = scoreListRef.scoreList[0].score;
    }

    void Update()
    {//every update we check all the variables from playmanager to keep UI up to date
        if (playManager.GAMEOVER == true)
        {
            gameObject.SetActive(false);
        }

        Score = playManager.scoreManager.getScore();
        Difficulty = playManager.DIFFICULTY;
        livesRemaining = playManager.player.playerLivesRemaining;
        timeRemaining = playManager.totalTimeRemaining;
        

    }
}
