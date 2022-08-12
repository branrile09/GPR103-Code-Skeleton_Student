using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;


[CreateAssetMenu(menuName = "ScriptableObjects/HighScoreSets/SavedHighScore")]
public class HighScoreList : ScriptableObject
{

    public int currentScore;

    [System.Serializable]
    public struct HighScore
    {
        public string name;
        public int score;
        public HighScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

    }

    [SerializeField] public HighScore[] scoreList;


    public void addScore(int newScore, string name)
    {
        //we cycle through to check if we have a new score
        for (int i = 0; i < scoreList.Length; i++)
        {
            
            //if we have a new highscore, we insert and push everything else down. 
            if (newScore >= scoreList[i].score)
            {

                int tempScore = scoreList[i].score;
                string tempName = scoreList[i].name;
                scoreList[i] = new HighScore(name,newScore);
                

                i++;
                while (i < scoreList.Length - 0)
                {
                   
                    int newTempScore = scoreList[i].score;
                    string newTempName = scoreList[i].name;
                    scoreList[i] = new HighScore(tempName, tempScore);                   
                    tempScore = newTempScore;
                    tempName = newTempName;
                    i++;
                }


            }              
        
        }
    
    
    
    }

    public void Submit(string name)
    {
        //we are checking for a name with "null" as we are replacing the name with a valid input
        for (int i = 0; i < scoreList.Length; i++)
        {
            if (scoreList[i].name == "NULL")
            {
                scoreList[i] = new HighScore(name, scoreList[i].score);
                break;
            }
        }



    }


}
