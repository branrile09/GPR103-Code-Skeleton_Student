using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outputScore : CanvasClass
{
    // Start is called before the first frame update
    public HighScoreList scoreListRef;  

    // Update is called once per frame
    void Update()
    {// display your score when game over
       string newText = "your score: " + scoreListRef.currentScore.ToString();
       text.text = newText;
    }
}
