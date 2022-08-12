using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScore : CanvasClass
{
    
    void Update()
    {
        //displays top score to UI
        string newText = CL.TopScore + " :TopScore";
        text.text = newText;
    }
}
