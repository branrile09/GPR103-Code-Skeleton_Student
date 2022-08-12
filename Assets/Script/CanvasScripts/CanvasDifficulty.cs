using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDifficulty : CanvasClass
{
   

    // Update is called once per frame
    void Update()
    {//uses to canvaslinker to update ddifficulty on screen
        string newText = CL.Difficulty + ":Difficulty";
        text.text = newText;
    }
}
