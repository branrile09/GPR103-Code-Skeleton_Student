using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CanvasClass : MonoBehaviour
{
    //uses to canvaslinker to update UI on screen
    [SerializeField]protected CanvasLink CL;
    protected Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    
}
