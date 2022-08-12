using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentLevel = 1;
    private int score = 0;
    // Start is called before the first frame update
    //self documentinf functions for keeping track of score, and managing. 
    public void addScore()
    {
        score += 10 * currentLevel;
    }
    public void addScore(int pointsAdded)
    {
        score += pointsAdded;
    }
    public void frogGotHome()
    {
        score += 50 * currentLevel;
        currentLevel++;
    }

    public void Reset()
    {
        currentLevel = 1;
        score = 0;
    }

    public int getScore()
    {
        return score;
    }

}
