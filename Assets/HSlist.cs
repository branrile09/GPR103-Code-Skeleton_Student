using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSlist : HSS
{
    // Start is called before the first frame update
    public int Position = 0;
    int Score = 0;
    string name = "N/A";
   

    // Update is called once per frame
    void Update()
    {
        //display scores and name in a list, 
        Score = scoreListRef.scoreList[Position].score;
        name = scoreListRef.scoreList[Position].name;
        string sPosition = (Position + 1).ToString();
        string newString = sPosition + ": "+name+" " + Score;
        text.text = newString;
        

    }
}
