using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScore : CanvasClass
{   

    // Update is called once per frame
    void Update()
    {//uses to canvaslinker to update score on screen
        string newText = "Score: " + CL.Score;
        text.text = newText;
    }
}
