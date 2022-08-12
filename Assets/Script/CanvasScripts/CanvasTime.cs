using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTime : CanvasClass
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {//uses to canvaslinker to update time on screen
        string newText = "Time: " + CL.timeRemaining;
        text.text = newText;
    }
}
