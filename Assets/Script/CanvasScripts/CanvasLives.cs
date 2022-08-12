using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLives : CanvasClass
{
    // Update is called once per frame
    void Update()
    {//uses to canvaslinker to update lives on screen
        string newText = "Lives: " + CL.livesRemaining;
        text.text = newText;
    }
}
